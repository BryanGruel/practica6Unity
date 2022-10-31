using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public LayerMask interactionLayer; 
    public float rayDistance = 40;

    //Para disparar
    public bool canShoot = false;
    public float timer = 0;
    public float timeBtwShoot = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, rayDistance, interactionLayer, QueryTriggerInteraction.Collide))
         {
            Debug.Log("Encontre un objeto");
            if(hit.collider.gameObject.CompareTag("Enemy"))
            {
                Attack();    
            }
         }
        
    }


   public void Attack()
    {
       if(canShoot)
        {
          if(timer < timeBtwShoot)
           {
            timer += Time.deltaTime;
           }
           else
           {
            timer = 0;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
           }
        }      
    }

}
