using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuScript : MonoBehaviour {

    public void OnPlusLevelsPressed()
    {
        GameData.GameType = GameData.STORY_GAME_TYPE;
        GameData.LevelType = GameData.PLUS_LEVEL_TYPE;
        SceneManager.LoadScene("Levels2MenuScene");
    }

    public void OnMinusLevelsPressed()
    {
        GameData.GameType = GameData.STORY_GAME_TYPE;
        GameData.LevelType = GameData.MINUS_LEVEL_TYPE;
        SceneManager.LoadScene("Levels2MenuScene");
    }

    public void OnMultiplyLevelsPressed()
    {
        GameData.GameType = GameData.STORY_GAME_TYPE;
        GameData.LevelType = GameData.MULTIPLY_LEVEL_TYPE;
        SceneManager.LoadScene("Levels2MenuScene");
    }


    public void OnBackPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int range = Random.Range(0, 15);
            for (int i = 0; i < range; i++)
            {
                string key = "storyProgress" + 0 + "" + i;

                int value = Random.Range(0, 3);

                PlayerPrefs.SetInt(key, value);
            }

            for (int i = range; i < 15; i++)
            {
                string key = "storyProgress" + 0 + "" + i;

                int value = -1;

                PlayerPrefs.SetInt(key, value);
            }
        }
    }
}
