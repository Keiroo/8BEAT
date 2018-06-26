using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour {

    public static AudioPlayerScript instance;
    public AudioClip[] sources;
    //public int[] BPMs;
    public float waitTime;    

    private int lvl;
    private bool waitEnded = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //BPMs = new int[] { 115, 180 };
    }

    // Use this for initialization
    void Start ()
    {        
        lvl = GameControl.level;
        waitEnded = false;
        StartCoroutine(WaitAndPlay(waitTime));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waitEnded == true)
        {
            if (lvl != GameControl.level)
            {
                lvl = GameControl.level;
                GetComponent<AudioSource>().Stop();
                StartCoroutine(WaitAndPlay(waitTime));
            }
            if (GameControl.instance.gameOver == true)
            {
                GetComponent<AudioSource>().Stop();
            }
        }
    }

    private IEnumerator WaitAndPlay(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().clip = sources[lvl - 1];
        GetComponent<AudioSource>().Play();
        waitEnded = true;
    }
}
