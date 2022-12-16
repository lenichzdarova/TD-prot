using System.Collections.Generic;
using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField] private List<TowerSkill> tasks;    

    // Update is called once per frame
    void Update()
    {           
        //�������, ��� ���������
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
