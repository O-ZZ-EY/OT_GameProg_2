using UnityEngine;

public class StateMachinePractice : MonoBehaviour
{
    public SpriteRenderer Sr;
    public Sprite SpriteChange;

    //public WeaponTypes EquippedWeapon = WeaponTypes.Pistol;
    Animator Anim;



    #region Attack Trigger

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("IsAttacking", true);
        }

        else
        {
            Anim.SetBool("IsAttacking", false);
        }

    }
    #endregion

    
}  


