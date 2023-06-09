using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class ZizonManager : MonoBehaviour
{
    public GameObject zizon;
    
    public float zizonCreateRate;
    private float currentTime;
    public float createPosRange;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > zizonCreateRate)
        {
            CreateZizon();
            currentTime = 0.0f;
        }
    }

    private void CreateZizon()
    {
        Instantiate(zizon, new Vector3(Random.Range(-createPosRange, createPosRange), 1.0f, Random.Range(-createPosRange, createPosRange)), zizon.transform.rotation);
    }
}
