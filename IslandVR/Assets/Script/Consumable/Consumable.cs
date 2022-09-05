using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attaches to GameObjects that can modify the player's health attributes.
/// </summary>
public class Consumable : MonoBehaviour
{
    public GameObject Player;
    public AudioSource EatSound;
    public InputActionReference ActivateControl;

    public float Proteins;
    public float Carbohydrates;
    public float Fats;
    public float Minerals;
    public float Vitamins;
    public float Water;

    /// <summary>
    /// Handle Unity message to begin consuming the product.
    /// This Consumable GameObject must be held to the camera such that
    /// its Collider component collides with the camera's Collider component.
    /// Then the player should activate the control to cause consuming this
    /// Consumable GameObject.
    /// </summary>
    /// <param name="other">GameObject with Collider component.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && ActivateControl.action.ReadValue<float>() != (float)0)
        {
            Consume();
        }
    }

    /// <summary>
    /// Tell player to consume this Consumable GameObject.
    /// Hence, the player's health attributes are updated accordingly.
    /// This Consumable GameObject also disappears, as it has been consumed.
    /// </summary>
    private void Consume()
    {
        // Change player nutrient values
        Player.GetComponent<PlayerAttributes>().Proteins += Proteins;
        Player.GetComponent<PlayerAttributes>().Carbohydrates += Carbohydrates;
        Player.GetComponent<PlayerAttributes>().Fats += Fats;
        Player.GetComponent<PlayerAttributes>().Minerals += Minerals;
        Player.GetComponent<PlayerAttributes>().Vitamins += Vitamins;
        Player.GetComponent<PlayerAttributes>().Water += Water;

        // Play eating sound
        //eatSound.Play();

        // Make consumable disappear
        this.gameObject.SetActive(false);
    }
}
