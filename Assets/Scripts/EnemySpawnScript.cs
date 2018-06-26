using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

    public GameObject[] enemies;
    public Transform spawnPoint;

    private AudioSource audioSource;
    private float spawnTime;
    private int lvl;
    private int BPM;
    private int patternNr;

    
    // Version 3
    void Start()
    {
        audioSource = AudioPlayerScript.instance.GetComponent<AudioSource>();
        lvl = GameControl.level;
        //BPM = AudioPlayerScript.instance.BPMs[lvl - 1];
        BPM = BPMBroadcaster.instance.getBPM();
        spawnTime = 1f / (BPM / 120f);
        //InvokeRepeating("Spawn", (spawnTime * 2f), (spawnTime * 4f));
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (lvl < GameControl.level)
        {
            RefreshVariables();
        }
    }

    IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(spawnTime * 2f);

        //while (AudioPlayerScript.instance.GetComponent<AudioSource>().isPlaying)
        while ((audioSource.clip.length - audioSource.time) > (spawnTime * 4f))
        {
            patternNr = Random.Range(1, 11);

            switch (patternNr)
            {
                // Normal (All Full)
                case 1:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        break;
                    }

                // OneEmpty 1
                case 2:
                    {
                        yield return new WaitForSeconds(spawnTime * 2f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        break;
                    }

                // OneEmpty 2
                case 3:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 2f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        break;
                    }

                // OneEmpty 3
                case 4:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 2f);
                        SpawnOneEnemy();
                        break;
                    }
                
                // OneEmpty 4
                case 5:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        break;
                    }

                // OneFaster 1
                case 6:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 0.5f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 1.5f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        break;
                    }

                // OneFaster 2
                case 7:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 0.5f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 1.5f);
                        SpawnOneEnemy();
                        break;
                    }
                
                // OneFaster 3
                case 8:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 0.5f);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime * 0.5f);
                        break;
                    }

                //// TwoEmpty 1
                //case 9:
                //    {
                //        yield return new WaitForSeconds(spawnTime);
                //        SpawnOneEnemy();
                //        yield return new WaitForSeconds(spawnTime * 2f);
                //        SpawnOneEnemy();
                //        yield return new WaitForSeconds(spawnTime);
                //        break;
                //    }

                //// TwoEmpty 2
                //case 10:
                //    {
                //        yield return new WaitForSeconds(spawnTime * 2f);
                //        SpawnOneEnemy();
                //        yield return new WaitForSeconds(spawnTime * 2f);
                //        SpawnOneEnemy();
                //        break;
                //    }

                default:
                    {
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        yield return new WaitForSeconds(spawnTime);
                        SpawnOneEnemy();
                        break;
                    }
            }
        }
    }

    void RefreshVariables()
    {
        audioSource = AudioPlayerScript.instance.GetComponent<AudioSource>();
        lvl = GameControl.level;
        //BPM = AudioPlayerScript.instance.BPMs[lvl - 1];
        BPM = BPMBroadcaster.instance.getBPM();
        spawnTime = 1f / (BPM / 120f);
    }

    void SpawnOneEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoint.position, spawnPoint.rotation);
        enemy.AddComponent<EnemyMoveScript>();
        GameControl.instance.AddEnemy(enemy);
    }


    // Version 1
    //private void Start ()
    //   {
    //       lvl = GameControl.instance.level;
    //       InvokeRepeating("Spawn", spawnTime, spawnTime);
    //}

    //   private void Update()
    //   {
    //       if (lvl < GameControl.instance.level)
    //       {
    //           CancelInvoke();
    //           lvl = GameControl.instance.level;
    //           spawnTime = spawnTime / 0.5f;
    //           InvokeRepeating("Spawn", spawnTime, spawnTime);
    //       }
    //   }

    //   void Spawn ()
    //   {
    //       int enemyIndex = Random.Range(0, enemies.Length);
    //       GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoint.position, spawnPoint.rotation);
    //       enemy.AddComponent<EnemyMoveScript>();
    //       GameControl.instance.AddEnemy(enemy);
    //   }


    // Version 2
    //private void Start()
    //{
    //    lvl = GameControl.instance.level;
    //}

    //private void Update()
    //{
    //    if (lvl < GameControl.instance.level)
    //    {
    //        lvl = GameControl.instance.level;
    //        spawnTime = spawnTime * 0.75f;
    //    }
    //    if (!isSpawning)
    //    {
    //        isSpawning = true;
    //        int enemyIndex = Random.Range(0, enemies.Length);
    //        StartCoroutine(Spawn(enemyIndex, spawnTime));
    //    }
    //}

    //IEnumerator Spawn(int index, float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    GameObject enemy = Instantiate(enemies[index], spawnPoint.position, spawnPoint.rotation);
    //    enemy.AddComponent<EnemyMoveScript>();
    //    GameControl.instance.AddEnemy(enemy);
    //    isSpawning = false;
    //}

    //// Version 3
    //void Start()
    //{
    //    lvl = GameControl.instance.level;
    //    BPM = AudioPlayerScript.instance.BPMs[lvl - 1];
    //    spawnTime = 1f / (BPM / 120f);
    //    timePassed = 0f;
    //    //fadeTime = GameControl.instance.GetComponent<FadingScript>().speed;
    //    fadeTime = 0f;
    //    InvokeRepeating("Spawn", (spawnTime * 2f), spawnTime);
    //}

    //void Update()
    //{
    //    //timePassed += Time.deltaTime;
    //    if (lvl < GameControl.instance.level)
    //    {
    //        RefreshVariables();
    //    }

    //    //if (timePassed >= spawnTime)
    //    //{
    //    //    timePassed = 0f;
    //    //    Spawn();
    //    //}
    //}

    //void Spawn()
    //{
    //    int enemyIndex = Random.Range(0, enemies.Length);
    //    GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoint.position, spawnPoint.rotation);
    //    enemy.AddComponent<EnemyMoveScript>();
    //    GameControl.instance.AddEnemy(enemy);
    //}

    //void RefreshVariables()
    //{
    //    lvl = GameControl.instance.level;
    //    BPM = AudioPlayerScript.instance.BPMs[lvl - 1];
    //    spawnTime = 1f / (BPM / 120f);
    //}

}
