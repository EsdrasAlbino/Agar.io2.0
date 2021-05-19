using System.Collections;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    PlayerController playerOne;
    public float ballSpeed;
    Rigidbody2D move;
    Vector3 _position;

    void Start()
    {
        move = GetComponent<Rigidbody2D>();
        playerOne = GetComponent<PlayerController>();
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(playerOne.sizeBall > 70 && playerOne.sizeBall< 150)
            {
                playerOne.sizeBall/=2;
                playerOne.transform.localScale/=2;
                spawnBall.transform.localScale = playerOne.transform.localScale;
                Instantiate(spawnBall, playerOne.transform.position , Quaternion.identity);
                StartCoroutine(SpeedSpawn());             
            }
            else
            {
                playerOne.sizeBall/=4;
                playerOne.transform.localScale/=4;
                spawnBall.transform.localScale = playerOne.transform.localScale;
                Instantiate(spawnBall, playerOne.transform.position , Quaternion.identity);
                StartCoroutine(SpeedSpawn());    
            }
        }
    }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        move.AddForceAtPosition(new Vector2(ballSpeed, 0f), Input.mousePosition);
    }
}

