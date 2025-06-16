using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public static PlayerScript instance;
    //declare all the variables you'll need for this component to work
    Rigidbody2D myRB;
    public float Speed;
    public float JumpPower;
    Vector2 vel;
    public float score;
    public TMP_Text Score_Text;
    float desiredX;
    float desiredY;




    [Header("Attack Vars")]
    public Collider2D baseSwordSwing;
    public bool attackRequest;
    public bool currentlyAttacking;
    public float attackTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        score = 0f;
        myRB = GetComponent<Rigidbody2D>();
        attackRequest = false;
        currentlyAttacking = false;
        attackTimer = 0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !attackRequest)
        {
            attackRequest = true;
        }

    }

    // run your component runtime logic in Update() and/or FixedUpdate()
    //this is where you call your functions and explain to the component what it should do
    void FixedUpdate()
    {
        #region Movement

        vel = myRB.linearVelocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            desiredX = Speed;
            if (vel.x < 0) vel.x = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            desiredX = -Speed;
            if (vel.x > 0) vel.x = 0;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            desiredY = Speed;
            if (vel.y < 0) vel.y = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            desiredY = -Speed;
            if (vel.y < 0) vel.y = 0;
        }
        else
        {
            desiredX = 0;
            desiredY = 0;
        }
        
        vel.x = Mathf.Lerp(vel.x, desiredX, 0.3f); 
        vel.y = Mathf.Lerp(vel.y, desiredY, 0.3f);  //My character decreases in speed when going up and down. why? can't go side to side and up simultiniously

        myRB.linearVelocity = vel;
        
        #endregion

        #region Attack Mechanic
        if (attackRequest && attackTimer < .1f)
        {
            attackTimer += Time.fixedDeltaTime;
            baseSwordSwing.enabled = true;
        }
        else
        {
            baseSwordSwing.enabled = false;
            attackTimer = 0f;
            attackRequest = false;
        }
        #endregion
    }


    #region Collectible
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
    #endregion


    #region Score
    public void AddScore(int Amount)
    {
        score += Amount;
        Score_Text.text = "Score:" + score.ToString();
    }
    void AddScore()
    {
        score++;
        Score_Text.text = "Score: " + score.ToString();
    }


    public float GetScore()
    {
        return score;
    }
    #endregion
}