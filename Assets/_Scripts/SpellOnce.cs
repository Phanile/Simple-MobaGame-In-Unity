using System.Collections;
using UnityEngine;

public class SpellOnce : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SpellData _data;

    [Header("Settings")]
    [SerializeField] private bool _haveTime;
    [SerializeField] private float _time;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ITarget>() != null)
        {
            if (collision.gameObject.GetComponent<ITarget>().transform.gameObject.CompareTag("Enemy"))
            {
                if (_haveTime)
                {
                    StartCoroutine(MakeDamage(collision.gameObject.GetComponent<ITarget>(), _time));
                }
                else
                {
                    collision.gameObject.GetComponent<ITarget>().TakeDamage(_data.damage);
                }
            }
        }
    }

    private IEnumerator MakeDamage(ITarget target, float time)
    {
        yield return new WaitForSeconds(time);
        target.TakeDamage(_data.damage);
    } 
}
