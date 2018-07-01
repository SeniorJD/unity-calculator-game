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

    public Image image;

    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;

    private void Start()
    {
        if (GameData.IsStoryMode())
        {
            nextButton.gameObject.SetActive(true);
            int starsCount = GameData.GetStarsCount(GameData.LevelType, GameData.LevelNumber, GameData.LastScore);

            if (starsCount > 0)
            {
                nextButton.interactable = true;
                image.color = new Color(1f, 1f, 1f, 1f);

                if (starsCount == 1)
                {
                    image.sprite = bronze;
                    currentScoreText.color = new Color(0.7f, 0.45f, 0.32f);
                } else if (starsCount == 2)
                {
                    image.sprite = silver;
                    currentScoreText.color = new Color(0.93f, 0.93f, 0.93f);
                }
                else if (starsCount == 3)
                {
                    image.sprite = gold;
                    currentScoreText.color = new Color(0.99f, 0.99f, 0.15f);
                }

            } else
            {
                image.sprite = bronze;
                image.color = new Color(1f, 1f, 1f, 0f);
                currentScoreText.color = new Color(0.5f, 0.5f, 0.5f);
                nextButton.interactable = false;
            }

            currentScoreText.text = "Time " + GameData.LastScore + " s";
            if (GameData.IsNewBest())
            {
                bestScoreText.text = "new best!";
                bestScoreText.color = new Color(0.99f, 0.99f, 0.15f);
            } else
            {
                bestScoreText.text = "Best " + GameData.GetScore(GameData.GameType, GameData.LevelType, GameData.LevelNumber) + " s";
                bestScoreText.color = new Color(0.93f, 0.93f, 0.93f);
            }
        } else
        {
            nextButton.gameObject.SetActive(false);

            currentScoreText.text = "Score " + GameData.LastScore;
            if (GameData.IsNewBest())
            {
                bestScoreText.text = "new best!";
                bestScoreText.color = new Color(0.99f, 0.99f, 0.15f);
            }
            else
            {
                bestScoreText.text = "Best " + GameData.GetScore(GameData.GameType, GameData.LevelType, GameData.LevelNumber);
                bestScoreText.color = new Color(0.93f, 0.93f, 0.93f);
            }
        }
    }

    public void OnAgainButtonPressed()
    {
        SceneManager.LoadScene("PlayScene_v2");
    }

    public void OnNextButtonPressed()
    {
        GameData.LevelNumber++;
        SceneManager.LoadScene("PlayScene_v2");
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene_v2");
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnMenuButtonPressed();
        }
    }
}
