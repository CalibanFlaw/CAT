using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPas : MonoBehaviour
{
    public enum MovingType
    {
        Moveing,
        Lerping
    }
    public MovingType Type = MovingType.Moveing;
    public NAV MyPath;
    public float speed = .1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    public void Start()
    {
        if(MyPath == null)
        {
            Debug.Log("примени путь");
            return;
        }
        pointInPath = MyPath.GetNextPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("3");
            return;
        }

        transform.position = pointInPath.Current.position;// объект должен стать на стартовую точку
    }

    public void FixedUpdate()
    {
        if(pointInPath == null || pointInPath.Current == null)//проверка отсутвия пути
        {
            return;// выход, пути нет
        }

        if(Type == MovingType.Moveing)// если выбран этот вид
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, speed);

        }
        else if(Type == MovingType.Lerping)// если выбран этот вид
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;// проверяем на сколько близко
        if (distanceSqure < maxDistance*maxDistance)// достаточно ли мы близко
        {
            pointInPath.MoveNext();// двигаемся к следующей точке
        }
    }

}
