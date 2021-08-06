using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField]
    public float Speedplatform = 0.2f;
    public bool SwipeUp, SwipeDown;


    Move move;

    void Start()
    {


        move = FindObjectOfType<Move>();

    }

    void FixedUpdate()
    {

        PlatformMove();

    }

    public void PlatformMove()
    {
        if (move.CanPlay)
        {
            transform.Translate(Vector2.down * Speedplatform);
        }
    }

}
