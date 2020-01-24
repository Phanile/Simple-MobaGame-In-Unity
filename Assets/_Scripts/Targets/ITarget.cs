using UnityEngine;

public interface ITarget
{
    void Select();
    void DeSelect();
    void TakeDamage(int damage);
    void Death();
    void OnAimAtTarget();
    bool TryToHitTarget(ITarget target);
    void Attack(ITarget target);
    Transform transform { get; }
}
