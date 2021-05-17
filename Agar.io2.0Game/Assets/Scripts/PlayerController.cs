using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject ballFollow;
    private Vector3 _target;
    public Camera Camera;

    public float speed;
    public float keepDistance = 0.2f;
    float input_x;
    float input_y;
    float lastDirectionX;
    float lastDirectionY;

    Vector2 playerPos;
    Vector2 ballTwo;

    void Start()
    { 
        player.transform.position = new Vector3(0f,0f,0f);
        playerPos = MovimentBallFollow(1, 1, player.transform.position);   
    }

    void Update()
    {
        MovimentPlayer();

 
        if (input_x > 0 || input_x < 0)
            lastDirectionX = input_x;
 
        if (input_y > 0 || input_y < 0)
            lastDirectionY = input_y;
 
        
 
        ballTwo = transform.position;
        playerPos = MovimentBallFollow(lastDirectionX, lastDirectionY, player.transform.position);
 
        transform.position = Vector2.MoveTowards(ballTwo, playerPos, speed * Time.deltaTime);

        playerPos = MovimentBallFollow(lastDirectionX, lastDirectionY, player.transform.position);
        
    }

    void MovimentPlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        _target = Camera.ScreenToWorldPoint(Input.mousePosition);
        _target.z = 0;    
        transform.position = Vector3.MoveTowards(transform.position, _target,speed * Time.deltaTime);
        PointSpawn count = new PointSpawn();
        count.countPoint--;
    }

    Vector2 MovimentBallFollow(float horizantal, float vertical, Vector2 playerPos)
    {
        if(vertical < 0)
        {
            playerPos.x += keepDistance;
        }
        else if(vertical > 0)
        {
            playerPos.x -= keepDistance;
        }
 
        if (horizantal < 0)
        {
            playerPos.y += keepDistance;
        }
        else if (horizantal > 0)
        {
            playerPos.y -= keepDistance;
        }
 
        return playerPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "CirclePoint(Clone)")
        {
            Destroy(collision.gameObject);
            Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0f);
            player.transform.localScale += scaleChange;
        }
    }

}
