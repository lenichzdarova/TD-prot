using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerTask : MonoBehaviour
{
    private protected AudioSource audioSource;
    [SerializeField] 
    private protected AudioClip audioClip;
    [SerializeField]
    private protected float range;
    [SerializeField]
    private protected float reloadTime;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public abstract bool Execute();
    
    // ����� ���� / itargetprovider/trytofindtarget(bool)    /gettarget(transform)  ///  enemytargetprovider / spawnpointtargetprovider  -
    // � ������ ������ ������ ��� �� ������ ������, �� ������ ����� ������� spawnMark

    //�������� ���������� � ������ �������� /imove  move // ��� ������ ��������
    //���������
}
