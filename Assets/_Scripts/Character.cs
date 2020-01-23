using UnityEngine;

public class Character : MonoBehaviour, IMovable, ITarget
{
    [Header("Data")]
    [SerializeField] private CharacterData _data;

    public Vector3 MoveVector { get; set; }

    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    [Header("Linqs")]
    public CameraMovement _cameraMovement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move(MoveVector);
        Rotate(MoveVector);
    }

    public void Death()
    {
        
    }

    public void Move(Vector3 movePos)
    {
        if (_cameraMovement.Target == null || _cameraMovement.Target != gameObject)
        {
            return;
        }
        MoveVector = movePos;
        transform.position = Vector3.MoveTowards(transform.position, MoveVector, Time.deltaTime * _data.moveSpeed);
        if (transform.position == MoveVector)
        {
            _animator.SetTrigger("idle");
        }
        else
        {
            _animator.SetTrigger("walk");
        }
    }

    public void Rotate(Vector3 pos)
    {
        if (_cameraMovement.Target == null || _cameraMovement.Target != gameObject)
        {
            return;
        }
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
        _cameraMovement.Target = gameObject;
    }

    public void StopMotion()
    {
        MoveVector = transform.position;  
    }

    public void TakeDamage(int damage)
    {
     
    }
}
