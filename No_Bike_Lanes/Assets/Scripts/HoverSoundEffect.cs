/*
Attached: Start Screen Button
*/
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSoundEffect : MonoBehaviour, IPointerEnterHandler
{
    // Drag your AudioSource object here in the Inspector
    public AudioSource hoverSound;

    // Method called when the pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && !hoverSound.isPlaying)
        {
            hoverSound.Play();
        }
    }
}
