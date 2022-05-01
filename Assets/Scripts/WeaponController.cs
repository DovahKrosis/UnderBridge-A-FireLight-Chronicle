using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public PlayerMovimentation PlayerMovimentation;
    public GameObject Sword;//add more here
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound01;
    public AudioClip SwordSheatheSound;
    public bool IsAttacking = false;
    public bool Sheathe = false;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Sheathe)
        {
            if (CanAttack)
            {
                swordAtack();
            }
        }

        SwordSheathe();

    }

    public void SwordSheathe()
        {
        if (Input.GetKeyDown(KeyCode.F) && Sheathe == false)
        {
            CanAttack = true;
            Sheathe = true;

            Animator anim = Sword.GetComponent<Animator>();
            anim.SetTrigger("sheathe");

            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(SwordSheatheSound);
        }
        else if (Input.GetKeyDown(KeyCode.F) && Sheathe == true)
        {
           CanAttack = false;
           Sheathe = false;

           AudioSource ac = GetComponent<AudioSource>();
           ac.PlayOneShot(SwordSheatheSound);

            Animator anim = Sword.GetComponent<Animator>();
            anim.SetTrigger("sheathe");
        }
    }
        public void swordAtack()
        {
            
            IsAttacking = true;
            PlayerMovimentation.staminaCurrent -= 20;
            CanAttack = false;
            Animator anim = Sword.GetComponent<Animator>();
            anim.SetTrigger("Attack");
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(SwordAttackSound01);
            StartCoroutine(ResetAttackCooldown());
        }

        IEnumerator ResetAttackCooldown()
        {
        StartCoroutine(ResetAttackBool());      
            yield return new WaitForSeconds(AttackCooldown);
            CanAttack = true;
        }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
    

}
