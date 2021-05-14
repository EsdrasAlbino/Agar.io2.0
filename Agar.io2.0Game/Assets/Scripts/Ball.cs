using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    public float ballSpeed;
    PlayerController person = new PlayerController();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn(){
    if(Input.GetKey(KeyCode.Space))
    Instantiate(spawnBall, person.player.transform.position*ballSpeed, Quaternion.identity);
    }
}
