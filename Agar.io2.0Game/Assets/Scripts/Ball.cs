using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    PlayerController playerOne;
    Rigidbody2D force;
    public Camera cameraTwo;
    Vector3 _targ;

    public float ballForce;
    public float speed;
    public bool value;

    void Start()
    {
        force = GetComponent<Rigidbody2D>();
        playerOne = GetComponent<PlayerController>();
    }

    void Update()
    {
        Spawn();
        Follow();
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
                value = true;             
            }
             if (playerOne.sizeBall>=150 & value)
            {
                playerOne.sizeBall/=4;
                playerOne.transform.localScale/=4;
                spawnBall.transform.localScale = playerOne.transform.localScale;
                Instantiate(spawnBall, playerOne.transform.position , Quaternion.identity);
                StartCoroutine(SpeedSpawn());    
            }
        }
    }

    void Follow()
    {
        Vector3 mousePos = Input.mousePosition;
        _targ = cameraTwo.ScreenToWorldPoint(Input.mousePosition);
        _targ.z = 0;    
        spawnBall.transform.position = Vector3.MoveTowards(spawnBall.transform.position, _targ,speed * Time.deltaTime);
    }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        force.AddForceAtPosition(new Vector2(ballForce, 0f), Input.mousePosition);
    }

    IEnumerator Divible()
    {
        yield return new WaitForSeconds(15f);



        value = false;
    }
}

