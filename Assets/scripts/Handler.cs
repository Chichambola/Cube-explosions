using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private HitDetection _hitDetection;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    
    private void OnEnable()
    {
        _hitDetection.CollisionDetected += WorkWithCube;
    }

    private void OnDisable()
    {
        _hitDetection.CollisionDetected += WorkWithCube;
    }

    private bool CanCubeClone(Cube cube)
    {
        int minPercentage = 0;
        int maxPercentage = 100;

        float number = Random.Range(minPercentage, maxPercentage);

        return number >= minPercentage && number <= cube.SplitChance;
    }

    private void WorkWithCube(Cube cube)
    {
        if (CanCubeClone(cube)) 
        {
            _exploder.CreateExplosion(_spawner.Clone(cube), cube);
        }

        Destroy(cube.gameObject);
    }
}
