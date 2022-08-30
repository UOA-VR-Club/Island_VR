using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot; //stores item that is in this slot
    public Image slotImage;
    Color originalColour;
    public InputActionReference activateReference = null; //this inputactionreference is linked to the grip action. To find the input actions, go to assets, samples, xr interaction toolkit... keep going and then click default input actions


    // Start is called before the first frame update
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColour = slotImage.color;
    }

    // When 'other' gameobject touches this gameobject (the slot), if it is an item and if this slot is empty, then put that gameobject into this slot
    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        if (!IsItem(other.gameObject)) return;
        if(activateReference.action.ReadValue<float>() == (float) 0)
        {
            InsertItem(other.gameObject);
        }
    }

    // If the item exiting is the one that was in the slot, then call the remove item function. the action.ReadValue is checking that the grip is released
    private void OnTriggerExit(Collider other)
    {
        if(!GameObject.ReferenceEquals(ItemInSlot, other.gameObject)) return;
        if(activateReference.action.ReadValue<float>() != (float) 0)
        {
            RemoveItem(other.gameObject);
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        obj.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        slotImage.color = Color.gray;
    }

    void RemoveItem(GameObject obj)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.transform.parent = null;
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        ItemInSlot = null;
        ResetColor();
    }

    public void ResetColor()
    {
        slotImage.color = originalColour;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
