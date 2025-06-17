using UnityEngine;

public class VelocityEasing : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    public float CoyoteTime;


    Rigidbody2D rb;
    Animator myAnim;
    SpriteRenderer mySprite;
    Vector3 vel; //current player velocity
    Vector3 inputDir; //current input direction

    public bool grounded;
    public bool canMove;
    public bool airborne;
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
        myAnim.SetBool("Airborne", airborne);

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
        
        Vector3 dir = Direction();
        vel = rb.linearVelocity;

        dir *= Speed;

        if (dir.x > 0)
        {
            if (vel.x < 0) { vel.x = 0; }
        }

        if (dir.x < 0)
        {
            if (vel.x > 0) { vel.x = 0; }
        }


        vel.x = Mathf.Lerp(vel.x, dir.x, .3f);


        if (Input.GetKey(KeyCode.Space) && grounded)
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

    void OnCollisionExit2D(Collision2D collision)
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

    void CoyoteJump()
    {
        if (grounded)
        {
            CoyoteTime = 0;
        }
        else
        {
            CoyoteTime += Time.time;
        }

        if(Input.GetKey(KeyCode.Space) && grounded && CoyoteTime < 0.15f)
        {
            vel.y = JumpPower;
            CoyoteTime = 999;

        }
    }
}

