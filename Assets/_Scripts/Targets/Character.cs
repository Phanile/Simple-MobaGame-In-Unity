using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour, IMovable, ITarget, ISpellUser
{
    [Header("Data")]
    [SerializeField] private CharacterData _data;

    [Header("Vectors")]
    [HideInInspector] public Vector3 moveVector;

    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    [Header("Linqs")]
    public TargetContainer targetContainer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("idle", true);
    }

    private void FixedUpdate()
    {
        Move(moveVector);
    }

    public void Death()
    {
        
    }

    public void Move(Vector3 movePos)
    {
        if (targetContainer.Target == null) 
        {
            return;
        }
        moveVector.Set(movePos.x, transform.position.y, movePos.z);
        transform.position = Vector3.MoveTowards(transform.position, moveVector, Time.deltaTime * _data.moveSpeed);
        Rotate(moveVector);
        if (transform.position == moveVector)
        {
            _animator.SetBool("idle", true);
        }
        else
        {
            _animator.SetBool("idle", false);
            _animator.speed = _data.moveSpeed / 3;
        }
    }

    public void Rotate(Vector3 pos)
    {
        pos.Set(pos.x, transform.position.y, pos.z);
        Vector3 lookPos = pos - transform.position;
        if (lookPos == Vector3.zero)
        {
            return;
        }
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _data.rotateSpeed);
    }

    public Quaternion GetRotateBeforeAttack(ITarget target)
    {
        Vector3 lookPos = target.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        return rotation;
    }

    public void OnAimAtTarget()
    {
        
    }

    public void Select()
    {
        targetContainer.Target = gameObject;
    }

    public void StopMotion()
    {
        moveVector = transform.position;  
    }

    public void TakeDamage(int damage)
    {
     
    }

    public CharacterData GetData()
    {
        return _data;
    }

    public bool TryToHitTarget(ITarget target)
    {
        if (Physics.OverlapSphere(transform.position, _data.attackRadius).Length > 0)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _data.attackRadius);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].transform.GetComponent<ITarget>() != null)
                {
                    if (cols[i].transform.GetComponent<ITarget>() == target)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool TryToUseSpellOnTarget(ITarget target, SpellData data)
    {
        if (Physics.OverlapSphere(transform.position, data.range).Length > 0)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, data.range);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].transform.GetComponent<ITarget>() != null)
                {
                    if (cols[i].transform.GetComponent<ITarget>() == target)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _data.attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }

    public void Attack(ITarget target)
    {
        StopMotion();
        transform.rotation = GetRotateBeforeAttack(target);
        _animator.SetTrigger("attack");
    }

    public IEnumerator MoveForAttack(ITarget target)
    {
        moveVector = target.transform.position;
        while (!TryToHitTarget(target))
        {
            yield return new WaitForEndOfFrame();
            if (TryToHitTarget(target))
            {
                Attack(target);
                yield break;
            }
        }
    }

    public void StartMoveToTarget(ITarget target)
    {
        StartCoroutine(MoveForAttack(target));
    }

    public IEnumerator MoveForUseSpell(ITarget target, SpellData data)
    {
        moveVector = target.transform.position;
        while (!TryToUseSpellOnTarget(target, data))
        {
            yield return new WaitForEndOfFrame();
            if (TryToUseSpellOnTarget(target, data))
            {
                UseSpellOn(target, data);
                yield break;
            }
        }
    }

    public void StartMoveToUseSpeellOnTarget(ITarget target, SpellData data)
    {
        StartCoroutine(MoveForUseSpell(target, data));
    }

    public void UseSpellOn(ITarget target, SpellData data)
    {
        StopMotion();
        transform.rotation = GetRotateBeforeAttack(target);
        data.SpellUse(target);
    }

    public void UseSpellTo(Vector3 pos)
    {
        
    }
}
