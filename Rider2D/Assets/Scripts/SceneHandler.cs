using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    public bool Finished;
    public Text restartUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Finished)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ReloadLevel(bool isWin)
    {
        if (isWin)
        {
            restartUI.text = "You win! 'R' to restart";
        }
        else
        {
            restartUI.text = "GameOver! 'R' to restart";
        }

    }
}
