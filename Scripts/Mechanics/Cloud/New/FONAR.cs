using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FONAR : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = Random.Range(0.005f, 0.01f);

    }


    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0, Space.Self);
        if (transform.position.x > 5)
        {
            speed = -Random.Range(0.005f, 0.01f);
        }
        if (transform.position.x < -5)
        {
            speed = Random.Range(0.005f, 0.01f);
        }

    }
}
