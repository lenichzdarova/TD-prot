using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Tower: MonoBehaviour
{
    [SerializeField] private List<TowerTask> tasks;
    [SerializeField] Animator animator;
    

    // Update is called once per frame
    void Update()
    {           
       TasksExecution();             
    }
    
    private void TasksExecution()
    {       
        foreach (var task in tasks)
        {
            if (task.Execute())
            {
                return;
            }
        }        
    }
}
