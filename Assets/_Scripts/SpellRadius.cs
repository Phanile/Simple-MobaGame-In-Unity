using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellRadius : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SpellData _data;

    [Header("Settings")]
    [SerializeField] private float _radius;
    [SerializeField] private List<ITarget> _targetsInRadius;
    public Character character;

    private SphereCollider _collider;

    private void Start()
    {
        _targetsInRadius = new List<ITarget>();
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _radius;
        StartCoroutine(Destroy());
        StartCoroutine(GiveDamageToAll(_data.damage, _data.timeToGiveDamage));
    }

    private void Update()
    {
        transform.position = character.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ITarget>() != null)
        {
            if (collision.gameObject.GetComponent<ITarget>().transform.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<ITarget>().transform.gameObject.GetComponent<Mob>().GetData().moveSpeed -= _data.speedDecrease;
                _targetsInRadius.Add(collision.gameObject.GetComponent<ITarget>());
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<ITarget>() != null)
        {
            if (collision.gameObject.GetComponent<ITarget>().transform.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<ITarget>().transform.gameObject.GetComponent<Mob>().GetData().moveSpeed += _data.speedDecrease;
                _targetsInRadius.Remove(collision.gameObject.GetComponent<ITarget>());
            }
        }
    }

    private IEnumerator GiveDamage(int damageAmount, ITarget target)
    {
        target.TakeDamage(damageAmount);
        yield break;
    }

    private IEnumerator GiveDamageToAll(int damageAmount, float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            for (int i = 0; i < _targetsInRadius.Count; i++)
            {
                StartCoroutine(GiveDamage(damageAmount, _targetsInRadius[i]));
            }
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_data.timeToDestroy);
        for (int i = 0; i < _targetsInRadius.Count; i++)
        {
            _targetsInRadius[i].transform.gameObject.GetComponent<Mob>().GetData().moveSpeed += _data.speedDecrease;
            _targetsInRadius.Remove(_targetsInRadius[i]);
        }
        Destroy(gameObject);
    }
}
