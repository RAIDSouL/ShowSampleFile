using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    private int NumEnemy = 0;
    public int MaxEnermy;
    private float delayTime;
    Vector3 SpawnPosition;
    // public float delayTime;
    void Start()
    {
        StartCoroutine("GenEnemy");
    }

    IEnumerator GenEnemy()
    {   
        while(NumEnemy < MaxEnermy)
        {
            float randnum = Random.value;
            delayTime = randnum * 5f;
            yield return new WaitForSeconds(delayTime);
            randnum *= 3f;

            SpawnPosition.Set(transform.position.x+randnum,transform.position.y,transform.position.z+randnum);
            Instantiate(Enemy,SpawnPosition,Quaternion.identity);
            NumEnemy += 1;
            // Debug.Log("nun");
            
        }
    }
}
