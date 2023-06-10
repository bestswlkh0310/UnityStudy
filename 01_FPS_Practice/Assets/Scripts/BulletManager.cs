using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public float bulletCreateRate;
    private float currentTime;
    public float spawnPosRange;
    
    void Update()
    {
        CreateBullet();
    }

    private void CreateBullet()
    {
        currentTime += Time.deltaTime;
        if (currentTime > bulletCreateRate)
        {
            GameObject newBullet = Instantiate(bullet,
                new Vector3(Random.Range(-spawnPosRange, spawnPosRange), 0.5f,
                    Random.Range(-spawnPosRange, spawnPosRange)),
                bullet.transform.rotation);
            newBullet.name = "Bullet";
            ItemManager.items.Add(newBullet.GetComponent<BulletItem>());
            currentTime = 0;
        }
    }
}
