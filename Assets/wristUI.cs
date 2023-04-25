using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class wristUI : MonoBehaviour
{
    public InputActionAsset InputActions;
    private Canvas _wristUICanvas;
    private InputAction _menu;
    // Start is called before the first frame update
    private void Start()
    {
        _wristUICanvas = GetComponent<Canvas>();
        _menu = InputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Menu");
        _menu.performed += ToggleMenu;
    }
    private void OnDestroy()
    {
        _menu.performed -= ToggleMenu;
    }
    public void ToggleMenu(InputAction.CallbackContext context)
    {
        _wristUICanvas.enabled = !_wristUICanvas.enabled;
    }
}
