using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFoundation : MonoBehaviour
{
    [SerializeField] GameObject highLight; 

    private void Awake()
    {
        highLight.SetActive(false);       
    }

    private void OnMouseEnter()
    {
        highLight.SetActive(true);       
    }

    private void OnMouseExit()
    {
        highLight.SetActive(false);
    }
}
