using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

    private float xspeed = 5f;
    private float yspeed = 0.03f;
    private float zspeed = 1f;
    private float speed, speed2;
    private int BPM = 0;
    //private float sin;
    private bool direction; // true = up, false = down

    // Use this for initialization
    void Start () {
        BPM = BPMBroadcaster.instance.getBPM();
        direction = true;
        zspeed = Random.Range(-2f, 2f);
        speed = xspeed * (BPM / 120f);
        speed2 = yspeed * (BPM / 120f);
        //DEBUG
        Debug.Log(BPM);
        Debug.Log(speed);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControl.instance.enemyCanMove == true)
        {
            //speed = 2.5f * (lvl + 1);

            // Xaxis
            //transform.Translate(Vector3.left * xspeed * Time.deltaTime);
            transform.position += Vector3.left * speed * Time.deltaTime;


            // Yaxis
            if (direction)
            {
                if (transform.position.y < 1.5f)
                {
                    //transform.Translate(Vector3.up * yspeed);
                    transform.position += Vector3.up * speed2;
                }
                else
                {
                    direction = false;
                    //transform.Translate(Vector3.down * yspeed);
                    transform.position += Vector3.down * speed2;
                }
            }
            else
            {
                if (transform.position.y > 0.5f)
                {
                    //transform.Translate(Vector3.down * yspeed);
                    transform.position += Vector3.down * speed2;
                }
                else
                {
                    direction = true;
                    //transform.Translate(Vector3.up * yspeed);
                    transform.position += Vector3.up * speed2;
                }
            }


            // Zaxis
            //transform.Rotate(0f, 0f, zspeed, Space.Self);
            transform.RotateAround(GetComponent<Collider2D>().bounds.center, Vector3.forward, zspeed);
        }
    }
}
