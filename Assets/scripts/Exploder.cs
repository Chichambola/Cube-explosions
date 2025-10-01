using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        _spawner.ClonesCreated += CreateExplosion;
    }

    private void OnDisable()
    {
        _spawner.ClonesCreated -= CreateExplosion;
    }

    private void CreateExplosion(List<GameObject> clones)
    {
        int firstIndex = 0;

        Collider[] hits = Physics.OverlapSphere(clones[firstIndex].transform.position, _explosionRadius);

        for (int i = 0; i < clones.Count; i++) 
        {
            if (clones[i].TryGetComponent<Rigidbody>(out Rigidbody cloneObject))
            {
                cloneObject.AddExplosionForce(_explosionForce, clones[firstIndex].transform.position, _explosionRadius);
            }
        }
    }
}
