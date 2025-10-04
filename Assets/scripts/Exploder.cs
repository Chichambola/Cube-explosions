using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void CreateExplosion(Cube cube)
    {
        Vector3 cubePosition = cube.transform.position;

        float cubeExplosionRadius = cube.ExplosionRadius;
        
        Collider[] hits = Physics.OverlapSphere(cubePosition, cubeExplosionRadius);
        
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Cube cubeComponent))
            {
                float distance = Vector3.Distance(cubePosition, hit.transform.position);

                float force = cube.ExplosionForce / distance;

                cubeComponent.Rigidbody.AddExplosionForce(force, cubePosition, cube.ExplosionRadius);
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