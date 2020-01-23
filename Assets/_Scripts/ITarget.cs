using UnityEngine;

public interface ITarget
{
    void Select();
    void TakeDamage(int damage);
    void Death();
    void OnAimAtTarget();
    Transform transform { get; }
}
