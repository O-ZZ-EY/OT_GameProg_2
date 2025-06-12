using UnityEngine;

public class StateMachinePractice : MonoBehaviour
{
    public SpriteRenderer Sr;

    //public WeaponTypes EquippedWeapon = WeaponTypes.Pistol;
    Animator Anim;

    #region Attack Trigger

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Anim.SetTrigger("Attack");

        }

    }
    #endregion

    
}  


