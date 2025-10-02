using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public Color ChangeColor()
    {
        return Random.ColorHSV();
    }
}
