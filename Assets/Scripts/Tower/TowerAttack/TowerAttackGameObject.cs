using System;
using System.Collections;
using UnityEngine;

public class TowerAttackGameObject : MonoBehaviour
{
    public event Action<Vector3> TargetPointReach;

    [SerializeField] private TargetCoordinatesProvider _targetCoordinatesProvider;
    [SerializeField] private MovingBehaviour _movingBehaviour;
    private AttackGameObjectAnimatorHandler _animatorHandler;
    [SerializeField] private float _moveSpeed;

    private bool _isInitialized = false;
            
    private Vector3 _baseLocalPosition;    
    public void Initialize()
    {        
        _baseLocalPosition = transform.localPosition;        
        _targetCoordinatesProvider = GetComponent<TargetCoordinatesProvider>();
        _movingBehaviour = GetComponent<MovingBehaviour>();
        _animatorHandler = new AttackGameObjectAnimatorHandler(GetComponent<Animator>());
        _isInitialized = true;
    }  
    
    public void Activate(Transform targetTransform)
    {
        if (!_isInitialized)
        {
            Initialize();
        }
        gameObject.SetActive(true);
        _targetCoordinatesProvider.Initialize(targetTransform);
        _movingBehaviour.Initialize(_targetCoordinatesProvider, _moveSpeed);
        _animatorHandler.PlayMoveAnimation();
        StartCoroutine(Moving());
    }
    
    public void OnDirectionCheck(bool direction)
    {
        if ((direction && _baseLocalPosition.x > 0) || (!direction && _baseLocalPosition.x < 0))
        {
            _baseLocalPosition = new Vector3(-_baseLocalPosition.x, _baseLocalPosition.y, _baseLocalPosition.z);
            transform.localPosition = _baseLocalPosition;
        }
    }

    private bool Move(Vector3 movePoint) 
    {       
        transform.position = movePoint;
        return movePoint !=_targetCoordinatesProvider.GetTargetPoint();
    }

    private IEnumerator Moving()
    {        
        while (Move(_movingBehaviour.GetMovePoint()))
        {            
            yield return null;
        }        
        TargetPointReach?.Invoke(transform.position);
        _animatorHandler.PlayImpactAnimation();        
    }

    private void OnAnimationEnd() //animation event
    {
        transform.localPosition = _baseLocalPosition;        
        gameObject.SetActive(false);
    }
}
