using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attaches to the Event System to allow the Attributes pane to be enabled or disabled.
/// </summary>
public class VRAttributes : MonoBehaviour
{
    public GameObject AttributesPane;
    public GameObject AttributesAnchor;
    public InputActionReference LeftHandSecondaryButton;
    private bool uiActive;

    /// <summary>
    /// Called before the first frame is updated.
    /// When the game starts, Attributes pane is inactive by default.
    /// </summary>
    private void Start()
    {
        uiActive = false;
        AttributesPane.SetActive(false);

        // Attaches OpenAttributes function to input action that is referenced.
        // The input action refers to a particular event that occurs when a specific control
        // in the XR controller has been triggered, such as a button press in the left hand.
        // To find the input actions,
        // go to "Assets/Samples/XR Interaction Toolkit/2.0.0-pre.6/Default Input Actions/XRI...Actions.inputactions".
        LeftHandSecondaryButton.action.started += ToggleAttributesPane;
    }

    /// <summary>
    /// Change the Attributes pane position to match anchor inside left controller.
    /// </summary>
    private void Update()
    {
        if (!uiActive) return;
        AttributesPane.transform.position = AttributesAnchor.transform.position;
        AttributesPane.transform.eulerAngles = new Vector3(AttributesAnchor.transform.eulerAngles.x + 15, AttributesAnchor.transform.eulerAngles.y, 0);
    }

    /// <summary>
    /// Toggle attributes pane on or off.
    /// </summary>
    /// <param name="context"></param>
    private void ToggleAttributesPane(InputAction.CallbackContext context)
    {
        uiActive = !uiActive;
        AttributesPane.SetActive(uiActive);
    }
}
