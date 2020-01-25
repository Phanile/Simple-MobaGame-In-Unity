using UnityEngine;

public class SpellOnce : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SpellData _data;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ITarget>() != null)
        {
            collision.gameObject.GetComponent<ITarget>().TakeDamage(_data.damage);
        }
    }
}
