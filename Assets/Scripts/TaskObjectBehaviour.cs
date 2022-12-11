using System;
using UnityEngine;


public abstract class TaskObjectBehaviour : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Animator animator;
    private protected Vector3 startPositionLocal = default;    
    private protected Transform targetTransform;
    private protected Action callback;
    private protected bool isActive;

    private protected void OnEnable()
    {
        isActive= true;
    }

    private void Update()
    {        
       Move();              
    }

    private abstract protected void Move();
    private abstract protected void Rotate();
    

    private protected void OnTargetReach()
    {
        callback();        
    }

    public virtual void Initialize(Transform targetTransform,  Action callback, bool isFliped )
    {
        gameObject.SetActive(true);
        startPositionLocal = transform.localPosition;
        if (isFliped)
        {
            transform.localPosition = new Vector3(-startPositionLocal.x, startPositionLocal.y, startPositionLocal.z);            
        }
        this.callback = callback;        
        this.targetTransform = targetTransform;        

        Rotate();
    }    

    private protected void EndOfAnimation()
    {        
        transform.localPosition = startPositionLocal;
        gameObject.SetActive(false);
    }
}
