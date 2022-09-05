using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    public GameObject StoredItem;
    public Image SlotImage;
    public InputActionReference GripAction = null;
    private Color originalColor;

    /// <summary>
    /// Called before the first frame is updated.
    /// </summary>
    void Start()
    {
        SlotImage = GetComponentInChildren<Image>();
        originalColor = SlotImage.color;
    }

    /// <summary>
    /// Handle Unity message to begin consuming the product.
    /// When the other GameObject touches this Slot GameObject,
    /// put the other GameObject in this Slot, provided that
    /// the other GameObject is an Item and Slot is empty.
    /// </summary>
    /// <param name="other">GameObject with Collider component.</param>
    private void OnTriggerStay(Collider other)
    {
        if (StoredItem != null) return;
        if (!IsItem(other.gameObject)) return;
        if (GripAction.action.ReadValue<float>() == 0f)
            InsertItem(other.gameObject);
    }

    /// <summary>
    /// Handle Unity message to begin consuming the product.
    /// Remove other GameObject from slot, provided that said
    /// GameObject is the one exiting from the slot, and that
    /// the grip on the XR controller has been released.
    /// </summary>
    /// <param name="other">GameObject with Collider component.</param>
    private void OnTriggerExit(Collider other)
    {
        if(!GameObject.ReferenceEquals(StoredItem, other.gameObject)) return;
        if(GripAction.action.ReadValue<float>() != 0f)
            RemoveItem(other.gameObject);
    }

    private bool IsItem(GameObject other)
    {
        return other.GetComponent<Item>();
    }

    private void InsertItem(GameObject other)
    {
        //other.GetComponent<Rigidbody>().isKinematic = true;
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        
        other.transform.SetParent(gameObject.transform, true);
        other.transform.localPosition = Vector3.zero;
        other.transform.localEulerAngles = other.GetComponent<Item>().SlotRotation;
        
        other.GetComponent<Item>().IsInSlot = true;
        other.GetComponent<Item>().CurrentSlot = this;
        
        StoredItem = other;
        SlotImage.color = Color.gray;
    }

    private void RemoveItem(GameObject other)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = false;
        other.transform.parent = null;
        other.GetComponent<Item>().IsInSlot = false;
        other.GetComponent<Item>().CurrentSlot = null;
        StoredItem = null;
        ResetColor();
    }

    private void ResetColor()
    {
        SlotImage.color = originalColor;
    }
}
