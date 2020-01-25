using UnityEngine;

public class MoveParticleSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject _pref;

    [Header("Settings")]
    public GameObject currentParticle;
    [SerializeField] private bool _canSpawn;

    [Header("Linqs")]
    [SerializeField] private TargetContainer _targetContainer;

    private Vector3 plusVect = new Vector3(0, 0.25f, 0);

    private bool CanSpawn => currentParticle != null;

    public void SpawnParticle(Vector3 pos)
    {
        if (!_canSpawn || !_targetContainer.Target.CompareTag("Player"))
        {
            return;
        }
        if (CanSpawn)
        {
            currentParticle.transform.position = pos + plusVect;
            currentParticle.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            currentParticle = Instantiate(_pref, pos + plusVect, Quaternion.identity);
        }
    }
}
