using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletEnergy : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody rb;
    public Vector3 direction = new Vector3(0, 0, 1); // Se va a mover hacia arriba
    public AudioClip destroySoundEffect;
    public GameObject destroyedEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("Enemy"))
      {
         AudioManager.instance.PlaySFX(destroySoundEffect);
         Instantiate(destroyedEffect, transform.position, destroyedEffect.transform.rotation);
         GameManager.instance.AddPoints();
         Destroy(gameObject);
         Destroy(collision.gameObject);    
       
      }
    }
}
