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
            Debug.Log("������� ����");
            return;
        }
        pointInPath = MyPath.GetNextPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("3");
            return;
        }

        transform.position = pointInPath.Current.position;// ������ ������ ����� �� ��������� �����
    }

    public void FixedUpdate()
    {
        if(pointInPath == null || pointInPath.Current == null)//�������� �������� ����
        {
            return;// �����, ���� ���
        }

        if(Type == MovingType.Moveing)// ���� ������ ���� ���
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, speed);

        }
        else if(Type == MovingType.Lerping)// ���� ������ ���� ���
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;// ��������� �� ������� ������
        if (distanceSqure < maxDistance*maxDistance)// ���������� �� �� ������
        {
            pointInPath.MoveNext();// ��������� � ��������� �����
        }
    }

}
