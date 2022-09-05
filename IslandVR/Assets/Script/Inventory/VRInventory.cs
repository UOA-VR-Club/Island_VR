using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attaches to the Event System to allow the Inventory pane to be enabled or disabled.
/// </summary>
public class VRInventory : MonoBehaviour
{
    public GameObject InventoryPane;
    public GameObject InventoryAnchor;
    public InputActionReference LeftHandPrimaryButton = null;
    private bool uiActive;

    /// <summary>
    /// Called before the first frame is updated.
    /// When the game starts, Inventory pane is inactive by default.
    /// </summary>
    private void Start()
    {
        uiActive = false;
        InventoryPane.SetActive(false);

        // Attaches OpenAttributes function to input action that is referenced.
        // The input action refers to a particular event that occurs when a specific control
        // in the XR controller has been triggered, such as a button press in the left hand.
        // To find the input actions,
        // go to "Assets/Samples/XR Interaction Toolkit/2.0.0-pre.6/Default Input Actions/XRI...Actions.inputactions".
        LeftHandPrimaryButton.action.started += ToggleInventoryPane;
    }

    /// <summary>
    /// Change the Inventory pane position to match anchor inside left controller.
    /// </summary>
    private void Update()
    {
        if (!uiActive) return;
        InventoryPane.transform.position = InventoryAnchor.transform.position;
        InventoryPane.transform.eulerAngles = new Vector3(InventoryAnchor.transform.eulerAngles.x + 15, InventoryAnchor.transform.eulerAngles.y, 0);
    }

    /// <summary>
    /// Toggle attributes pane on or off.
    /// </summary>
    /// <param name="context"></param>
    private void ToggleInventoryPane(InputAction.CallbackContext context)
    {
        uiActive = !uiActive;
        InventoryPane.SetActive(uiActive);
    }
}
