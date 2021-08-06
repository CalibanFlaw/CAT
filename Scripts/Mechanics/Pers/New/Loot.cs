using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField]
    public GameObject Magnit;
    public GameObject Milk;
    public GameObject Money;
    Vector3 Spawn;
    public float SpawnMagnit, SpawnMoney, SpawnMilk;
    private float nextSpawn = 100, nextSpawn1 = 50, nextSpawn2 = 200, RandX, RandY;

    Move move;

    private void Start()
    {
        move = FindObjectOfType<Move>();

    }



    // Update is called once per frame
    void FixedUpdate()
    {


        Magnitik();
        Monetka();
        Moloko();



    }

    void Magnitik()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnMagnit;
            RandX = Random.Range(-4f, 4f);
            RandY = Random.Range(14.5f, 17.5f);
            Spawn = new Vector3(RandX, RandY, -1.1f);
            Instantiate(Magnit, Spawn, Quaternion.identity);
        }

    }
    void Monetka()
    {
        if (Time.time > nextSpawn1)
        {
            nextSpawn1 = Time.time + SpawnMoney;
            RandX = Random.Range(-4f, 4f);
            RandY = Random.Range(14.5f, 17.5f);
            Spawn = new Vector3(RandX, RandY, -1.1f);
            Instantiate(Money, Spawn, Quaternion.identity);
        }

    }
    void Moloko()
    {
        if (Time.time > nextSpawn2)
        {
            nextSpawn2 = Time.time + SpawnMilk;
            RandX = Random.Range(-4f, 4f);
            RandY = Random.Range(14.5f, 17.5f);
            Spawn = new Vector3(RandX, RandY, -1.1f);
            Instantiate(Milk, Spawn, Quaternion.identity);
        }

    }
}
