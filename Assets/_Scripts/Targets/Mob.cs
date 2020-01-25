using System.Collections;
using UnityEngine;

public class Mob : MonoBehaviour, IMovable, ITarget
{
    public TargetContainer targetContainer;

    public void Attack(ITarget target)
    {
        
    }

    public void Death()
    {
        
    }

    public void DeSelect()
    {
        
    }

    public void Move(Vector3 movePos)
    {
        
    }

    public IEnumerator MoveForAttack(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator MoveForTo(Vector3 pos, SpellData data)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator MoveForUseSpell(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator MoveForUseSpell(ITarget target, SpellData data)
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
        targetContainer.Target = gameObject;
    }

    public void StartMoveToTarget(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public void StartMoveToUseSpeellOnTarget(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public void StartMoveToUseSpeellOnTarget(ITarget target, SpellData data)
    {
        throw new System.NotImplementedException();
    }

    public void StartMoveToUseSpeellTo(Vector3 pos, SpellData data)
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
