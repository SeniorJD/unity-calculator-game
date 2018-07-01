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

        Sprite gold = Resources.Load<Sprite>("Textures/v2/gold_0");
        Sprite silver = Resources.Load<Sprite>("Textures/v2/silver_0");
        Sprite bronze = Resources.Load<Sprite>("Textures/v2/bronze_0"); ;

        //GameObject starPanel = Resources.Load<GameObject>("StarPanel");
        Debug.Log("Levels2MenuScript gt:" + GameData.LevelType + "; LN:" + GameData.LevelNumber);

        int prevStarsCount = 1;

        for (int i = 0; i < progress.Length; i++)
        {
            int starsCount = GameData.GetStarsCount(GameData.LevelType, i, progress[i]);
            Debug.Log("level: " + i + "; starts: " + starsCount + "; progress: " + progress[i]);
            bool active = prevStarsCount > 0;

            prevStarsCount = starsCount;

            Button button = GameObject.Find(prefix + (i + 1)).GetComponent<Button>();
            button.interactable = active;

            if (starsCount < 1)
            {
                continue;
            }

            if (starsCount == 1)
            {
                button.image.sprite = bronze;
            } else if (starsCount == 2)
            {
                button.image.sprite = silver;
            } else if (starsCount == 3)
            {
                button.image.sprite = gold;
            }
        }

        Text text = GameObject.Find("LevelNameText").GetComponent<Text>();

        string s;
        switch(GameData.LevelType)
        {
            case GameData.PLUS_LEVEL_TYPE:
                s = "Plus";
                break;
            case GameData.MINUS_LEVEL_TYPE:
                s = "Minus";
                break;
            case GameData.MULTIPLY_LEVEL_TYPE:
                s = "Multiply";
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
        SceneManager.LoadScene("PlayScene_v2");
    }

    public void OnBackPressed()
    {
        SceneManager.LoadScene("LevelsMenuScene_v2");
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnBackPressed();
        }
    }
}
