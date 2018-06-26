using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                GameControl.instance.enemyCanMove = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameControl.instance.enemyCanMove = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
