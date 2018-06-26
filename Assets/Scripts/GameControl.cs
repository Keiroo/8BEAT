using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject player;
    public Button[] buttons;
    public Text scoreText;
    public Text lifePointsText;
    public Text Timer;
    public GameObject audioPlayer;
    public GameObject middleLine;
    public Sprite[] middleLineSprites;
    public bool gameOver = false;
    public bool enemyCanMove = true;
    public static int level = 1;
    public static int maxLevel = 2;

    private AudioSource audioSource;
    private List<GameObject> enemies;
    private static int score;
    private static int lastScore = 0;
    private int lifePoints = 3;
    private float fadeTime;
    private float time = 0f;
    private int timeInt = 0;

    // "Awake is used to initialize any variables or game state before the game starts."
    void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        enemies = new List<GameObject>();
        enemies.Clear();

        fadeTime = GameControl.instance.GetComponent<FadingScript>().speed;
    }

    private void Start()
    {
        audioSource = AudioPlayerScript.instance.GetComponent<AudioSource>();
        if (level == 1)
        {
            score = 0;
            lastScore = 0;
        }
        scoreText.text = "Score: " + score.ToString();
        lifePointsText.text = "Lives: " + lifePoints.ToString();
    }

    // Update is called once per frame
    void Update () {
        TimerCount();

        // DEBUG
        //if (enemies.Count > 0)
        //{
        //    if (enemies[0].transform.position.x < 0)
        //    {
        //        Destroy(enemies[0]);
        //        enemies.RemoveAt(0);
        //        GetComponent<AudioSource>().Play();
        //    }
        //}

        if (audioSource.clip != null)
        {
            if (audioSource.time > (audioSource.clip.length - 4f))
            {
                if (!audioSource.isPlaying)
                {
                    NextLevel();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameControl.instance.enemyCanMove = true;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Scored()
    {
        if (gameOver)
        {
            return;
        }
        else
        {
            // RELEASE
            score++;

            // DEBUG
            //score += 1;

        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void NextLevel()
    {
        //if ((score / 20) + 1 > level)
        //{
        //    level++;
        //    //enemies.Clear();
        //    foreach (GameObject enemy in enemies)
        //    {
        //        Destroy(enemy);
        //    }
        //    enemies = new List<GameObject>();

        //}
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies = new List<GameObject>();

        if (PlayerPrefs.GetInt("BestScore") < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        lastScore = score;
        if (level != maxLevel)
        {
            SceneManager.LoadScene("NextLevel");
        }
        else
        {
            SceneManager.LoadScene("FinalScene");
        }
        
        
    }

    public void LostLifePoint()
    {
        lifePoints--;
        lifePointsText.text = "Lives: " + lifePoints.ToString();

        if (lifePoints > 0)
        {
            Destroy(enemies[0]);
            enemies.RemoveAt(0);

            // DEBUG
            //GetComponent<AudioSource>().Play();
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        enemyCanMove = false;
        float fadeTime = GameControl.instance.GetComponent<FadingScript>().BeginFade(1);
        StartCoroutine(WaitAndRestart(fadeTime));        
    }

    public void AddEnemy(GameObject obj)
    {
        enemies.Add(obj);
    }

    public void AddLevel()
    {
        level++;
    }

    public static void RstLevel()
    {
        level = 1;
    }

    public static int GetScore()
    {
        return score;
    }

    public void SetScore(int scr)
    {
        score = scr;
        Debug.Log(score);
        
        scoreText.text = "Score: " + score.ToString();
        Debug.Log(scoreText.text);
    }

    public static void RstScore()
    {
        score = 0;
        lastScore = 0;
    }

    public int LoadLastScore()
    {
        return lastScore;
    }

    public void OnTap(Button button)
    {
        if (button.tag == "Red")
        {
            middleLine.GetComponent<SpriteRenderer>().sprite = middleLineSprites[1];
        }
        else if (button.tag == "Blue")
        {
            middleLine.GetComponent<SpriteRenderer>().sprite = middleLineSprites[2];
        }
        else if (button.tag == "Yellow")
        {
            middleLine.GetComponent<SpriteRenderer>().sprite = middleLineSprites[3];
        }
        else if (button.tag == "Green")
        {
            middleLine.GetComponent<SpriteRenderer>().sprite = middleLineSprites[4];
        }

        if (enemies.Count != 0)
        {
            if (enemies[0].transform.position.x <= 1.1f && enemies[0].transform.position.x >= -1.1f && enemies[0].tag == button.tag)
            {
                Destroy(enemies[0]);
                enemies.RemoveAt(0);
                Scored();
            }
        }

        StartCoroutine(middleLineChangeToWhite());
    }

    private IEnumerator middleLineChangeToWhite()
    {
        yield return new WaitForSeconds(0.1f);
        middleLine.GetComponent<SpriteRenderer>().sprite = middleLineSprites[0];
    }

    // DEBUG
    public void OnMiddleBtnTap(GameObject button)
    {
        Destroy(enemies[0]);
        enemies.RemoveAt(0);
        Scored();

        //GetComponent<AudioSource>().Play();
    }

    private void TimerCount()
    {
        time += Time.deltaTime;
        timeInt = (int)(time * 100);
        time = timeInt / 100f;
        Timer.text = time.ToString();
    }

    private IEnumerator WaitAndRestart(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Restart");
    }
}
