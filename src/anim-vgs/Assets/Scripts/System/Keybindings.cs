using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybindings : MonoBehaviour
{    
    [Space(10)]
    [Header("KEY MAPPING -----------------------------------------------------------")]
    [Header("KEYBOARD")]
    [Header("Basic")]
    public KeyCode k_forward = KeyCode.W;
    public KeyCode k_backwards = KeyCode.S;

    public KeyCode k_run = KeyCode.LeftShift;
    [Header("Gun ----------------")]
    public KeyCode k_reload = KeyCode.R;
    public KeyCode k_aim = KeyCode.Mouse1;
    public KeyCode k_shoot = KeyCode.Mouse0;
    public KeyCode k_auto = KeyCode.Mouse0;


    [Space(5)]
    [Header("JOYSTICK --------------------------")]
    [Header("Basic")]
    public KeyCode j_forward = KeyCode.JoystickButton0;
    public KeyCode j_backwards = KeyCode.JoystickButton1;

    public KeyCode j_run = KeyCode.JoystickButton2;
    [Header("Gun ----------------")]
    public KeyCode j_reload = KeyCode.JoystickButton5;
    public KeyCode j_aim = KeyCode.JoystickButton3;
    public KeyCode j_shoot = KeyCode.JoystickButton4;
    public KeyCode j_auto = KeyCode.JoystickButton5;
}
