using UnityEngine;

public class ManagingState : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite Attack2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SR.sprite = Attack2;
            Debug.Log("Space was pressed");
        }
    }
}
