using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zizon : MonoBehaviour
{
    public int hp;
    public int damage;
    private GameObject player;
    public float speed;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
