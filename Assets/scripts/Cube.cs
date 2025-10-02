using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private void Awake()
    {
        Color = GetComponent<Renderer>().material.color;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public Color Color;
    public Rigidbody Rigidbody;
}
