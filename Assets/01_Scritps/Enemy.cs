using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Rigidbody rb; 
    public float speed = 4;
    public Vector3 direction = new Vector3(0, 0, -1);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1 , 5);
        rb.velocity = direction.normalized * speed;
    }
}
