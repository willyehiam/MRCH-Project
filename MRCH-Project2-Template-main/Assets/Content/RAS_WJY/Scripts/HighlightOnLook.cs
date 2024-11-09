using UnityEngine;

public class HighlightOnLook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject[] sprites; // Array of sprites to detect
    [SerializeField] private GameObject[] highlightOutlines; // Array of highlight outlines
    [SerializeField] private LayerMask spriteLayerMask; // LayerMask for sprites

    private GameObject currentHighlighted;

    void Start()
    {
        // Ensure all highlight outlines are disabled initially
        if (highlightOutlines.Length != sprites.Length)
        {
            Debug.LogError("The number of highlight outlines must match the number of sprites.");
            return;
        }

        foreach (var outline in highlightOutlines)
        {
            if (outline != null)
                outline.SetActive(false);
        }
    }

    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera is not assigned.");
            return;
        }

        // Perform a 3D raycast from the center of the camera's view
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, spriteLayerMask))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

            // Check if the hit object is one of the sprites
            for (int i = 0; i < sprites.Length; i++)
            {
                if (hit.collider.gameObject == sprites[i])
                {
                    // Enable the highlight outline for the looked-at sprite
                    if (currentHighlighted != highlightOutlines[i])
                    {
                        DisableAllOutlines();
                        highlightOutlines[i].SetActive(true);
                        currentHighlighted = highlightOutlines[i];
                    }
                    return;
                }
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any sprite.");
        }

        // Disable highlight if looking away from all sprites
        DisableAllOutlines();
        currentHighlighted = null;
    }

    private void DisableAllOutlines()
    {
        foreach (var outline in highlightOutlines)
        {
            if (outline != null)
                outline.SetActive(false);
        }
    }
}
