using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] float speed;
    Transform target;
    [SerializeField] float radius;
    [SerializeField] GameObject ImpactVFX;

    private void Update()
    {
        if(target!= null)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = position;
            if (transform.position == target.position)
            {
                Instantiate(ImpactVFX, target.position, ImpactVFX.transform.rotation);
                Collider[] hit = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Enemy"));
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        else
        {
            gameObject.SetActive(false);
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Initialize(Transform target)
    {
        this.target = target;
        gameObject.SetActive(true);
    }
}
