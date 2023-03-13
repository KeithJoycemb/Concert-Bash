using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrinkFromBottle : MonoBehaviour
{
    public float sipAmount = 0.1f; // The amount to sip from the bottle
    public float sipInterval = 1.0f; // The interval between sips
    public float sipDuration = 1.0f; // The duration of the sip animation
    public float bottleAngleThreshold = 45.0f; // The angle threshold for the bottle to be tilted before sipping
    public GameObject bottleObject; // The GameObject representing the bottle
    public Animator animator; // The Animator component for the player
    public UnityEvent onSip; // The UnityEvent to trigger when the player sips from the bottle

    private bool isSipping = false; // Flag to indicate whether the player is currently sipping
    private float sipTimer = 0.0f; // Timer to keep track of sip intervals

    public void StartDrinking()
    {
        animator.SetBool("isDrinking", true);
        Invoke("StopDrinking", 2f);
        onSip.Invoke();
    }

    void StopDrinking()
    {
        animator.SetBool("isDrinking", false);
    }

    void Update()
    {
        // Get the current angle of the bottle
        float angle = Mathf.Abs(Vector3.Angle(Vector3.up, bottleObject.transform.up));

        // Check if the bottle is tilted enough to trigger a sip
        if (angle > bottleAngleThreshold)
        {
            // Start the sip animation if not already sipping and the interval has passed
            if (!isSipping && sipTimer >= sipInterval)
            {
                animator.SetTrigger("Drink"); // Trigger the drink animation
                isSipping = true; // Set the sipping flag
                sipTimer = 0.0f; // Reset the sip timer
            }

            // If sipping, increment the timer and decrease the bottle fill amount
            if (isSipping)
            {
                sipTimer += Time.deltaTime; // Increment the sip timer

                // If the sip animation is complete, reset the sipping flag and trigger the event
                if (sipTimer >= sipDuration)
                {
                    isSipping = false;
                    onSip.Invoke(); // Trigger the UnityEvent
                }
            }
        }
        else
        {
            // Reset the sip timer if the bottle is not tilted enough
            sipTimer = 0.0f;
        }
    }
}
