using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public List<GameObject> items;
    float timer = 0;
    public float timeBtwSpawn = 4;

    public bool ActivadoSpawner1 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
        if(timer >= timeBtwSpawn)
        {
            timer = 0;
            float x = Random.Range(point1.position.x, point2.position.x);
            float z = Random.Range(point1.position.z, point2.position.z);
            Vector3 pos = new Vector3(x, transform.position.y, transform.position.z);
            Instantiate(items[Random.Range(0, items.Count)], pos, Quaternion.identity);
            CondicionSpawner1();
        }
    }


    public void CondicionSpawner1()
    {
      ActivadoSpawner1 = true;
    }
}
