// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class VRInventory : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;
    public InputActionReference lefthandPrimaryReference = null;

    // when game start, inventory is inactive by default
    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
        lefthandPrimaryReference.action.started += openInventory; // attaches the openInventory function to the input action that is referenced. To find the input actions, go to assets, samples, xr interaction toolkit... keep going and then click default input actions
    }

    // changes the inventory position to match the anchor inside left controller
    private void Update()
    {
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }

    //toggles the inventory on or off
    private void openInventory(InputAction.CallbackContext context)
    {
        UIActive = !UIActive;
        Inventory.SetActive(UIActive);
    }
}