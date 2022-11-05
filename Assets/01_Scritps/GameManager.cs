using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int points=0;
    public TMP_Text pointsTxt;
    public static GameManager instance;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    public void AddPoints()
    {
      points++;
      pointsTxt.text = "Points " + points.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        pointsTxt.text = "Points " + points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
