using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int healthPoints;
    private float timerBullet;
    public GameObject bullet;
    public float lowerRangeOfTIme, upperRangeOfTime;
    public EndCondition endCondition;

    void Start()
    {
        healthPoints = 2;
        timerBullet = Random.Range(lowerRangeOfTIme, upperRangeOfTime);
        endCondition = GameObject.FindGameObjectWithTag("globalVariables").GetComponent<EndCondition>();
    }

    void FixedUpdate()
    {
        Shot();
    }

    void Shot()
    {
        timerBullet -= Time.deltaTime;
        if (timerBullet <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timerBullet = Random.Range(lowerRangeOfTIme, upperRangeOfTime);
        }
    }

    void GotShot()
    {
        if (healthPoints > 1)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            healthPoints--;
        }
        else
        {
            endCondition.UpdateScores();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulletPlayer"))
        {
            GotShot();
            Destroy(collision.gameObject);
        }
    }
}
