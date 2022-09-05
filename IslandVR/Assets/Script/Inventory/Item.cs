using UnityEngine;

/// <summary>
/// Stores information about the state of a GameObject,
/// where the GameObject can be stored in the player's inventory.
/// </summary>
public class Item : MonoBehaviour
{
    // Boolean for whether this GameObject is in a slot
    public bool IsInSlot;

    // If inSlot is true, store the slot that the GameObject belongs to
    public Slot CurrentSlot;

    // Rotate the object as the slot rotates
    public Vector3 SlotRotation = Vector3.zero;
}
