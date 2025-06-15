using UnityEngine;

public class VelocityEasing : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

    Vector2 vel;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float desiredX;
        vel = rb.linearVelocity; //How does Vector2 movement work? How is setting desiredX equal to speed changing the player movement?
                            //what is (vel.x < 0) vel.x = 0; doing? is it just stopping the player once they go below the positive value?

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
        else
        {
            desiredX = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow))   //Why does my character keep floating up?
        {
            vel.y = JumpPower;
        }
        vel.x = Mathf.Lerp(vel.x, desiredX, 0.3f); //What exactly is this doing?
        rb.linearVelocity = vel;
    }
}

