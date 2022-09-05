using UnityEngine;

public class Attributes : MonoBehaviour
{
    // Starting value for player's health points
    public float HealthPoints = 100;

    // Starting values for player's quality attributes
    public float Speed;
    public float Strength;
    public float Stamina;

    // Starting values for player's health attributes
    public float Proteins = 100;
    public float Carbohydrates = 100;
    public float Fats = 100;
    public float Minerals = 100;
    public float Vitamins = 100;
    public float Water = 100;

    // Game elements, useful to determine when player's health attributes
    // are to be updated
    public float Timer = 0;
    public float DecayTime = 1;

    /// <summary>
    /// Update player's health attributes.
    /// </summary>
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > DecayTime)
        {
            Timer -= DecayTime;
            Water -= 1;
            Minerals -= 1;
            Vitamins -= 1;
            Carbohydrates -= 1;
            Proteins -= 1;
            Fats -= 1;
        }
    }
}
