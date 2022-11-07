using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject EnemyPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(collision.gameObject);
        } 
        if(collision.gameObject.CompareTag("Bullet"))
        {
           
            Destroy(collision.gameObject);
        } 
        if(collision.gameObject.CompareTag("BulletEnergy"))
        {
           
            Destroy(collision.gameObject);
        } 
    }
}
