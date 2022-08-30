using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool inSlot; //boolean for whether it is in a slot
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot; //if inSlot is true, this stores the slot that it is in

}
