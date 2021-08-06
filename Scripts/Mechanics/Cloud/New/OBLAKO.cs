using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBLAKO : MonoBehaviour
{
    private float speed;


    void Start()
    {
        speed = Random.Range(0.04f, 0.25f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0, Space.World);
        if (transform.position.x > 4.5)
        {
            speed = -speed;
        }
        if (transform.position.x < -4.5)
        {
            speed = Random.Range(0.04f, 0.25f);
        }

    }
}
