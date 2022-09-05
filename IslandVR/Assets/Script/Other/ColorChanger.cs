using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    public InputActionReference ActivateControl;

    // Arbitrary material, to be connected in inspector
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float value = ActivateControl.action.ReadValue<float>();
        meshRenderer.material.color = new Color(value, value, value);
    }
}
