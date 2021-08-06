using System.Collections.Generic;
using UnityEngine;

public class NAV : MonoBehaviour
{
   public enum Types
    {
        liner,
        loop
    }

    public Types PathType; // ���������� ��� ����
    public int moveDirection = 1; // ����������� : ������ ��� �����
    public int moveingTo = 0; // � ����� �����
    public Transform[] Elements;

    public void OnDrawGizmos()// ���������� ����� ����� �������
    {
        if(Elements ==null || Elements.Length < 2)// ��������� ���� �� 2 ��������
        {
            return;     
        }
        for (var i = 1; i <Elements.Length; i++)// ��������� ��� �����
        {
            Gizmos.DrawLine(Elements[i - 1].position, Elements[i].position);// ������ �����
        }
        if(PathType == Types.loop)// ���� ���������
        {
            Gizmos.DrawLine(Elements[0].position, Elements[Elements.Length-1].position);// ������ ����� 
        }
    }
    public IEnumerator<Transform> GetNextPoint()
    {
        if(Elements == null || Elements.Length < 1)//�������� �� ������ �����
        {
            yield break;//��������� ����� �� ��������
        }
        while (true)
        {
            yield return Elements[moveingTo];// ������� � ������� �����

            if(Elements.Length == 1)// ���� ���� ����� �����
            {
                continue;
            }
            if(PathType == Types.liner)// ���� �����
            {
                if(moveingTo <= 0)// �������� �� �����������
                {
                    moveDirection = 1;// �������� � ��������
                }
                else if(moveingTo >=Elements.Length - 1)// ��������� �� ���������
                {
                    moveDirection = -1;// ������� ���� �� ��������
                }
            }
            moveingTo = moveingTo + moveDirection;// �������� �� 1 �� -1
            
            if(PathType == Types.loop)// ����� ���������
            {
                if(moveingTo>= Elements.Length)// �� ����� �� ��������� �����
                {
                    moveingTo = 0;// ���� �������
                }
                if(moveingTo < 0)//���� �� ����� �� ������ ����� � �������� �����������
                {
                    moveingTo = Elements.Length - 1;// �� ������ � ���������
                }
            }
        }
    }
}
