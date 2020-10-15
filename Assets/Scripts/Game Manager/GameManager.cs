using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text titleText;
    public Text m_MessageText;

    public Button m_NewGameButton;

    public GameObject enemy;
    public GameObject player;

    public GameObject[] m_Characters;
    public Transform[] spawnPoints;

    private bool gameEnd = false;

    public int waveNumber = 1;
    private int enemySpawnAmount = 0;
    private int enemiesKilled = 0;

    private float m_GameTime = 0f;
    public float GameTime { get { return m_GameTime; } }

    public GameObject[] spawners;

    private void Awake()
    {
        
    }
    private void Start()
    {
        enemy.SetActive(false);
        player.SetActive(false);

        titleText.text = "Zombie Chaos";
        m_MessageText.text = "";
        m_NewGameButton.gameObject.SetActive(true);

        spawners = new GameObject[5];

        for (int i = 0; i <spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SpawnEnemy()
    {
        for (int i =0; i < 5; i++)
        {
            Instantiate(enemy, spawners[i].transform.position, spawners[i].transform.rotation);
        }
        
    }

    public void StartWave()
    {
        player.SetActive(true);
        enemy.SetActive(true);

        m_MessageText.text = "";
        titleText.text = "";
        m_NewGameButton.gameObject.SetActive(false);

        waveNumber = 1;
        enemySpawnAmount = 5;
        enemiesKilled = 0;


        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    private void NextWave()
    {
        if(waveNumber == 3)
        {
            GameEnd();
        }
        else
        {
            waveNumber++;
            enemySpawnAmount = 5;
            enemiesKilled = 0;

            for (int i = 0; i < enemySpawnAmount; i++)
            {
                SpawnEnemy();
            }
        }
    }

    public void EnemyDie()
    {
        enemiesKilled++;

        if (enemiesKilled == enemySpawnAmount)
        {
            NextWave();
        }
    }

    public void GameEnd()
    {
       if(player.activeSelf == false)
        {
            m_MessageText.text = "You are dead. Try again next time.";
        }
        else
        {
            m_MessageText.text = "Congratulations, you survived!";
        }
    }
}
