using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class FishingRod : MonoBehaviour
{
    //public InputActionReference ActivateControl;

    public int durability = 100;

    public float throwSpeed = 10f;

    //public GameObject lure;

    //public Transform pivot;

    //private LineRenderer lineRenderer;

    public void Fish()
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

    }

}
