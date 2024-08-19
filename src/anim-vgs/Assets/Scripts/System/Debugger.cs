using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Debugger : MonoBehaviour
{
    public bool debugGamepadOld = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debugGamepadOld){
            JoystickFunctionalOld();
        }
    }

    void JoystickFunctionalOld(){
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Debug.Log("Gamepad - button 0 [square]");
        }
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            Debug.Log("Gamepad - button 1 [x]");
        }
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Debug.Log("Gamepad - button 2 [cirle]");
        }
        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            Debug.Log("Gamepad - button 3 [L1]");
        }
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("Gamepad - button 4 [R1]");
        }
    }
}
