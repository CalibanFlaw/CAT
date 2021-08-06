using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public Transform Player;
    public Road[] EasyPrefabs, EasyPrefabs2, MediumPrefabs, MediumPrefabs2;
    public Road First;

    SCORE SCR;


    private List<Road> spawnedPlatform = new List<Road>();










    void Start()
    {
        spawnedPlatform.Add(First);
        SCR = FindObjectOfType<SCORE>();

        

    }


    void FixedUpdate()
    {


        if (Player.position.y > spawnedPlatform[spawnedPlatform.Count - 1].End.position.y - 35)
        {
            if (SCR.scoreCounter <= 10000)
            {
                if (SCR.scoreCounter <= 1200)
                {
                    EasyPlatform();
                }
                if (SCR.scoreCounter >= 1200)
                {
                    MediumPlatform();
                }



            }

            if (SCR.scoreCounter >= 10000)
            {


                if (SCR.scoreCounter <= 12000)
                {
                    EasyPlatform2();
                }
                if (SCR.scoreCounter >= 12000)
                {
                    MediumPlatform2();
                }

            }


        }

    }

    private void EasyPlatform()
    {

        Road newplatform = Instantiate(EasyPrefabs[Random.Range(0, EasyPrefabs.Length)]);
        newplatform.transform.position = spawnedPlatform[spawnedPlatform.Count - 1].End.position + newplatform.Begin.position;
        spawnedPlatform.Add(newplatform);

        if (spawnedPlatform.Count >= 3)
        {
            Destroy(spawnedPlatform[0].gameObject);
            spawnedPlatform.RemoveAt(0);
            
        }
    }
    private void MediumPlatform()
    {


        Road newplatform = Instantiate(MediumPrefabs[Random.Range(0, MediumPrefabs.Length)]);
        newplatform.transform.position = spawnedPlatform[spawnedPlatform.Count - 1].End.position + newplatform.Begin.position;
        spawnedPlatform.Add(newplatform);

        if (spawnedPlatform.Count >= 3)
        {
            Destroy(spawnedPlatform[0].gameObject);
            spawnedPlatform.RemoveAt(0);
        }

    }
    private void EasyPlatform2()
    {

        Road newplatform = Instantiate(EasyPrefabs2[Random.Range(0, EasyPrefabs2.Length)]);
        newplatform.transform.position = spawnedPlatform[spawnedPlatform.Count - 1].End.position + newplatform.Begin.position;
        spawnedPlatform.Add(newplatform);

        if (spawnedPlatform.Count >= 3)
        {
            Destroy(spawnedPlatform[0].gameObject);
            spawnedPlatform.RemoveAt(0);
        }

    }
    private void MediumPlatform2()
    {

        Road newplatform = Instantiate(MediumPrefabs2[Random.Range(0, MediumPrefabs2.Length)]);
        newplatform.transform.position = spawnedPlatform[spawnedPlatform.Count - 1].End.position + newplatform.Begin.position;
        spawnedPlatform.Add(newplatform);

        if (spawnedPlatform.Count >= 3)
        {
            Destroy(spawnedPlatform[0].gameObject);
            spawnedPlatform.RemoveAt(0);
        }


    }
}
