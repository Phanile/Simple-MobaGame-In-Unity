using UnityEngine;

public interface IMovable 
{
    void Move(Vector3 movePos);
    void Rotate(Vector3 vect);
    void StopMotion();
}
