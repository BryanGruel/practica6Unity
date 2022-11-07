using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquivacion : MonoBehaviour
{
    public float timerIzquierda = 0;
    public float timeBtwShootIzquierda = 2;
    public float timerDerecha = 0;
    public float timeBtwShootDerecha = 3;
    public float speed = 3;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveIzquierda();
        MoveDerecha();
         
    }

    void MoveIzquierda()
    {
        if(timerIzquierda < timeBtwShootIzquierda)
        {
            timerIzquierda += Time.deltaTime;
        }
         else
        {
            timerIzquierda = 0;
            transform.Translate( new Vector3 (-180, 0f, 0f) * speed * Time.deltaTime); 
            Debug.Log("Se movio a la izquierda");
        }
    }

    void MoveDerecha()
    {
       if(timerDerecha < timeBtwShootDerecha)
        {
            timerDerecha += Time.deltaTime;
        }
         else
        {
            timerDerecha = 0;
            transform.Translate( new Vector3 (180, 0f, 0f) * speed * Time.deltaTime); 
            Debug.Log("Se movio a la derecha");
        }
    }
}

