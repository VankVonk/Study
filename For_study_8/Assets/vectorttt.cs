using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorttt : MonoBehaviour
{
    static int n = 12; // кол-во поинтов
    Vector3[] points = new Vector3[n];
    int place = 0; 

    void Start()
    {
        int numb;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0) { numb = 4; } else { numb = -4; } // чтобы было наглядно
            points[i] = new Vector3(numb, 0, i + 1);
            //Debug.Log(points[i]); //если нада 
        }
    }

    
    void Update()
    {
        if ( place < n)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[place], 0.008f);

            if (transform.position == points[place])
            {
                place++;
            }
        }
        else if (place == n)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 0.1f); //скорость специально выше, т.к понятно куда он поедет
            
        }


         if (transform.position == new Vector3(0, 0, 0)) // бесконечный вариант, если закомментить, будет только одна итерация
        {
            place = 0;
        }
    }
}
