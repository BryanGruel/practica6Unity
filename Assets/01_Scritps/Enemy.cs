using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Rigidbody rb; 
    public float speed = 3;
    public Vector3 directionSpawner1 = new Vector3(0, 0, -1);
    public Vector3 directionSpawner2 = new Vector3(-1, 0, 0);

    public bool VerficacionVelocidad1 = true;
    public bool VerficacionVelocidad2 = true;

    Spawner spawner;
    Spawner2 spawner2;
  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // speed = Random.Range(1 , 5);
        //rb.velocity = directionSpawner1.normalized * speed;
       Verficacion();

    }

    void Verficacion()
    {
        spawner = FindObjectOfType<Spawner>();
        spawner2 = FindObjectOfType<Spawner2>();

        if(VerficacionVelocidad1)
        {
            Debug.Log("Spawner1");
            spawner.CondicionSpawner1();
            rb.velocity = directionSpawner1.normalized * speed;
            VerficacionVelocidad1 = false;
        }

        // else if( VerficacionVelocidad1 == false)
        // {
        //     Debug.Log("Spawner2");
        //     spawner2.CondicionSpawner2();
        //     rb.velocity = directionSpawner2.normalized * speed;
           
        // }
       
    }
       
        
      
    
}
