using System.Collections;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    public float ballSpeed;
    Rigidbody2D move;
    Vector3 _position;

    void Start()
    {
        move = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawnBall, GetComponent<PlayerController>().transform.position , Quaternion.identity);
            StartCoroutine(SpeedSpawn());  
        }
    }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        move.AddForceAtPosition(new Vector2(ballSpeed, 0f), Input.mousePosition);
    }
}

