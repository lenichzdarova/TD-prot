
using UnityEngine;

public class MovingBallisticBehaviour : MovingBehaviour
{    
    private float _radius;
    private float _distanceToApogee;
    private Vector3 _linearPosition;
    [SerializeField]
    private float _heighModifier = 3f;

    public override Vector3 GetMovePoint()
    {        
            Vector3 tempLinearPosition = _linearPosition;
            _linearPosition = Vector3.MoveTowards(tempLinearPosition, _targetProvider.GetTargetPoint(), _moveSpeed * Time.deltaTime);
            if (_linearPosition == _targetProvider.GetTargetPoint())
            {
                return _linearPosition;
            }
            float moveDelta = Vector3.Distance(tempLinearPosition, _linearPosition);
            _distanceToApogee -= moveDelta;            
            float cannonballHeigh;
            if (_distanceToApogee == 0)
            {
                cannonballHeigh = _radius;
            }
            else if (Mathf.Abs(_distanceToApogee) >= _radius)
            {
                cannonballHeigh = 0;
            }
            else
            {
                cannonballHeigh = Mathf.Sqrt(_radius * _radius - _distanceToApogee * _distanceToApogee);
            }

            Vector3 position = new Vector3(_linearPosition.x, _linearPosition.y + cannonballHeigh*_heighModifier, _linearPosition.z);
            return  position;              
    }    

    public override void Initialize(TargetCoordinatesProvider targetProvider, float moveSpeed)
    {                
        _targetProvider = targetProvider;
        _moveSpeed = moveSpeed;
        _linearPosition = transform.position;
        _radius = Vector3.Distance(transform.position, targetProvider.GetTargetPoint())/2;   
        _distanceToApogee = _radius;        
    }
}
