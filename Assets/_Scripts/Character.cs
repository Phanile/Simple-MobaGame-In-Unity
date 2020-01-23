using UnityEngine;

public class Character : MonoBehaviour, IMovable, ITarget
{
    [Header("Data")]
    [SerializeField] private CharacterData _data;

    public Vector3 MoveVector;

    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    [Header("Linqs")]
    public TargetContainer targetContainer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move(MoveVector);
    }

    public void Death()
    {
        
    }

    public void Move(Vector3 movePos)
    {
        if (targetContainer.Target == null || targetContainer.Target != gameObject) 
        {
            return;
        }
        MoveVector.Set(movePos.x, transform.position.y, movePos.z);
        transform.position = Vector3.MoveTowards(transform.position, MoveVector, Time.deltaTime * _data.moveSpeed);
        if (transform.position == MoveVector)
        {
            _animator.SetBool("idle", true);
        }
        else
        {
            _animator.SetBool("idle", false);
            _animator.speed = _data.moveSpeed / 3;
            Rotate(MoveVector);
        }
    }

    public void Rotate(Vector3 pos)
    { 
        Vector3 lookPos = pos- transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _data.rotateSpeed);
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
        MoveVector = transform.position;  
    }

    public void TakeDamage(int damage)
    {
     
    }
}
