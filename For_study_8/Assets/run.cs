using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
   public Transform runner1;
   public Transform runner2;
   public Transform runner3;
   public Transform runner4;
   public Transform runner5;

    Vector3[] pos = new Vector3[4]; // массив точек
    Transform [] runn = new Transform[5]; //массив бегунов
    
    int run_count = 4; //каунтер бегнуов
    int pos_count = 0; // каунтер позиций
    int run_count_old = 4; // каунтер бегунов для куба который подбегает к точке
    int pos_count_old = 0; // каунтер позиций для куба который подбегает к точке
    int first_drive = 1; // запускатор

    float passDistace = 1.25f; // дистанция при которой начинает бежать следующий куб


    void Start()
    {  
        //вношу в массив объекты
        runn[0] = runner1;
        runn[1] = runner2;
        runn[2] = runner3;
        runn[3] = runner4;
        runn[4] = runner5;

        // отдельные позиции, чтобы можно было менять местоположение кубов
        pos[0] = runner1.position;
        pos[1] = runner2.position;
        pos[2] = runner3.position;
        pos[3] = runner4.position;
    }

    
    void Update()
    {
        if (first_drive == 1 ) //так скажем толчок 
        {
            runn[run_count].position = Vector3.MoveTowards(runn[run_count].position, pos[pos_count], 0.01f);
        }

        if (Vector3.Distance(runn[run_count].position, pos[pos_count]) < passDistace)
        {
            run_count_old = run_count;
            run_count++;
            if (run_count > 4) { run_count = 0; }
            pos_count_old = pos_count;
            pos_count++;
            if (pos_count > 3) { pos_count = 0; }
            
        }
        runn[run_count_old].position = Vector3.MoveTowards(runn[run_count_old].position, pos[pos_count_old], 0.01f); // нужно чтобы после срабатывания if куб "добегал"

        runn[run_count].position = Vector3.MoveTowards(runn[run_count].position, pos[pos_count], 0.01f);

    }
}
