using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySceneScript : MonoBehaviour {
    private static Color GREEN = new Color(0.77f, 0.99f, 0.77f);
    private static Color YELLOW = new Color(0.99f, 0.99f, 0.76f);
    private static Color NORMAL = new Color(0.66f, 0.66f, 0.66f);
    private static Color RED = new Color(0.99f, 0.77f, 0.77f);

    private static string MINUS = "-";



    public Text timeText;
    public Text scoreText;
    public Text taskText;
    public Text inputText;
    public Text bonusText;

    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject rightPanel;
    public GameObject wrongPanel;

    //private Image inputPanelImage;

    private static int gameType;
    private static int levelType;
    private static int levelIndex;

    bool storyMode;
    bool started = false;
    bool ignoreKeyboard = false;

    float timeLeft;

    protected int scoreValue;
    private string enterValue;
    private string expectedResult;

    private LevelGenerator levelGenerator;

    List<string> tasksSet = new List<string>();
    List<string> resultsSet = new List<string>();


    private void Awake()
    {
        gameType = GameData.GameType;
        levelType = GameData.LevelType;
        levelIndex = GameData.LevelNumber;

        storyMode = gameType == GameData.STORY_GAME_TYPE;

        if (storyMode)
        {
            SetTimerValue(0);
            SetScoreValue(10);
        } else
        {
            SetTimerValue(60);
            SetScoreValue(0);
        }

        taskText.text = "";
        inputText.text = "";

        //inputPanelImage = GameObject.Find("TaskPanel").GetComponent<Image>();

        startPanel.SetActive(true);
        pausePanel.SetActive(false);
        bonusText.gameObject.SetActive(false);

        started = false;
        ignoreKeyboard = false;
    }

    void SetTimerValue(float value)
    {
        timeLeft = value;
        timeText.text = ((int)timeLeft).ToString();
    }

    void SetScoreValue(int value)
    {
        scoreValue = value;
        scoreText.text = ((int)scoreValue).ToString();
    }

    private string GetEnterValue()
    {
        return enterValue;
    }

    void SetEnterValue(string value)
    {
        this.enterValue = value;

        ValueChanged();
    }

    void SetEnterFieldText(string value)
    {
        this.inputText.text = value;
    }

    private void ValueChanged()
    {
        SetEnterFieldText(GetEnterValue());

        CheckEntered();
    }

    private void CheckEntered()
    {
        string text = GetEnterValue();

        if (text.Equals(expectedResult))
        {
            //inputPanelImage.color = GREEN;
            rightPanel.SetActive(true);

            if (gameType == GameData.STORY_GAME_TYPE)
            {
                SetScoreValue(scoreValue - 1);

                if (scoreValue == 0)
                {
                    LevelDone();
                    return;
                }
            }
            else if (gameType == GameData.TIME_ATTACK_GAME_TYPE)
            {
                SetScoreValue(scoreValue + 1);
                SetTimerValue(timeLeft + 2);
                ShowBonus(2);
            }
            else
            {
                throw new System.Exception("gameType: " + gameType);
            }

            WaitAndGenerate();
        }
        else
        {
            if (expectedResult.Contains(MINUS))
            {
                if (text.Contains(MINUS))
                {
                    if (expectedResult.Length <= text.Length)
                    {
                        //inputPanelImage.color = RED;
                        wrongPanel.SetActive(true);

                        Handheld.Vibrate();
                        if (GameData.IsStoryMode())
                        {
                            SetTimerValue(timeLeft + 1);
                            ShowBonus(1);
                        }
                        else if (GameData.IsTimeAttackMode())
                        {
                            SetTimerValue(timeLeft - 1);
                            ShowBonus(-1);
                        }
                        else
                        {
                            throw new System.Exception("gameType: " + gameType);
                        }

                        WaitAndSetGreen();
                    }
                }
            }
            else if (!text.Contains(MINUS))
            {
                if (expectedResult.Length <= text.Length)
                {
                    //inputPanelImage.color = RED;
                    wrongPanel.SetActive(true);

                    Handheld.Vibrate();
                    if (GameData.IsStoryMode())
                    {
                        SetTimerValue(timeLeft + 1);
                        ShowBonus(1);
                    }
                    else if (GameData.IsTimeAttackMode())
                    {
                        SetTimerValue(timeLeft - 1);
                        ShowBonus(-1);
                    }
                    else
                    {
                        throw new System.Exception("gameType: " + gameType);
                    }

                    WaitAndSetGreen();
                }
            }
            else
            {
                if (expectedResult.Length + 1 <= text.Length)
                {
                    //inputPanelImage.color = RED;
                    wrongPanel.SetActive(true);

                    Handheld.Vibrate();
                    if (GameData.IsStoryMode())
                    {
                        SetTimerValue(timeLeft + 1);
                        ShowBonus(1);
                    }
                    else if (GameData.IsTimeAttackMode())
                    {
                        SetTimerValue(timeLeft - 1);
                        ShowBonus(-1);
                    }
                    else
                    {
                        throw new System.Exception("gameType: " + gameType);
                    }

                    WaitAndSetGreen();
                }
            }
        }
    }

    private void ShowBonus(int difference)
    {
        if (GameData.IsStoryMode())
        {
            if (difference > 0)
            {
                ShowBonus("+" + difference, Color.red);
            }
            else if (difference < 0)
            {
                ShowBonus(difference.ToString(), Color.green);
            }
        }
        else if (GameData.IsTimeAttackMode())
        {
            if (difference > 0)
            {
                ShowBonus("+" + difference, Color.green);
            }
            else if (difference < 0)
            {
                ShowBonus(difference.ToString(), Color.red);
            }
        }
    }

    IEnumerator showBonusCaroutine;
    private void ShowBonus(string bonus, Color color)
    {
        if (showBonusCaroutine != null)
        {
            StopCoroutine(showBonusCaroutine);
        }
        bonusText.text = bonus;
        bonusText.color = color;
        int maxX = 0;
        string text = timeText.text;
        timeText.font.RequestCharactersInTexture(text);
        foreach (char c in text)
        {
            CharacterInfo ci;
            if (timeText.font.GetCharacterInfo(c, out ci))
            {
                maxX += ci.maxX;
            }
        }
        Vector2 anchoredPosition = timeText.GetComponent<RectTransform>().anchoredPosition;
        bonusText.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPosition.x + timeText.GetComponent<RectTransform>().rect.width, anchoredPosition.y);
        //bonusText.transform.position = new Vector3(maxX + 45, timeText.transform.position.y);

        bonusText.gameObject.SetActive(true);

        showBonusCaroutine = CreateShowBonusCoroutine();
        StartCoroutine(showBonusCaroutine);
    }

    IEnumerator CreateShowBonusCoroutine()
    {
        ignoreKeyboard = true;
        yield return new WaitForSeconds(1);
        ignoreKeyboard = false;
        bonusText.gameObject.SetActive(false);
        showBonusCaroutine = null;
    }

    IEnumerator waitAndSetGreenCaroutine;
    private void WaitAndSetGreen()
    {
        if (waitAndSetGreenCaroutine != null)
        {
            StopCoroutine(waitAndSetGreenCaroutine);
        }

        waitAndSetGreenCaroutine = CreateWaitAndSetGreenCoroutine();
        StartCoroutine(waitAndSetGreenCaroutine);
    }

    IEnumerator CreateWaitAndSetGreenCoroutine()
    {
        ignoreKeyboard = true;
        yield return new WaitForSeconds(0.2f);
        ignoreKeyboard = false;
        SetEnterValue("");
        //inputPanelImage.color = NORMAL;
        wrongPanel.SetActive(false);
        rightPanel.SetActive(false);
        waitAndSetGreenCaroutine = null;
    }

    IEnumerator waitAndGenerateCoroutine;
    private void WaitAndGenerate()
    {
        if (waitAndGenerateCoroutine != null)
        {
            StopCoroutine(waitAndGenerateCoroutine);
        }

        waitAndGenerateCoroutine = CreateWaitAndGenerateCoroutine();
        StartCoroutine(waitAndGenerateCoroutine);
    }

    IEnumerator CreateWaitAndGenerateCoroutine()
    {
        ignoreKeyboard = true;
        yield return new WaitForSeconds(0.3f);
        ignoreKeyboard = false;
        GenerateNewTask();
        waitAndGenerateCoroutine = null;
    }

    void LevelDone()
    {
        started = false;

        if (storyMode)
        {
            GameData.SetScore(GameData.STORY_GAME_TYPE, GameData.LevelType, GameData.LevelNumber, (int)timeLeft);

            GameData.ClearTempData();
            GameData.GameType = gameType;
            GameData.LevelType = levelType;
            GameData.LevelNumber = levelIndex;
            GameData.LastScore = (int)timeLeft;

            SceneManager.LoadScene("ScoreScene");
        }
        else
        {
            GameData.SetScore(scoreValue);

            GameData.ClearTempData();
            GameData.GameType = gameType;
            GameData.LastScore = scoreValue;

            SceneManager.LoadScene("ScoreScene");
        }
    }

    public void StartLevel()
    {
        started = true;

        GenerateNewTask();
    }

    private void GenerateNewTask()
    {
        if (levelGenerator == null)
        {
            levelGenerator = LevelGenerator.GetGenerator(gameType, levelType, levelIndex);
            Debug.Log(levelGenerator);
        }

        LevelGenerator.Task task = GenerateNewTaskImpl();

        tasksSet.Add(task.getTask());
        resultsSet.Add(task.getExpectedResult());

        expectedResult = task.getExpectedResult();
        taskText.text = task.getTask() + " =";
        //inputPanelImage.color = NORMAL;
        wrongPanel.SetActive(false);
        rightPanel.SetActive(false);
        SetEnterValue("");
    }

    private LevelGenerator.Task GenerateNewTaskImpl()
    {
        LevelGenerator.Task task;
        Debug.Log("gameType: " + gameType + "; " + (gameType == GameData.TIME_ATTACK_GAME_TYPE));
        if (gameType == GameData.TIME_ATTACK_GAME_TYPE)
        {
            task = levelGenerator.GenerateTask(scoreValue);
        }
        else
        {
            task = levelGenerator.GenerateTask();
        }

        while (tasksSet.Contains(task.getTask()) /*|| resultsSet.Contains(task.getExpectedResult())*/)
        {
            Debug.Log("retry");
            if (gameType == GameData.TIME_ATTACK_GAME_TYPE)
            {
                task = levelGenerator.GenerateTask(scoreValue);
            }
            else
            {
                task = levelGenerator.GenerateTask();
            }
        }

        return task;
    }

    public void OnButtonPressed(int code)
    {
        if (ignoreKeyboard)
        {
            return;
        }

        if (!started)
        {
            return;
        }

        if (code < 10)
        {
            string enterValue = GetEnterValue();

            enterValue += code;

            SetEnterValue(enterValue);
        } else if (code == 10)
        {
            string text = GetEnterValue();

            if (text.StartsWith(MINUS))
            {
                text = text.Substring(1);
            }
            else if (text.Length < 10)
            {
                text = MINUS + text;
            }

            SetEnterValue(text);
        }
        else if (code == 11)
        {
            string text = GetEnterValue();

            if (text.Length != 0)
            {
                text = text.Substring(0, text.Length - 1);
                SetEnterValue(text);
            }
        }
    }

    public void OnPauseButtonPressed(int code)
    {
        if (code == 0)
        {
            started = true;
            GenerateNewTask();
            pausePanel.SetActive(!pausePanel.activeSelf);
        } else if (code == 1)
        {
            GameData.SetScore(-1);
            Awake();
        } else if (code == 2)
        {
            GameData.ClearTempData();
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    private void Update()
    {
        if (!started)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                started = true;
                GenerateNewTask();
            } else
            {
                started = false;
            }

            pausePanel.SetActive(!pausePanel.activeSelf);
            return;
        }

        if (storyMode)
        {
            timeLeft += Time.deltaTime;
            SetTimerValue(timeLeft);
        }
        else
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                LevelDone();
            }
            else
            {
                SetTimerValue(timeLeft);
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        started = false;
        pausePanel.SetActive(true);
    }
}
