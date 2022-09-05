using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Vibrates the XR controller when the axe hits a GameObject with a Collision attribute.
/// </summary>
[RequireComponent(typeof(XRBaseInteractable))]
public class AxeHapticsProvider : MonoBehaviour
{
    /// <summary>
    /// Called when axe collides with the other GameObject.
    /// </summary>
    /// <param name="other">GameObject with Collision component.</param>
    private void OnCollisionEnter(Collision other)
    {
        XRBaseControllerInteractor hand = (XRBaseControllerInteractor)GetComponent<XRBaseInteractable>().selectingInteractor;
        if (hand is null) return;
        float speed = other.relativeVelocity.magnitude;
        float impulseAmplitude = Clamp(speed, 0.3f, 0.9f);
        float impulseDuration = impulseAmplitude / 3.0f;
        hand.SendHapticImpulse(impulseAmplitude, impulseDuration);
    }

    /// <summary>
    /// Keep the value within min and max bounds.
    /// Thus, if the value is lower than min, the min is returned.
    /// Else, if the value is higher than max, the max is returned.
    /// Finally, if the value is within the min and max, the value is simply returned.
    /// </summary>
    /// <param name="value">The original value.</param>
    /// <param name="min">The minimum for the value.</param>
    /// <param name="max">The maximum for the value.</param>
    /// <returns></returns>
    private static float Clamp(float value, float min, float max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}
