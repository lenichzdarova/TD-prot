using System;
using System.Collections;
using UnityEngine;

public class TowerAttackGameObject : MonoBehaviour
{
    public event Action<Vector3> TargetPointReach;

    [SerializeField] private TargetCoordinatesProvider _targetCoordinatesProvider;
    [SerializeField] private MovingBehaviour _movingBehaviour;
    [SerializeField] private float _moveSpeed;   
            
    private Vector3 basePosition;    
    public void Initialize(Transform targetTransform)
    {
        gameObject.SetActive(true);
        basePosition  = transform.position;
        if (_targetCoordinatesProvider == null)
        {
            _targetCoordinatesProvider = GetComponent<TargetCoordinatesProvider>();
        }
        if (_movingBehaviour == null)
        {
            _movingBehaviour = GetComponent<MovingBehaviour>();
        }
        _targetCoordinatesProvider.Initialize(targetTransform);
        _movingBehaviour.Initialize(_targetCoordinatesProvider,_moveSpeed);
        StartCoroutine(Moving());
    }    
    
    public void OnDirectionCheck(bool direction)
    {
        if ((direction && transform.localPosition.x > 0) || (!direction && transform.localPosition.x < 0))
        {
            transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
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
        //impact animation command
        //targetreachevent invokation
    }
}
