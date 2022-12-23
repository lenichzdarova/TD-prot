using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSkill : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private TargetProvider targetProvider;

    [SerializeField]
    private string targetLayer;
    [SerializeField]
    private string taskName;
    [SerializeField] 
    private AudioClip audioClip;
    [SerializeField]
    private float range;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private TowerSkillGameObject skillGameObject;    

    private bool isReady = true;


    public void Initialize()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetProvider = new TargetProvider();
    }    

    public  bool Execute()
    {
        if (isReady)
        {
           Transform target = targetProvider.TryToGetTarget(transform , range , targetLayer);
            if (target != null)
            {
                if (transform.position.x < target.position.x && spriteRenderer.flipX == true)
                {
                    spriteRenderer.flipX = false;

                    skillGameObject.transform.localPosition = new Vector3(-skillGameObject.transform.localPosition.x, skillGameObject.transform.localPosition.y, skillGameObject.transform.localPosition.z);
                }
                else if (transform.position.x > target.position.x && spriteRenderer.flipX == false)
                {
                    spriteRenderer.flipX = true;
                    skillGameObject.transform.localPosition = new Vector3(-skillGameObject.transform.localPosition.x, skillGameObject.transform.localPosition.y, skillGameObject.transform.localPosition.z);
                }
                Activation(target);
                return true;
            }
            else return false;
        }
        else
        {
            return isReady;
        }
    }    

    private IEnumerator Realoading()
    {
        yield return new WaitForSeconds(reloadTime);
        isReady = true;
    }

    private void Activation(Transform targetTransform)
    {        
        animator.SetTrigger(taskName);
        isReady = false;
        StartCoroutine(Realoading());
        skillGameObject.Initialize(targetTransform);
    }

    private void ActivationAnimEvent()
    {
        skillGameObject.gameObject.SetActive(true);
        audioSource.PlayOneShot(audioClip);        
    } 
    
    private void AnimationEnd()
    {
        animator.SetTrigger("Idle");
    }
}
