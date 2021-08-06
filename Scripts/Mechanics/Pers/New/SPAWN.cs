using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN : MonoBehaviour
{
    public GameObject loot;

    Move move;

    private void Start()
    {
        move = FindObjectOfType<Move>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (move.CanPlay)
            if (other.CompareTag("Player") || other.tag == "Loot")
            {

                Destroy(gameObject);


            }
    }

}
