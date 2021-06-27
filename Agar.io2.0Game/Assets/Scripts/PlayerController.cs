using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Vector3 _target;
    public Camera Camera;
    public int sizeBall;
    public float speed;
    PointSpawn count;


    void Start()
    { 
        player.transform.position = new Vector3(0f,0f,0f);
        count = GetComponent<PointSpawn>();
    }

    void Update()
    {
        MovimentPlayer();
    }

    public void MovimentPlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        _target = Camera.ScreenToWorldPoint(Input.mousePosition);
        _target.z = 0;    
        transform.position = Vector3.MoveTowards(transform.position, _target,speed * Time.deltaTime);
        count.countPoint--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PointMap")
        {
            Destroy(collision.gameObject);
            Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0f);
            player.transform.localScale += scaleChange;

            sizeBall++;
        }
    }

}
