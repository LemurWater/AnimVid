using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybindings : MonoBehaviour
{    
    [Space(10)]
    [Header("KEY MAPPING")]
    [Header("KEYBOARD")]
    public KeyCode forward_k = KeyCode.W;
    public KeyCode backwards_k = KeyCode.S;
    
    public KeyCode run_k = KeyCode.LeftShift;
 
    [Space(5)]
    [Header("JOYSTICK")]
    public KeyCode forward_j = KeyCode.JoystickButton0;
    public KeyCode backwards_j = KeyCode.JoystickButton1;

    public KeyCode run_j = KeyCode.JoystickButton2;
}
