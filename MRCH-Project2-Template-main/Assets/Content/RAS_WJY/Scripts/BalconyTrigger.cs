using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalconyTrigger : MonoBehaviour
{
    // Assign the GameObjects in the Inspector
    [SerializeField] private List<GameObject> assetsToDisplay;

    void Awake()
    {
        if (assetsToDisplay != null && assetsToDisplay.Count > 0)
        {
            // Ensure all assets are initially hidden
            foreach (var asset in assetsToDisplay)
            {
                if (asset != null)
                {
                    asset.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("One or more GameObjects in the list are not assigned.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Assets list is empty or not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (assetsToDisplay != null && assetsToDisplay.Count > 0 && collider.CompareTag("Player"))
        {
            foreach (var asset in assetsToDisplay)
            {
                if (asset != null)
                {
                    asset.SetActive(true); // Show each asset
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (assetsToDisplay != null && assetsToDisplay.Count > 0 && collider.CompareTag("Player"))
        {
            foreach (var asset in assetsToDisplay)
            {
                if (asset != null)
                {
                    asset.SetActive(false); // Hide each asset
                }
            }
        }
    }
}
