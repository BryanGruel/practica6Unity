using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=3;
    Inputs inputs;
    Vector2 dir = Vector2.zero; //inicia los valores en x en cero y Y en cero

     void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Movement.performed += ctx => dir = ctx.ReadValue<Vector2>(); //si presiono algo
        inputs.Player.Movement.canceled += ctx => dir = Vector2.zero; // si no estoy presionando nada

    }
    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
    }

   
}
