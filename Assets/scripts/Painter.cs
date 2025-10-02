using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ClonesCreated += ChangeColor;
    }

    private void OnDisable()
    {
        _spawner.ClonesCreated -= ChangeColor;
    }

    private void ChangeColor(List<Cube> clonedObjects)
    {
        for (int i = 0; i < clonedObjects.Count; i++)
        {
            clonedObjects[i].Color = Random.ColorHSV();
        }
    }
}
