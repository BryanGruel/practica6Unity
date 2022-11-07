using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody rb;
    public Vector3 direction = new Vector3(0, 0, 1); // Se va a mover hacia arriba
    public AudioClip destroySoundEffect;
    public GameObject destroyedEffect;

    // Start is called before the first frame update
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
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
