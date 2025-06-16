using UnityEngine;

public class VelocityEasing : MonoBehaviour
{
    public float Speed;
    public float JumpPower;


    Rigidbody2D rb;
    Animator myAnim;
    SpriteRenderer mySprite;
    Vector3 vel; //current player velocity
    Vector3 inputDir; //current input direction

    public bool grounded;
    public bool canMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum PlayerState
    {
        GROUNDED = 0,
        AIRBORNE = 1,
        JUMPING = 2,
        TAKEHIT = 3,
        DEAD = 4,
        ATTACKING = 5,
        IDLE = 6
    }

    public PlayerState myState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        canMove = true;
        myState = PlayerState.IDLE;
    }


    private void Update()
    {
        myAnim.SetBool("Grounded", grounded);
        myAnim.SetFloat("Speed", Mathf.Abs(vel.magnitude));

        if (rb.linearVelocity.x < 0)
        {
            mySprite.flipX = true;
        }
        else { mySprite.flipX = false; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(myState)
        {
            case PlayerState.GROUNDED:
                canMove = true;
                break;
            case PlayerState.TAKEHIT:
                canMove = false;
                break;
        }

        if(canMove)
        {
            ApplyVelocityEasing();
        }
    }

    void ApplyVelocityEasing()
    {
        //find our input axes direction
        Vector3 dir = Direction();
        //storing current velocity
        vel = rb.linearVelocity;

        //dir = (-1,-1,0) to (1,1,0)
        //speed = an arbitrary float from 0 to infinity
        //let's say speed = 3
        //when you multiply a vector by a float, it applies the multiplication to each of the individual vector components
        // dir * speed = (-3,-3,0) to (3,3,0)
        dir *= Speed;

        //before applying the LERP, let's check to see if the player
        //is changing directions from Left>Right or Right>Left
        if (dir.x > 0) //if Dir > 0 and vel < 0, the player is requesting Right but the myRB is moving Left
        {
            if (vel.x < 0) { vel.x = 0; } //instead of LERP from -Speed to Speed, this halves the distance so we only need to LERP from 0 to Speed
        }
        if (dir.x < 0)
        {
            if (vel.x > 0) { vel.x = 0; } //instead of LERP from Speed to -Speed, this halves the distance so we only need to LERP from 0 to -Speed
        }

        //LERP stands for linear interpolation
        //      A (0%) -------------float time (percentage) ----------------------------- (100%)B 
        //LERP takes two values and finds the value that is TIME% between the two
        //in other words, if t = .40f == 40% , then find a value that is 40% from A TOWARDS B
        vel.x = Mathf.Lerp(vel.x, dir.x, .3f);


        if (Input.GetKey(KeyCode.Space) && grounded)   //Why does my character keep floating up?
        {
            vel.y = JumpPower;
            Debug.Log("jumping");
        }



        rb.linearVelocity = vel;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
    Vector3 Direction()
    {
        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0);

        return inputDir;
    }
}

