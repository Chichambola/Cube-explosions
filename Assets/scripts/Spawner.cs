using System.Collections;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private HitDetection _hitDetector;

    private int _attempt = 1;
    private float _successPercentage = 100;
    private int _minCloneCubeAmount = 2;
    private int _maxCloneCubeAmount = 6;

    public event Action<List<GameObject>> ClonesCreated;

    private void OnEnable()
    {
        _hitDetector.CollisionDetected += Clone;
    }

    private void OnDisable()
    {
        _hitDetector.CollisionDetected -= Clone;
    }

    private void Clone(GameObject originalObject)
    {
        List<GameObject> clones = new List<GameObject>();

        int divider = 2;

        int amountofCubes = Random.Range(_minCloneCubeAmount, _maxCloneCubeAmount + 1);

        Vector3 newScale = originalObject.transform.localScale / divider;

        for (int i = 0; i < amountofCubes; i++)
        {
            if (CanClone())
            {
                var newObject = Instantiate(originalObject);

                newObject.transform.position = originalObject.transform.position;
                newObject.transform.localScale = newScale;

                clones.Add(newObject);

                ClonesCreated?.Invoke(clones);
            }

            Destroy(originalObject);
        }

        _successPercentage /= _attempt;

        _attempt++;
    }

    private bool CanClone()
    {
        int minPercentage = 0;
        int maxPercentage = 100;

        float number = Random.Range(minPercentage, maxPercentage);

        return number  >= minPercentage && number <= _successPercentage;
    }
}
