using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private LayerMask _layerToHit;

    private Cube _cube;

    private float _maxDistance = 100000;

    public event Action<Cube> CollisionDetected;

    private void OnEnable()
    {
        _inputHandler.Clicked += IsRayCollided;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= IsRayCollided;
    }

    private void IsRayCollided()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerToHit))
        {
            _cube = hit.collider.gameObject.GetComponent<Cube>();

            CollisionDetected?.Invoke(_cube);
        }
    }
}
