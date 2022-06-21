using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int healthPoints;
    public GameObject bullet;
    public GameObject bulletStartPoint;
    public EndCondition endCondition;
    public Text healthPointsText;
    public float leftBorder, rightBorder;

    private float direction;

    public float maxSpeed;

    private bool keyRightPressed, keyLeftPressed, keySpacePressed;

    void Start()
    {
        healthPoints = 3;
        endCondition = GameObject.FindGameObjectWithTag("globalVariables").GetComponent<EndCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    void FixedUpdate()
    {
        MovePlayer();
        Shot();
    }

    void HandleInputs()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) keyLeftPressed = true;
        else keyLeftPressed = false;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) keyRightPressed = true;
        else keyRightPressed = false;
        if (Input.GetKeyDown(KeyCode.Space)) keySpacePressed = true;
    }

    void MovePlayer()
    {
        if (keyLeftPressed && transform.position.x > -10) direction = -1f;
        else if (keyRightPressed && transform.position.x < 10) direction = 1f;
        else direction = 0;
        transform.position = new Vector3(transform.position.x + direction * maxSpeed, transform.position.y, transform.position.z);
    }

    void Shot()
    {
        if(keySpacePressed)
        {
            Instantiate(bullet, bulletStartPoint.transform.position, Quaternion.identity);
            keySpacePressed = false;
        }
    }

    void GotShot()
    {
        healthPoints--;
        healthPointsText.text = healthPoints.ToString();
        if (healthPoints <= 0) 
        {
            endCondition.End(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBullet"))
        {
            GotShot();
            Destroy(collision.gameObject);
        }
    }
}
