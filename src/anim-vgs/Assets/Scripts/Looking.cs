using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Looking : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Vector2Dampener lookVector;

    [Range(0.0f, 1.0f)]
    public float sensitivity = 1;
    
    public void Look(InputAction.CallbackContext ctx)
    {
        lookVector.Target = (ctx.ReadValue<Vector2>() / new Vector2(Screen.width, Screen.height));
        //lookVector.Target = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }

    private void Update()
    {
        lookVector.Update();
        camera.RotateAround(transform.position, transform.up, lookVector.Value.x * sensitivity * 360);
    }
}
