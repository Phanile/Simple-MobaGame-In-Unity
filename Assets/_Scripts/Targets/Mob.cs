﻿using System.Collections;
using UnityEngine;

public class Mob : MonoBehaviour, IMovable, ITarget
{
    public void Attack(ITarget target)
    {
        
    }

    public void Death()
    {
        
    }

    public void Move(Vector3 movePos)
    {
        
    }

    public IEnumerator MoveForAttack(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public void OnAimAtTarget()
    {
        
    }

    public void Rotate(Vector3 vect)
    {
        
    }

    public void Select()
    {
        
    }

    public void StartMoveToTarget(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public void StopMotion()
    {
        
    }

    public void TakeDamage(int damage)
    {
        
    }

    public bool TryToHitTarget(ITarget target)
    {
        return true;
    }
}
