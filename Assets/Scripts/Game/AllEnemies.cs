using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemies : MonoBehaviour
{
    float timer;
    public GameObject player;
    public EndCondition endCondition;
    float playerPosY;

    void Start()
    {
        timer = Random.Range(5f, 10f);
        playerPosY = player.transform.position.y;
        endCondition = GameObject.FindGameObjectWithTag("globalVariables").GetComponent<EndCondition>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GoDown();
    }

    void GoDown()
    {
        if (timer < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            timer = Random.Range(5f, 10f);
            if(playerPosY + 0.75f >= transform.position.y)
            {
                endCondition.End(false);
            }
        }
        else timer -= Time.deltaTime;
    }
}
