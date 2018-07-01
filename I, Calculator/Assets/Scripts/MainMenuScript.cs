using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private void Awake()
    {
        
    }

    public void OnLevelsPressed()
    {
        SceneManager.LoadScene("LevelsMenuScene_v2");
    }

    public void OnTimeAttackPressed()
    {
        GameData.ClearTempData();
        GameData.GameType = GameData.TIME_ATTACK_GAME_TYPE;
        SceneManager.LoadScene("PlayScene_v2");
    }

    public void OnTutorialPressed()
    {

    }

    public void OnExitPressed()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        //    activity.Call<bool>("moveTaskToBack", true);
        //}
        //else
        //{
            Application.Quit();
        //}
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnExitPressed();
        }
    }
}
