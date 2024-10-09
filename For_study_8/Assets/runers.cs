using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runers : MonoBehaviour
{
   
   public float passDistace = 1.25f; // дистанция при которой начинает бежать следующий куб
   public Transform [] runn = new Transform[5]; //массив бегунов

   private int run_count = 0; // от кого
   private int run_count_old = 1; // к кому

    void Start()
    {
        
        
    }

    
    void Update()
    {
        

        if (run_count_old + 1 > runn.Length) { run_count_old = 0; }
        if (run_count + 1 > runn.Length) { run_count = 0; }
       

        if (Vector3.Distance(runn[run_count].position, runn[run_count_old].position) < passDistace)
        {
            
            run_count++;
            run_count_old++;
            
        }
        

        runn[run_count].position = Vector3.MoveTowards(runn[run_count].position, runn[run_count_old].position, 0.01f);

    }
}
