using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScene : MonoBehaviour {

    public Text currentScoreText;
    public Text bestScoreText;

    public Button againButton;
    public Button nextButton;
    public Button menuButton;

    private void Start()
    {
        if (GameData.IsStoryMode())
        {
            nextButton.gameObject.SetActive(true);
            int starsCount = GameData.GetStarsCount(GameData.LevelType, GameData.LevelNumber, GameData.LastScore);

            if (starsCount > 0)
            {
                nextButton.interactable = true;
                GameObject starPanel = Resources.Load<GameObject>("StarPanel");
                GameObject starsPanel = GameObject.Find("StarsPanel").gameObject;

                for (int j = 0; j < starsCount; j++)
                {
                    GameObject starPanelInstance = Instantiate(starPanel);
                    starPanelInstance.transform.SetParent(starsPanel.transform);
                    starPanelInstance.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);
                }

            } else
            {
                nextButton.interactable = false;
            }

            currentScoreText.text = "Time " + GameData.LastScore + "s";
            bestScoreText.text = "Best " + GameData.GetScore(GameData.GameType, GameData.LevelType, GameData.LevelNumber) + "s";
        } else
        {
            nextButton.gameObject.SetActive(false);

            currentScoreText.text = "Score " + GameData.LastScore;
            bestScoreText.text = "Best " + GameData.GetScore(GameData.GameType, GameData.LevelType, GameData.LevelNumber);
        }
    }

    public void OnAgainButtonPressed()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OnNextButtonPressed()
    {
        GameData.LevelNumber++;
        SceneManager.LoadScene("PlayScene");
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
