using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private MeshRenderer _meshRenderer;

    private const int MinValue = 2;
    private const int MaxValue = 7;
    private const int DecreaseNumber = 2;
    private const int RandomMaxValue = 101;
    private float _chanceSeparation = 100;

    private void OnMouseDown()
    {
        Destroy(gameObject);    
        CreateCube();
    }

    public void CreateCube()
    {       
        int quantity = UnityEngine.Random.Range(MinValue, MaxValue);
        float random = UnityEngine.Random.Range(0, RandomMaxValue);

        if (_chanceSeparation >= random)
        {
            _chanceSeparation /= DecreaseNumber;

            for (int i = 0; i < quantity; i++)
            {
                Cube cube = Instantiate(_prefab, transform.position, transform.rotation);

                cube.SetOptions(_chanceSeparation, cube);
            }
        }
    }

    private void SetOptions(float chance, Cube cube)
    {
        _chanceSeparation = chance;

        Vector3 scale = transform.localScale / DecreaseNumber;
        cube.transform.localScale = scale;

        _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
