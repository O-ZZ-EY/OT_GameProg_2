using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public float enemySpawnRange = 10f;
    public GameObject[] enemies;
    public List<GameObject> enemiesList;
    public GameObject zombie;
    public GameObject FireW;

    [Header("Timer Vars")]
    public TMP_Text Timer_Text;
    public float CurrentTimer;
    public float TimerInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentTimer = TimerInterval;
        instance = this;
        //player = Movementv2.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //int index = Random.Range(0, enemies.Length - 1);
        //SpawnEnemy(enemies[index]);

        CurrentTimer -= Time.deltaTime;
        Timer_Text.text = "Timer: " + CurrentTimer.ToString();

        if (CurrentTimer <= 0f)
        {

            CurrentTimer = 0f;
            EndGame();

        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Vector3 position;

        position = Random.insideUnitSphere * enemySpawnRange;
        position.z = 0f;

        enemiesList.Add(Instantiate(prefab, position, Quaternion.identity));
    }

    void EndGame()
    {
        foreach(GameObject e in enemiesList)
        {
            Destroy(e);
            //e.SetActive(false);
        }
        Destroy(player);

    }
}
