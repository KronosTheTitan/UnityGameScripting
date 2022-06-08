using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    [SerializeField] protected float health = 1;
    protected float lastAttack = -10;
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

    public virtual void TakeDamage(float damage,Character source)
    {
        if(source==this) return;
        Debug.Log("OOF");
        health -= damage;
        if(health<=0) Destroy(gameObject);
    }
}
