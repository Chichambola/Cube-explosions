using System.Collections;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private int _attempt = 1;
    private float _successPercentage = 100;
    private int _minCloneCubeAmount = 2;
    private int _maxCloneCubeAmount = 6;

    public event Action<List<Cube>> ClonesCreated;

    public List<Cube> Clone(Cube originalCube)
    {
        List<Cube> clones = new ();

        int divider = 2;

        int amountofCubes = Random.Range(_minCloneCubeAmount, _maxCloneCubeAmount + 1);

        Vector3 newScale = originalCube.transform.localScale / divider;

        for (int i = 0; i < amountofCubes; i++)
        {
            if (CanClone())
            {
                var newObject = Instantiate(originalCube);

                newObject.transform.position = originalCube.transform.position;
                newObject.transform.localScale = newScale;

                clones.Add(newObject);
            }

            ClonesCreated?.Invoke(clones);
        }

        Destroy(originalCube.gameObject);
        
        _successPercentage /= _attempt;

        _attempt++;

        return clones;
    }

    private bool CanClone()
    {
        int minPercentage = 0;
        int maxPercentage = 100;

        float number = Random.Range(minPercentage, maxPercentage);

        return number  >= minPercentage && number <= _successPercentage;
    }
}
