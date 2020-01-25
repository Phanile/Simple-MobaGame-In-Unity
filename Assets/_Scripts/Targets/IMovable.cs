using UnityEngine;
using System.Collections;

public interface IMovable 
{
    void Move(Vector3 movePos);
    void Rotate(Vector3 vect);
    IEnumerator MoveForAttack(ITarget target);
    IEnumerator MoveForUseSpell(ITarget target, SpellData data);
    void StartMoveToTarget(ITarget target);
    void StartMoveToUseSpeellOnTarget(ITarget target, SpellData data);
    void StopMotion();
}
