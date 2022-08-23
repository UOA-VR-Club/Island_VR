using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAttributes : MonoBehaviour
{
    public GameObject player;
    public GameObject attributes;
    public GameObject proteinValue,carbohydrateValue,fatValue,mineralValue,vitaminValue,waterValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hp = player.GetComponent<Attributes>().healthPoints;
        float proteins = player.GetComponent<Attributes>().proteins;
        float carbohydrates = player.GetComponent<Attributes>().carbohydrates;
        float fats = player.GetComponent<Attributes>().fats;
        float minerals = player.GetComponent<Attributes>().minerals;
        float vitamins = player.GetComponent<Attributes>().vitamins;
        float water = player.GetComponent<Attributes>().water;

        proteinValue.GetComponent<Text>().text = proteins.ToString();
        carbohydrateValue.GetComponent<Text>().text = carbohydrates.ToString(); 
        fatValue.GetComponent<Text>().text = fats.ToString(); 
        mineralValue.GetComponent<Text>().text = minerals.ToString(); 
        vitaminValue.GetComponent<Text>().text = vitamins.ToString(); 
        waterValue.GetComponent<Text>().text = water.ToString(); 
    }
}