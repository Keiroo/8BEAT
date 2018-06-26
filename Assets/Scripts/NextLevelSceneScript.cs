using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSceneScript : MonoBehaviour {


    private int lvl;
    private int maxLvl;
    private int lastScore;

	// Use this for initialization
	void Start () {
        lvl = GameControl.level;
        maxLvl = GameControl.maxLevel;
	}
	
	// Update is called once per frame
	void Update () {
        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began)
        //    {
        //        if (lvl < maxLvl)
        //        {
        //            GameControl.instance.enemyCanMove = true;

        //            lastScore = GameControl.instance.LoadLastScore();
        //            Debug.Log(lastScore);
        //            SceneManager.LoadScene("MainGame");
        //            GameControl.instance.AddLevel();
        //            GameControl.instance.SetScore(lastScore);
        //        }
        //        else
        //        {
        //            GameControl.instance.enemyCanMove = true;
        //            SceneManager.LoadScene("MainMenu");
        //        }
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameControl.instance.enemyCanMove = true;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnMainMenuTap()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNextLevelTap()
    {
        if (lvl < maxLvl)
        {
            GameControl.instance.enemyCanMove = true;

            lastScore = GameControl.instance.LoadLastScore();
            Debug.Log(lastScore);
            SceneManager.LoadScene("MainGame");
            GameControl.instance.AddLevel();
            GameControl.instance.SetScore(lastScore);
        }
    }
}
