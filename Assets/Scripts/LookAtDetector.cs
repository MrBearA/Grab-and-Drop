using UnityEngine;
using TMPro; // Only needed if you're using TextMeshPro

public class LookAtDetector : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; // Assign the Main Camera here
    [SerializeField] private Transform dummy; // Assign the Dummy object here
    [SerializeField] private CanvasGroup textCanvasGroup; // Assign the Canvas Group of the text

    [SerializeField] private float maxLookDistance = 10f; // Max distance the player can "see" the dummy
    [SerializeField] private LayerMask layerMask; // Set this to the Dummy's layer to avoid unnecessary raycast hits

    private void Update()
    {
        CheckIfLookingAtDummy();
    }

    private void CheckIfLookingAtDummy()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxLookDistance, layerMask))
        {
            if (hit.transform == dummy)
            {
                ShowText();
                return;
            }
        }

        HideText();
    }

    private void ShowText()
    {
        textCanvasGroup.alpha = 1; // Show text
    }

    private void HideText()
    {
        textCanvasGroup.alpha = 0; // Hide text
    }
}
