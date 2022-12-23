using System.Collections.Generic;
using UnityEngine;

public class Tower: MonoBehaviour
{
    private AnimatorHandler animatorHandler;

    [SerializeField] private List<TowerSkill> skills;

    private void Awake()
    {
        animatorHandler = new AnimatorHandler(GetComponent<Animator>());
        foreach(var skill in skills)
        {
            skill.Initialize(); 
        }
    }
    
    private void SkillsActivation()
    {       
        foreach (var skill in skills)
        {
            if (skill.Execute())
            {
                return;
            }
        }        
    }
}
