using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColor : MonoBehaviour
{
    //arbitrary material, to be connected in inspector.
    private MeshRenderer meshRenderer = null;
    public InputActionReference activate = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float value = activate.action.ReadValue<float>();
        changeColour(value);
    }
    private void changeColour(float value)
    {
        meshRenderer.material.color = new Color(value, value, value);
    }
}