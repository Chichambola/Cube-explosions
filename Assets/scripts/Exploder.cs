using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void CreateExplosion(List<Cube> clones, Cube originalCube)
    {
        Collider[] hits = Physics.OverlapSphere(originalCube.transform.position, _explosionRadius);

        for (int i = 0; i < clones.Count; i++)
        {
            clones[i].Rigidbody.AddExplosionForce(_explosionForce, originalCube.transform.position, _explosionRadius);
        }
    }
}