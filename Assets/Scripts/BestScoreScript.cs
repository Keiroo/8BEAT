using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScript : MonoBehaviour {

    public Text bestScoreText;

    private int bestScore;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        bestScore = PlayerPrefs.GetInt("BestScore");

        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
