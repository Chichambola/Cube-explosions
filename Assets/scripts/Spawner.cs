using System.Collections;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Painter _painter;

    private int _minCloneCubeAmount = 2;
    private int _maxCloneCubeAmount = 6;

    public List<Cube> Clone(Cube originalCube)
    {
        List<Cube> clones = new();

        int divider = 2;

        int amountofCubes = Random.Range(_minCloneCubeAmount, _maxCloneCubeAmount + 1);

        Vector3 newScale = originalCube.transform.localScale / divider;

        for (int i = 0; i < amountofCubes; i++)
        {
            var newCube = Instantiate(originalCube);
            
            if(newCube.TryGetComponent(out MeshRenderer meshRenderer))
            {
                newCube.transform.position = originalCube.gameObject.transform.position;
                newCube.transform.localScale = newScale;
                newCube.DecreaseChances(originalCube.SplitChance);

                meshRenderer.material.color = _painter.ChangeColor();

                clones.Add(newCube);
            }
        }

        Destroy(originalCube.gameObject);

        return clones;
    }
}
