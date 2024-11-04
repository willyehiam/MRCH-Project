using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingLetter : MonoBehaviour
{
    // Assign the trigger zones in the Inspector in the order of movement
    [SerializeField] private Transform[] triggerZones;
    private int currentZoneIndex = 0;
    
    void Start()
    {
        // Ensure the letter starts at the first trigger zone
        if (triggerZones.Length > 0 && triggerZones[0] != null)
        {
            transform.position = triggerZones[currentZoneIndex].position;
        }
        else
        {
            Debug.LogWarning("Trigger zones not assigned or missing the first trigger zone.");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if player enters the trigger and if there's another zone to move to
        if (collider.CompareTag("Player") && currentZoneIndex < triggerZones.Length - 1)
        {
            currentZoneIndex++; // Move to the next zone
            transform.position = triggerZones[currentZoneIndex].position; // Snap letter to the next zone
            Debug.Log("Letter moved to zone index: " + currentZoneIndex);
        }
    }
}