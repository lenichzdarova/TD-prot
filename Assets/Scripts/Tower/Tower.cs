using System.Collections.Generic;
using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField] private List<TowerSkill> skills;    

    // Update is called once per frame
    void Update()
    {           
        //затычка, тут распетл€ю
       TasksExecution();             
    }
    
    private void TasksExecution()
    {       
        foreach (var task in skills)
        {
            if (task.Execute())
            {
                return;
            }
        }        
    }
}
