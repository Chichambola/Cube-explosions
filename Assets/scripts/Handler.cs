using System;
using System.Collections;
using System.Collections.Generic;
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

    private void WorkWithCube(Cube cube)
    {
        _exploder.CreateExplosion(_spawner.Clone(cube),cube);
    }
}
