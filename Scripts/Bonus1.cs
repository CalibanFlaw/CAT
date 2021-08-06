using System.Collections.Generic;
using UnityEngine;

public class Bonus1 : MonoBehaviour
{
    public GameObject[] Money;
    Vector3 Spawn;
    private float SpawnBonus;
    private float nextSpawn = 15, RandX, RandY;
    public float timeDelite;

    

    

    private List<GameObject> SpawnedBonus = new List<GameObject>();

   

    void FixedUpdate()
    {

        SpawnBonus = Random.Range(15, 150);
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnBonus;
            RandX = Random.Range(-4f, 4f);
            RandY = Random.Range(14.5f, 17.5f);
            Spawn = new Vector3(RandX, RandY, -1.1f);
            GameObject newBonus = Instantiate(Money[Random.Range(0, Money.Length)]);
            newBonus.transform.position = Spawn;

            
            Destroy(newBonus, 7f);

        }
        
        
        
            
        
        
    } 
}
