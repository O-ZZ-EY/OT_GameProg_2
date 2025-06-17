using UnityEngine;
using System;
using System.Collections;

public class EnemyFOV : MonoBehaviour
{
    public simpleEnemy myEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myEnemy = gameObject.GetComponentInParent<simpleEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myEnemy.playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ForgetPlayer(1f));
        }
    }

    public IEnumerator ForgetPlayer( float time)
    {

        //code up here executes the second you call this function
        yield return new WaitForSeconds(time); //pausing the function for X seconds
        //code under this line will execute after the function has waited for X seconds
        myEnemy.playerDetected = false;
    }
}
