using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickListener : MonoBehaviour {

    private PlaySceneScript_v2 playScript;

    private void Start()
    {
        playScript = FindObjectOfType<Canvas>().GetComponent<PlaySceneScript_v2>();
    }
    void Update () {
		if (Input.GetMouseButtonUp(0))
        {
            playScript.StartLevel();
            gameObject.SetActive(false);
        }
	}
}
