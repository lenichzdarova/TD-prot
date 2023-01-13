using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFoundation : MonoBehaviour
{
    [SerializeField] GameObject _highLight; 

    private void Awake()
    {
        _highLight.SetActive(false);       
    }

    private void OnMouseEnter()
    {
        _highLight.SetActive(true);       
    }

    private void OnMouseExit()
    {
        _highLight.SetActive(false);
    }
}
