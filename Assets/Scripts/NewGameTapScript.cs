using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameTapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnNewGameTap()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log(GameControl.instance);
        if (GameControl.level != 1 || GameControl.GetScore() != 0)
        {
            GameControl.RstLevel();
            GameControl.RstScore();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
