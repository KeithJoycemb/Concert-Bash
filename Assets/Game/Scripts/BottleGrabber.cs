using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class NewBehaviourScript : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // The XRGrabInteractable component for the bottle
    public DrinkFromBottle drinkFromBottle; // The DrinkFromBottle component for the player

    void Start()
    {
        grabInteractable.onSelectEntered.AddListener(StartDrinking);
    }

    void StartDrinking(XRBaseInteractor interactor)
    {
        drinkFromBottle.StartDrinking();
    }
}
