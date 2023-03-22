using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletInteraction : MonoBehaviour
{
    public GameObject tablet; // The tablet game object
    public float interactionDistance = 1.5f; // The distance at which the tablet can be interacted with
    public LayerMask interactionLayer; // The layer(s) on which the tablet can be interacted with

    private bool isInteracting = false; // Whether the player is currently interacting with the tablet

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteracting) // Check if the player presses the interaction key and isn't already interacting
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayer)) // Cast a ray forward from the player to check if the tablet is within interaction range
            {
                if (hit.collider.gameObject == tablet) // Check if the hit object is the tablet
                {
                    isInteracting = true;
                    
                }
            }
        }

        if (isInteracting && Input.GetKeyDown(KeyCode.Escape)) // Check if the player presses the escape key while interacting
        {
            isInteracting = false;
            
        }
    }

    public void LoadScene(string sceneName) // Called from the tablet UI to load a scene
    {
        if (isInteracting)
        {
            isInteracting = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
