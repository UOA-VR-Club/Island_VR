using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Consumable : MonoBehaviour
{
    //elements are indexed from 0 to 5, referring to protein,carbohydrate,fat,mineral,vitamin,water respectively
    public int[] nutrientValues = new int[6];
    public GameObject player;
    public AudioSource eatSound;
    public InputActionReference activateButton = null;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Main Camera" && activateButton.action.ReadValue<float>() != (float)0)
        {
            consume();
        }
    }

    public void consume()
    {
        //change player nutrient values
        player.GetComponent<Attributes>().proteins += nutrientValues[0];
        player.GetComponent<Attributes>().carbohydrates += nutrientValues[1];
        player.GetComponent<Attributes>().fats += nutrientValues[2];
        player.GetComponent<Attributes>().minerals += nutrientValues[3];
        player.GetComponent<Attributes>().vitamins += nutrientValues[4];
        player.GetComponent<Attributes>().water += nutrientValues[5];

        
        //play eating sound
        //eatSound.Play();


        //make consumable disappear
        this.gameObject.SetActive(false);
    }
}
