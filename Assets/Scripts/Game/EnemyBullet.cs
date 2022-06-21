using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float maxSpeed;
    private float timeToLive;
    void Start()
    {
        timeToLive = 5;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - maxSpeed, 0);
        DestroyMe();
    }


    void DestroyMe()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
