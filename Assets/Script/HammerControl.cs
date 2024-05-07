using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class HammerController : MonoBehaviour
{
    public AudioSource hitAudioSource;
    public AudioClip hitClip;
    public XRNode controllerNode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mole"))
        {
            hitAudioSource.PlayOneShot(hitClip);
            StartCoroutine(TriggerHapticFeedback(0.08f));
        }
    }
    IEnumerator TriggerHapticFeedback(float duration)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        if (device.isValid)
        {
            float startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                device.SendHapticImpulse(0, 0.5f, duration);
                yield return null;
            }
        }
    }
    
}
