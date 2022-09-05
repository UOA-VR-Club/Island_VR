using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the displays shown in the Attributes pane.
/// </summary>
public class UpdateAttributes : MonoBehaviour
{
    public GameObject Player;

    // Health values for player
    public GameObject ProteinDisplay;
    public GameObject CarbohydrateDisplay;
    public GameObject FatDisplay;
    public GameObject MineralDisplay;
    public GameObject VitaminDisplay;
    public GameObject WaterDisplay;

    /// <summary>
    /// Called once per frame.
    /// Update values shown on the attributes pane per player's health.
    /// </summary>
    private void Update()
    {
        float proteins = Player.GetComponent<Attributes>().Proteins;
        float carbohydrates = Player.GetComponent<Attributes>().Carbohydrates;
        float fats = Player.GetComponent<Attributes>().Fats;
        float minerals = Player.GetComponent<Attributes>().Minerals;
        float vitamins = Player.GetComponent<Attributes>().Vitamins;
        float water = Player.GetComponent<Attributes>().Water;

        ProteinDisplay.GetComponent<Text>().text = proteins.ToString(CultureInfo.InvariantCulture);
        CarbohydrateDisplay.GetComponent<Text>().text = carbohydrates.ToString(CultureInfo.InvariantCulture); 
        FatDisplay.GetComponent<Text>().text = fats.ToString(CultureInfo.InvariantCulture); 
        MineralDisplay.GetComponent<Text>().text = minerals.ToString(CultureInfo.InvariantCulture); 
        VitaminDisplay.GetComponent<Text>().text = vitamins.ToString(CultureInfo.InvariantCulture); 
        WaterDisplay.GetComponent<Text>().text = water.ToString(CultureInfo.InvariantCulture); 
    }
}
