using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public GameObject player;
private Vector3 _target;
public Camera Camera;
public float speed;
 void Start()
 { 
    player.transform.position = new Vector3(0f,0f,0f);
 }

 void Update()
 {
     Moviment();
 }

 void Moviment(){

        Vector3 mousePos = Input.mousePosition;
        _target = Camera.ScreenToWorldPoint(Input.mousePosition);
        _target.z = 0;
 
         transform.position = Vector3.MoveTowards(transform.position, _target,speed * Time.deltaTime);
         PointSpawn count = new PointSpawn();
         count.countPoint--;

 }
private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.name == "Circle (1)(Clone)"){
        Destroy(collision.gameObject);
        Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0f);
        player.transform.localScale += scaleChange;
    }
}

}
