using UnityEngine;
using TMPro;

public class Movementv2 : MonoBehaviour
{

    public static Movementv2 instance;
    //declare all the variables you'll need for this component to work
    Rigidbody2D myRB;
    public float speed;
    Vector3 direction;
    public float score;
    public TMP_Text Score_Text;




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
        myRB.AddForce(Direction() * speed * Time.fixedDeltaTime);

        if (attackRequest && attackTimer < 1f)
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
    }


    #region Direction
    Vector3 Direction()
    {

        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector3(h, v, 0);

        return direction;
    }
    #endregion


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