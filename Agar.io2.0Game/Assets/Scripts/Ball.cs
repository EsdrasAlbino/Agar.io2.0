using System.Collections;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    public float ballSpeed;
    Rigidbody2D move;  
    void Start()
    {
        move = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawnBall, GetComponent<PlayerController>().transform.position, Quaternion.identity);
            StartCoroutine(SpeedSpawn());
            move.AddForce(new Vector2(ballSpeed, 0f));
        }
    }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
}

