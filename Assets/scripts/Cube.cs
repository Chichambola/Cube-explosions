using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 100;
    private float _decreaseRate = 2f;

    public Color Color { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float SplitChance { get; private set; }

    private void Awake()
    {
        Color = GetComponent<MeshRenderer>().material.color;
        Rigidbody = GetComponent<Rigidbody>();
        SplitChance = _splitChance;
    }

    public void DecreaseChances(float originalCubeSplitChance)
    {
        SplitChance = originalCubeSplitChance;

        SplitChance = SplitChance/ _decreaseRate;
    }
}
