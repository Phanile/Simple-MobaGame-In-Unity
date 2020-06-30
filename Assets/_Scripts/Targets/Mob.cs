using System.Collections;
using UnityEngine;

public class Mob : MonoBehaviour, IMovable, ITarget
{
    [Header("Data")]
    [SerializeField] private CreepData _data;

    public TargetContainer targetContainer;

    private void Start()
    {
        _data.health = _data.maxHealth;
    }

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
    public CreepData GetData()
    {
        return _data;
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
        if (_data.health > 0)
        {
            _data.health -= damage;
            if (_data.health <= 0)
            {

            }
        }
    }

    public bool TryToHitTarget(ITarget target)
    {
        return true;
    }
}
