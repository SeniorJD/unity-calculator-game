using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels2MenuScript : MonoBehaviour {

    private void Awake()
    {
        int[] progress = GameData.LoadStoryProgress(GameData.LevelType);
        string prefix = "Level_";

        GameObject starPanel = Resources.Load<GameObject>("StarPanel");
        Debug.Log("Levels2MenuScript gt:" + GameData.LevelType + "; LN:" + GameData.LevelNumber);

        for (int i = 0; i < progress.Length; i++)
        {
            int starsCount = GameData.GetStarsCount(GameData.LevelType, i, progress[i]);
            Debug.Log("level: " + i + "; starts: " + starsCount + "; progress: " + progress[i]);
            bool active = starsCount > -1;

            Button button = GameObject.Find(prefix + (i + 1)).GetComponent<Button>();
            button.interactable = active;

            if (starsCount < 1)
            {
                continue;
            }

            GameObject starsPanel = button.transform.Find("StarsPanel").gameObject;

            for (int j = 0; j < starsCount; j++)
            {
                GameObject starPanelInstance = Instantiate(starPanel);
                starPanelInstance.transform.SetParent(starsPanel.transform);
                starPanelInstance.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }

        Text text = GameObject.Find("LevelNameText").GetComponent<Text>();

        string s;
        switch(GameData.LevelType)
        {
            case GameData.PLUS_LEVEL_TYPE:
                s = "Plus Levels";
                break;
            case GameData.MINUS_LEVEL_TYPE:
                s = "Minus Levels";
                break;
            case GameData.MULTIPLY_LEVEL_TYPE:
                s = "Multiply Levels";
                break;
            default:
                s = "ERROR";
                break;
        }
        text.text = s;
    }

    public void OnLevelButtonPressed(int code)
    {
        GameData.LevelNumber = code;
        SceneManager.LoadScene("PlayScene");
    }

    public void OnBackPressed()
    {
        SceneManager.LoadScene("LevelsMenuScene");
    }
}
