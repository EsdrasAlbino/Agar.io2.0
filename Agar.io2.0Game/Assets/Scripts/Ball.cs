using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject spawnBall;
    public float ballSpeed;

    void Start()
    {
        
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
        }
    }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        CircleClone.GetComponent<Rigidbory2d>().AddForce(ballSpeed, ForceMode2D.Impulse);
    }
}
