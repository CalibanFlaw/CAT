using System.Collections.Generic;
using UnityEngine;

public class NAV : MonoBehaviour
{
   public enum Types
    {
        liner,
        loop
    }

    public Types PathType; // определяет тип пути
    public int moveDirection = 1; // направление : вперед или назад
    public int moveingTo = 0; // к какой точке
    public Transform[] Elements;

    public void OnDrawGizmos()// отоброжает линии между точками
    {
        if(Elements ==null || Elements.Length < 2)// проверяет есть ли 2 элемента
        {
            return;     
        }
        for (var i = 1; i <Elements.Length; i++)// прогоняет все точки
        {
            Gizmos.DrawLine(Elements[i - 1].position, Elements[i].position);// рисует линии
        }
        if(PathType == Types.loop)// путь замкнутый
        {
            Gizmos.DrawLine(Elements[0].position, Elements[Elements.Length-1].position);// рисует линии 
        }
    }
    public IEnumerator<Transform> GetNextPoint()
    {
        if(Elements == null || Elements.Length < 1)//проверка на нужные точки
        {
            yield break;//позволяет выйти из коротины
        }
        while (true)
        {
            yield return Elements[moveingTo];// возврат к текущей точке

            if(Elements.Length == 1)// если одна точка выйти
            {
                continue;
            }
            if(PathType == Types.liner)// если линия
            {
                if(moveingTo <= 0)// движемся по нарастающей
                {
                    moveDirection = 1;// добовлем к движению
                }
                else if(moveingTo >=Elements.Length - 1)// двигаемся по убывающей
                {
                    moveDirection = -1;// убираем один из движения
                }
            }
            moveingTo = moveingTo + moveDirection;// диапозон от 1 до -1
            
            if(PathType == Types.loop)// линия зациклина
            {
                if(moveingTo>= Elements.Length)// мы дошли до последней точки
                {
                    moveingTo = 0;// идем обратно
                }
                if(moveingTo < 0)//если мы дошли до первой точки в обратном направление
                {
                    moveingTo = Elements.Length - 1;// от первой к последней
                }
            }
        }
    }
}
