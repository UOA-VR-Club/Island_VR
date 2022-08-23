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

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
        lefthandPrimaryReference.action.started += openInventory;
    }

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