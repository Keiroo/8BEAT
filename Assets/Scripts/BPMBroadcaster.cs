using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMBroadcaster : MonoBehaviour {

    public static BPMBroadcaster instance;
    private int BPM;

    private int[] BPMs;
    private int lvl;

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
        BPMs = new int[] { 115, 150 };
        BPM = BPMs[0];
    }

    // Use this for initialization
    void Start () {
        lvl = GameControl.level;
        BPM = BPMs[lvl - 1];
	}
	
	// Update is called once per frame
	void Update () {
		if (lvl != GameControl.level)
        {
            lvl = GameControl.level;
            BPM = BPMs[lvl - 1];
        }
	}

    public int getBPM()
    {
        return BPM;
    }
}
