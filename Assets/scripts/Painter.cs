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

    private void ChangeColor(List<GameObject> clonedObject)
    {
        foreach (GameObject obj in clonedObject)
        {
            obj.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
