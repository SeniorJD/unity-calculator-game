using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {
    public const int STORY_GAME_TYPE = 0;
    public const int TIME_ATTACK_GAME_TYPE = 1;

    public const int PLUS_LEVEL_TYPE = 0;
    public const int MINUS_LEVEL_TYPE = 1;
    public const int MULTIPLY_LEVEL_TYPE = 2;

    private const string STORY_PROGRESS_KEY = "storyProgress";
    private const string TIME_ATTACK_PROGRESS_KEY = "timeAttackProgress";
    private const string DELIMITER = "_";

    private static int gameType;
    private static int levelType;
    private static int levelNumber;

    private static int lastScore;

    public static int GameType {
        get { return gameType; }
        set { gameType = value; }
    }

    public static int LevelType
    {
        get { return levelType; }
        set { levelType = value; }
    }

    public static int LevelNumber
    {
        get { return levelNumber; }
        set { levelNumber = value; }
    }

    public static int LastScore
    {
        get { return lastScore; }
        set { lastScore = value; }
    }

    public static bool IsStoryMode()
    {
        return gameType == STORY_GAME_TYPE;
    }

    public static bool IsTimeAttackMode()
    {
        return gameType == TIME_ATTACK_GAME_TYPE;
    }

    public static int[] LoadStoryProgress(int levelType)
    {
        int storyProgress = PlayerPrefs.GetInt(STORY_PROGRESS_KEY, 0);
        //if (storyProgress < levelType)
        //{
        //    return GenerateDefaultArray();
        //}

        int[] result = new int[15];
        int prevResult = 0;
        for (int i = 0; i < result.Length; i++)
        {
            string key = STORY_PROGRESS_KEY + DELIMITER + levelType + DELIMITER + i;
            int progress = PlayerPrefs.GetInt(key, -1);

            if (progress == -1 && prevResult > -1)
            {
                result[i] = 0;
            } else
            {
                result[i] = progress;
            }

            prevResult = progress;
        }

        if (result[0] == -1)
        {
            result[0] = 0;
        }

        return result;
    }

    private static int[] GenerateDefaultArray()
    {
        int[] result = new int[15];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = -1;
        }

        return result;
    }

    public static int GetStarsCount(int levelType, int levelIndex, int timerValue)
    {
        if (timerValue == -1)
        {
            return -1;
        }

        if (timerValue == 0)
        {
            return 0;
        }

        int optimalTime = 15 * ((levelType + 2) / 2) * (levelIndex + 2) / 2;
        if (timerValue <= optimalTime)
        {
            return 3;
        }
        else if (timerValue <= optimalTime * 1.5)
        {
            return 2;
        }
        else if (timerValue <= optimalTime * 2)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static void SetScore(int score)
    {
        SetScore(TIME_ATTACK_GAME_TYPE, -1, -1, score);
    }

    public static void SetScore(int gameType, int levelType, int level, int score)
    {
        if (gameType == STORY_GAME_TYPE)
        {
            string key = STORY_PROGRESS_KEY + DELIMITER + levelType + DELIMITER + level;
            int oldScore = PlayerPrefs.GetInt(key, -1);
            Debug.Log("A " + key);
            Debug.Log("A " + oldScore);
            Debug.Log("A " + score);

            if (oldScore == -1 || score < oldScore)
            {
                PlayerPrefs.SetInt(key, score);
                Debug.Log("A " + PlayerPrefs.GetInt(key, -1));
            }
        } else
        {
            string key = TIME_ATTACK_PROGRESS_KEY;
            int oldScore = PlayerPrefs.GetInt(key, -1);
            Debug.Log("B " + key);
            Debug.Log("B " + oldScore);
            Debug.Log("B " + score);

            if (oldScore == -1 || score > oldScore)
            {
                PlayerPrefs.SetInt(key, score);
                Debug.Log("B " + PlayerPrefs.GetInt(key, -1));
            }
        }
    }

    public static int GetScore(int gameType, int levelType, int level)
    {
        Debug.Log("GetScore: gameType:" + gameType + "; levelType:" + levelType + "; level: " + level);
        if (gameType == STORY_GAME_TYPE)
        {
            string key = STORY_PROGRESS_KEY + DELIMITER + levelType + DELIMITER + level;

            return PlayerPrefs.GetInt(key, -1);
        } else
        {
            string key = TIME_ATTACK_PROGRESS_KEY;

            return PlayerPrefs.GetInt(key, -1);
        }
    }

    public static void ClearTempData()
    {
        gameType = -1;
        levelType = -1;
        levelNumber = -1;
        lastScore = -1;
    }
}
