using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private int MinValue = 2;
    private int MaxValue = 6;
    private int DecreaseNumber = 2;
    private int RandomMaxValue = 100;
    private float _chanceSeparation = 100;

    private void OnMouseDown()
    {
        Destroy(gameObject);    
        CreateCube();
    }

    public void SetOptions(float chance, Cube cube)
    {
        _chanceSeparation = chance;

        Vector3 scale = transform.localScale / DecreaseNumber;
        cube.transform.localScale = scale;

        _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void CreateCube()
    {       
        int quantity = UnityEngine.Random.Range(MinValue, MaxValue + 1);
        float random = UnityEngine.Random.Range(0, RandomMaxValue + 1);

        if (_chanceSeparation >= random)
        {
            _chanceSeparation /= DecreaseNumber;

            for (int i = 0; i < quantity; i++)
            {
                Cube cube = Instantiate(this, transform.position, transform.rotation);

                cube.SetOptions(_chanceSeparation, cube);
            }
        }
    }
}
