using UnityEngine;
using UnityEngine.InputSystem;

public class FishingRod : MonoBehaviour
{
    public InputActionReference ActivateControl;

    public int durability = 100;


    private void Fish()
    {
        //Get Fish
        // Not implemented yet

        // Reduce durability
        if (durability > 0)
        {
            durability -= 1;
        }
        else
        {
            // Play destroyed sound
            this.gameObject.SetActive(false);
        }
        

    }

    private void Update()
    {
        if(ActivateControl.action.ReadValue<float>() != (float)0)
        {
            Fish();
        }
    }

}
