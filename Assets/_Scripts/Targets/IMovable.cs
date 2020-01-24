using UnityEngine;
using System.Collections;

public interface IMovable 
{
    void Move(Vector3 movePos);
    void Rotate(Vector3 vect);
    IEnumerator MoveForAttack(ITarget target);
    void StartMoveToTarget(ITarget target);
    void StopMotion();
}
