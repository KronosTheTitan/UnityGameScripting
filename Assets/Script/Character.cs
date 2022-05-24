using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    protected float health = 1;
    protected float lastAttack = 0;
    /// <summary>
    /// This method makes a melee attack
    /// </summary>
    public virtual void RangedAttack()
    {
        
    }
    /// <summary>
    /// This method is used to make a melee attack against a target.
    /// </summary>
    public virtual void MeleeAttack()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0) Destroy(gameObject);
    }
}
