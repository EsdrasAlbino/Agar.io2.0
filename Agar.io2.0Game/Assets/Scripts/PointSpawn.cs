using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    public GameObject prefeb;
    public int countPoint;
    public float spawnWait;
    public bool condition;
    
    void Start()
    {
            while(!condition && countPoint<500)
        {
            Instantiate(prefeb, new Vector2(Random.Range(-9.55f, 29f), Random.Range(-5.30f, 15f)), Quaternion.identity);
            countPoint ++;
        }
        StartCoroutine(spawnTime());
    }

    void Update()
    {
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag ("PointMap");
        countPoint = thingyToFind.Length; 

        if(countPoint>700)
        spawnWait = Random.Range(0f,1f);
        else spawnWait = Random.Range(0f,0.5f);
    }

     IEnumerator spawnTime()
  {
        while(!condition)
        {
            Instantiate(prefeb, new Vector2(Random.Range(-9.55f, 29f), Random.Range(-5.30f, 15f)), Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
  }
}
