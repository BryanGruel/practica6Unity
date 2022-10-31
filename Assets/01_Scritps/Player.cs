using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=3;
    public float life = 3;
    public bool alive = true;
    public TMP_Text lifesTxt;
    public GameObject gameOverPanel;
    public GameObject DamageLifePanel;
    public float timer = 0;
    public float timeBtwShoot = 1;
    public Transform player;
    public float x;
    public float y;
    float sensivity = 50f;
    public bool gyroEnabled = true;
    Vector2 dir = Vector2.zero; //inicia los valores en x en cero y Y en cero
    Inputs inputs;

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
        gameOverPanel.SetActive(false);
        lifesTxt.text = "Lifes " + life.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(alive)
       {
         rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);

        if (gyroEnabled)
        {
            x = Input.gyro.rotationRate.x;
            y = Input.gyro.rotationRate.y;
            float xFiltered = FilerGyroValue(x);
               player.RotateAround(transform.position,transform.right, -xFiltered * sensivity * Time.deltaTime);
            float yFiltered = FilerGyroValue(y);
                    player.RotateAround(player.position,transform.up, -yFiltered * sensivity * Time.deltaTime);    
             if(transform.localEulerAngles.x >=26 && transform.localEulerAngles.x <42)
             {
                  player.Translate(Vector3.forward * speed * Time.deltaTime);
                  Debug.Log(transform.eulerAngles.x);
             }
              else if(transform.rotation.x <= -0.3f)
             {
                 player.Translate(Vector3.back * speed * Time.deltaTime);
                 Debug.Log(transform.eulerAngles.x);
             }
         }

       }
    }

    float FilerGyroValue(float axis)
    {
        if (axis < -0.1f || axis > 0.1f)
        {
            return axis;
        } 
        else
        {
             return 0;
        }    
    }


    void TakeDamage()
    {
        life--;
        lifesTxt.text = "Lifes " + life.ToString();
        if(life <= 0)
        {
            Debug.Log("gameover");
            StartCoroutine(ShowGameOver());
        }
    }

    IEnumerator ShowGameOver()
    {
        alive = false;
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
    }

    IEnumerator ShowPanelDamageLife()
    {
        alive = false;
        yield return new WaitForSeconds(0.1f);
        DamageLifePanel.SetActive(true);
    }


    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           TakeDamage();
           Destroy(collision.gameObject);
           DamageLifePanel.SetActive(false);
        } 
    }
 
}
