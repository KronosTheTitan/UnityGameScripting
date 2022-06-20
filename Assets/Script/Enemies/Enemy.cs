using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected Character targetCharacter;

    [SerializeField] protected State state;
    [SerializeField] protected float painChance;
    
    private float lastAITick = 0;
    
    protected enum State
    {
        ATT_RANGE,
        ATT_MELEE,
        SPAWN,
        SEE,
        PAIN,
        DEATH,
    }

    private void Update()
    {
        if(Time.time < lastAITick + .25) return;
        lastAITick = Time.time;

        switch (state)
        {
            case State.ATT_RANGE:
                if (!ATT_RangeSwap())
                {
                    ATT_RangeAction();
                }
                break;
            case State.ATT_MELEE:
                if (!ATT_MELEESwap())
                {
                    ATT_MELEEAction();
                }
                break;
            case State.SEE:
                if (!SEESwap())
                {
                    SEEAction();
                }
                break;
            case State.PAIN:
                if (!ATT_MELEESwap())
                {
                    ATT_MELEEAction();
                }
                break;
            case State.SPAWN:
                if (!SEESwap())
                {
                    SEEAction();
                }
                break;
            default:
                break;
        }
    }

    protected virtual void ATT_RangeAction()
    {
        
    }

    protected virtual bool ATT_RangeSwap()
    {
        return false;
    }

    protected virtual void ATT_MELEEAction()
    {
        
    }

    protected virtual bool ATT_MELEESwap()
    {
        return false;
    }

    protected virtual void SEEAction()
    {
        
    }

    protected virtual bool SEESwap()
    {
        Vector2 toVector = targetCharacter.transform.position - transform.position;
        float angleToTarget = Vector2.Angle(transform.forward, toVector);
        if (angleToTarget < 90 && angleToTarget > -90)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, targetCharacter.transform.position - transform.position,out hit);
            //if (hit == null) return false;
        }
        return false;
    }

    protected virtual void PAINAction()
    {
        
    }

    protected virtual bool PAINSwap()
    {
        return false;
    }
}
