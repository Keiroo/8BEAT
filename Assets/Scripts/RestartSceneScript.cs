using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour {

    private bool gameOver;
    private int lastScore;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        gameOver = GameControl.instance.gameOver;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (gameOver == true && Input.GetTouch(i).phase == TouchPhase.Began)
        //    {
        //        GameControl.instance.enemyCanMove = true;
        //        SceneManager.LoadScene("MainGame");

        //    }
        //}
    }

    public void OnRestartTap()
    {
        if (gameOver == true)
        {
            GameControl.instance.enemyCanMove = true;
            lastScore = GameControl.instance.LoadLastScore();
            SceneManager.LoadScene("MainGame");
            GameControl.instance.SetScore(lastScore);

        }
    }

    public void OnMainMenuTap()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
