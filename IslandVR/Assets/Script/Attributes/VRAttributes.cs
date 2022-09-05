// Script name: AttributesVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.

using UnityEngine;
using UnityEngine.InputSystem;

public class VRAttributes : MonoBehaviour
{
    public GameObject attributes;
    public GameObject anchor;
    bool uiActive;
    public InputActionReference lefthandSecondaryReference = null;

    // when game start, attributes is inactive by default
    private void Start()
    {
        attributes.SetActive(false);
        uiActive = false;
        lefthandSecondaryReference.action.started += OpenAttributes; // attaches the OpenAttributes function to the input action that is referenced. To find the input actions, go to assets, samples, xr interaction toolkit... keep going and then click default input actions
    }

    // changes the attributes position to match the anchor inside left controller
    private void Update()
    {
        if (uiActive)
        {
            attributes.transform.position = anchor.transform.position;
            attributes.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x + 15, anchor.transform.eulerAngles.y, 0);
        }
    }

    //toggles the attributes on or off
    private void OpenAttributes(InputAction.CallbackContext context)
    {
        uiActive = !uiActive;
        attributes.SetActive(uiActive);
    }
}