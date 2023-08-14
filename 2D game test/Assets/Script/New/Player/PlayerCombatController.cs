using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private float stunDamageAmount = 1f;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;
    
    private float lastInputTime = Mathf.NegativeInfinity;
    private AttackDetails attackDetails;

    private playermovement PC;
    private PlayerStats PS;
    

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        PC = GetComponent<playermovement>();
        PS = GetComponent<PlayerStats>();
        
    }

    private void Update()
    {
        CheckCombatInput();
        
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                //Attempt combat
                SoundManagerScript.Playsound("attack");
                lastInputTime = Time.time;
            }
        }
    }



    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
            //Instantiate hit particle
        }
    }

    private void Damage(AttackDetails attackDetails)
    {
        
        int direction;

        PS.DecreaseHealth(attackDetails.damageAmount);
        if(attackDetails.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        PC.Knockback(direction);
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }

}
