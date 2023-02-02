using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy_Hoverbot;
    [SerializeField]
    private GameObject SpecialEnemyHoverbot;
    public List<GameObject> location = new List<GameObject>();
    [SerializeField]
    private Transform specialLocation;
    private bool playerDetected;
    [SerializeField]
    private float waitTime = 1.0f;
    private float timer = 0f;
    private int enemiesSpawned = 0;
    int counter = 0;
    
  

    private void Start()
    {
        
    }




    private void Update()
    {
        timer -= Time.deltaTime;

        if (playerDetected)
        {

            if (timer <= 0)
            {
                SpawnEnemies();
                enemiesSpawned++;
                timer = waitTime;
            }

            if (enemiesSpawned >= location.Count)
            {
                SpawnSpecialEnemy();
                playerDetected = false;
            }    
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerDetected = true;

        timer = waitTime;
    }

    private void SpawnEnemies() 
    {
        Debug.Log("Spaaaaa");
        Instantiate(Enemy_Hoverbot, location[enemiesSpawned].transform.position, Quaternion.identity);
       
    }

    private void SpawnSpecialEnemy()
    {
        Instantiate(SpecialEnemyHoverbot, specialLocation.position, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        //Destroy(gameObject);
    }

    
    
}
