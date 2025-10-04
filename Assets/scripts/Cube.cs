using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    
    
    private float _splitChance = 100;
    private float _decreaseRate = 2f;
    private int _multiplier = 5;

    public Color Color { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float SplitChance { get; private set; }
    public float ExplosionForce { get; private set; }
    public float ExplosionRadius { get; private set; }

    private void Awake()
    {
        Color = GetComponent<MeshRenderer>().material.color;
        Rigidbody = GetComponent<Rigidbody>();
        ExplosionForce = _explosionForce;
        ExplosionRadius = _explosionRadius;
        SplitChance = _splitChance;
    }

    public void DecreaseChances(float originalCubeSplitChance)
    {
        SplitChance = originalCubeSplitChance;

        SplitChance = SplitChance/ _decreaseRate;
    }

    public void IncreaseExplosionForce(float originalCubeForce)
    {
        _explosionForce = originalCubeForce;

        _explosionForce *= _multiplier;
    }
    
    public void IncreaseExplosionRadius(float originalCubeRadius)
    {
        _explosionRadius = originalCubeRadius;

        _explosionRadius *= _multiplier;
    }
}
