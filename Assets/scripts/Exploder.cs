using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void CreateExplosion(Cube cube)
    {
        Vector3 cubePosition = cube.transform.position;
        
        Collider[] hits = Physics.OverlapSphere(cubePosition, cube.ExplosionRadius);
        
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                float distance = Vector3.Distance(cubePosition, hit.transform.position);
                
                if (distance > 0)
                {
                    float force = cube.ExplosionForce / distance;
                    
                    rigidbody.AddExplosionForce(force, cubePosition, cube.ExplosionRadius);
                }
            }
        }
    }

    public void CreateExplosion(List<Cube> clones, Cube originalCube)
    {
        Collider[] hits = Physics.OverlapSphere(originalCube.transform.position, originalCube.ExplosionRadius);

        foreach (Collider hit in hits)
        {
            foreach (Cube cube in clones)
            {
                cube.Rigidbody.AddExplosionForce(originalCube.ExplosionForce, originalCube.transform.position,
                    originalCube.ExplosionRadius);
            }
        }
    }
}