using UnityEngine;

public class Boss1movement : MonoBehaviour
{
    //declare all the variables you'll need for this component to work
    Rigidbody2D myRB;
    public float speed;
    Vector3 direction;

    float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0f;
        myRB = GetComponent<Rigidbody2D>();
    }

    // run your component runtime logic in Update() and/or FixedUpdate()
    //this is where you call your functions and explain to the component what it should do
    void FixedUpdate()
    {
        myRB.AddForce(Direction() * speed * Time.fixedDeltaTime);  
    }

    //put your logic into discrete functions that do specific tasks
    Vector3 Direction()
    {

        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector3(h, v, 0);

        return direction;
    }



    //collision code describes logic or computations that run when specific triggers or events happen
    void OnTriggerEnter2D(Collider2D collision)         
    {
        if (collision.gameObject.tag == "Collectible")
        {
            AddScore();
            Destroy(collision.gameObject);
            Debug.Log("Player collider");
        }
    }

    void AddScore()
    {
        score++;     //What is ++ and what is it doing? is there something similar with -- or **
    }
}