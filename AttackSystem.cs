using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private int attackCount = -1;
    private bool canAttack = true;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();


    }
    public int CalculateMeastryLevel(int weaponMaestry) 
    {

        if (weaponMaestry < 30) return 0;
        if (weaponMaestry >=30 && weaponMaestry < 60) return 1;
        if (weaponMaestry >= 60 && weaponMaestry <=100) return 2;

        return 0;
    }

    public void Attack(int weaponMaestry=0)
    {
        if (!canAttack) return;

        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 3);
       
        attackCount++;
        animator.SetTrigger($"Attack{attackCount}");
        
        if(CalculateMeastryLevel(weaponMaestry) == attackCount) attackCount = -1;      

        canAttack = false;
    }

    public void EnableAttack()
    {
        canAttack = true;

    }

    public void ResetAttack()
    {
        canAttack = true;
        attackCount = -1;

    }
}
