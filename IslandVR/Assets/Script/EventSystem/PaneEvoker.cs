using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attaches to the Event System GameObject to allow any pane to be enabled or disabled.
/// </summary>
public class PaneEvoker : MonoBehaviour
{
    public GameObject Pane;
    public GameObject Anchor;
    public InputActionReference ActionButton;
    private bool isPaneActive;

    /// <summary>
    /// Called before the first frame is updated.
    /// When the game starts, the pane is inactive by default.
    /// </summary>
    private void Start()
    {
        isPaneActive = false;
        Pane.SetActive(isPaneActive);

        // Attaches OpenAttributes function to input action that is referenced.
        // The input action refers to a particular event that occurs when a specific control
        // in the XR controller has been triggered, such as a button press in the left hand.
        // To find the input actions,
        // go to "Assets/Samples/XR Interaction Toolkit/2.0.0-pre.6/Default Input Actions/XRI...Actions.inputactions".
        ActionButton.action.started += TogglePane;
    }

    /// <summary>
    /// Change the pane position to match anchor inside XR controller.
    /// </summary>
    private void Update()
    {
        if (!isPaneActive) return;
        Pane.transform.position = Anchor.transform.position;
        Pane.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
    }

    /// <summary>
    /// Toggle pane on or off.
    /// </summary>
    /// <param name="context"></param>
    private void TogglePane(InputAction.CallbackContext context)
    {
        isPaneActive = !isPaneActive;
        Pane.SetActive(isPaneActive);
    }
}
