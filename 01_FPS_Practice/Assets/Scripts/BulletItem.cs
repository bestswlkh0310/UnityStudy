using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour, IRotatable
{
    private Vector3 rotation;
    public float rotationRange;
    
    void Start()
    {
        rotation = new Vector3(Random.Range(-rotationRange, rotationRange), Random.Range(-rotationRange, rotationRange),
            Random.Range(-rotationRange, rotationRange));
    }

    public void Rotate()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
