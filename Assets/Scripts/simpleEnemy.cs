using UnityEngine;

public class simpleEnemy : MonoBehaviour
{
    public int pointValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            PlayerScript.instance.AddScore(pointValue);
            Destroy(this.gameObject);
        }
    }
}
