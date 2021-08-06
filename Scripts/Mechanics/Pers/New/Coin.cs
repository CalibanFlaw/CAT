using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _Player;
    public GameObject _Distance;
    public static bool activemag = false;
    private float Distance;
    public float Dis;

    public float rotspeed = 1;

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Magnits");
    }

    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 1 * rotspeed, 0);
        if (activemag)
        {
            move();
        }
    }
    void move()
    {

        Distance = Vector2.Distance(transform.position, _Distance.transform.position);
        if (Distance <= Dis)
        {
            transform.position = Vector3.Lerp(transform.position, _Player.transform.position, 0.08f);
        }
    }
}
