using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    public float range;
    public float coinInterval;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //invoke repeating calls a function by string name, waits for an X second delay (first number),
       //then repeating every X seconds (the second number)
       InvokeRepeating("SpawnCoin", 0f, coinInterval);
    }

    void SpawnCoin()
    {
       Vector3 position = Random.insideUnitSphere * range;
       position.z = 0f;
       Instantiate(coin, position, Quaternion.identity);
    }
}