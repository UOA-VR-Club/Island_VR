using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRBaseInteractable))]
public class Axehit : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.name);
        XRBaseControllerInteractor hand = (XRBaseControllerInteractor)GetComponent<XRBaseInteractable>().selectingInteractor;
        if (hand)
        {
            float speed = other.relativeVelocity.magnitude;
            hand.SendHapticImpulse(Clamp(speed,0.3f,0.9f), Clamp(speed/3.0f, 0.1f, 0.3f));
        }
    }

    public static float Clamp(float value, float min, float max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}
