using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSpeed = 0.2f;

    float posX, posY, angle = 0f;


    private void FixedUpdate()
    {
        // мат. вычесления. если сделать син\син то движение будет по диалонали син\тан по горизонтали тан\тан по вертикали

        posX = center.position.x + Mathf.Cos(angle) * radius;
        posY = center.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
