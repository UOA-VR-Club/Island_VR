using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public float healthPoints = 100;
    public float speed,strength,stamina;
    public float water = 100,minerals = 100,vitamins = 100,carbohydrates = 100,proteins = 100,fats = 100;

    public float timer = 0;
    public float decayTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("player alive");
        timer += Time.deltaTime;

        if(timer > decayTime)
        {
            //Debug.Log("reached timer");
            timer -= decayTime;
            water -= 1;
            minerals -= 1;
            vitamins -= 1;
            carbohydrates -= 1;
            proteins -= 1;
            fats -= 1;
        }
    }
}