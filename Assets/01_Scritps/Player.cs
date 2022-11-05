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
    public bool alive = true;
    public GameObject gameOverPanel;
    public GameObject DamageLifePanel;
    public Transform player;
    public float x;
    public float y;
    float sensivity = 50f;
    public bool gyroEnabled = true;
    Vector2 dir = Vector2.zero; //inicia los valores en x en cero y Y en cero
    Inputs inputs;
    public GameObject bulletPrefab;
    public GameObject bulletEnergyPrefab;
    public Transform firePoint;
    public Animator redPanel;

    //Barra de vida
    public Image lifeBar;
    float maxLife = 15;
    float life = 14;

    //Barra de Energia de poder
    public Image EnergyBar;
    float maxEnergy = 15;
    float Energy = 14;
    public float timer = 0;
    public float timeBtwShoot = 2;
    public bool canShoot = false;
    public bool bombaActivada = false;


     void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Movement.performed += ctx => dir = ctx.ReadValue<Vector2>(); //si presiono algo
        inputs.Player.Movement.canceled += ctx => dir = Vector2.zero; // si no estoy presionando nada
        inputs.Player.Attack.performed += ctx => Attack();
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
        lifeBar.fillAmount = life / maxLife; 
        EnergyBar.fillAmount = Energy / maxEnergy; 
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
         BullEnergy();
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
        Debug.Log("damage");
        redPanel.SetTrigger("damage");
        DamageLifePanel.SetActive(true);
        life--;
        lifeBar.fillAmount = life / maxLife; 
        if(life <=1)
        {
            Debug.Log("gameover");
            StartCoroutine(ShowGameOver());
        }
    }


    public void Attack()
    {
      if(bombaActivada == false)
      {
         Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      }
      else if (bombaActivada == true)
      {
        Instantiate(bulletEnergyPrefab, firePoint.position, firePoint.rotation); 
        bombaActivada = false;
      }

    }

    public void BullEnergy()
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
            Energy--;
            EnergyBar.fillAmount = Energy / maxEnergy; 
              if(Energy <=1)
              {
                bombaActivada = true;
                Energy = 14;
              }
           }
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
        DamageLifePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        DamageLifePanel.SetActive(false);
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
        } 
    }
 
}
