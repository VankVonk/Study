using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorttt : MonoBehaviour
{
    
    public Vector3[] points = new Vector3[12];
    int place = 0;
    
    void Start()
    {
        int n = points.Length;
        int numb;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0) { numb = 4; } else { numb = -4; } // ����� ���� ��������
            points[i] = new Vector3(numb, 0, i + 1);
            //Debug.Log(points[i]); //���� ���� 
        }
    }

    
    void Update()
    {
         int n = points.Length;
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 0.1f); //�������� ���������� ����, �.� ������� ���� �� ������
            
        }


         if (transform.position == new Vector3(0, 0, 0)) // ����������� �������, ���� ������������, ����� ������ ���� ��������
        {
            place = 0;
        }
    }
}
