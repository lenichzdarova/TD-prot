using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public abstract class MovingBehaviour : MonoBehaviour
{
    [SerializeField]
    private protected float moveSpeed;
    private protected TargetCoordinatesProvider targetProvider;
    private protected Vector3 startPositionLocal; //���������� ��� �������� ������� �� ��������. ���� �� ���� ���� ��������

    public abstract void Move();

    public virtual void Initialize(TargetCoordinatesProvider targetProvider)
    {
        this.targetProvider = targetProvider;
        startPositionLocal = transform.localPosition;
    }
}
