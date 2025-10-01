using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private LayerMask _layerToHit;

    private float _maxDistance = 100000;

    public event Action<GameObject> CollisionDetected;

    private void OnEnable()
    {
        _inputHandler.Clicked += CheckForColliders;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= CheckForColliders;
    }

    private void CheckForColliders()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerToHit))
        {
            var hitCube = hit.collider.gameObject;

            CollisionDetected?.Invoke(hitCube);
        }
    }
}
