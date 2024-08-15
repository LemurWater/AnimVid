using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("REFERENCES")]
    public Animator animator;

    CharacterController controller;
    Keybindings keybidings;

    [Space(20)]
    [Header("VARIABLES ---------------------------")]
    [Header("MOVEMENT")]
    [Range(3, 6)]
    public float xSpeed = 1.0f;
    public float speed = 15f;
    public float runSpeed = 3.0f;

    [Space(10)]
    [Header("CHARACTER")]
    public GameObject character;
    
    [Space(10)]
    [Header("EQUIPMENT")]
    public GameObject gun;

    [Space(10)]
    [Header("CAMERAS")]
    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        keybidings = GetComponent<Keybindings>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    void Walk() {
        Forward();
        Backwards();
        Run();
    }

    void CharacterMovement(Vector3 direction, float _speed) {
        controller.Move(direction * _speed * xSpeed * Time.deltaTime);
    }
    void Forward(){
        if (Input.GetKey(keybidings.forward_k) || Input.GetKey(keybidings.forward_j)){
            //Animation
            animator.SetBool("isForward",true);
            //3D Movement
            //Vector3 _move = new Vector3(0, 0, 1); delete
            CharacterMovement(new Vector3(0, 0, 1), speed);
            //controller.Move(_move * speed * xSpeed * Time.deltaTime); delete
        }
        else {
            //Animation
            animator.SetBool("isForward",false);
            //3D Movement
        }
    }
    void Backwards(){
        if (Input.GetKey(keybidings.backwards_k) || Input.GetKey(keybidings.backwards_j)){
            //Animation
            animator.SetBool("isBackwards",true);
            //3D Movement
            Vector3 _move = new Vector3(0, 0, -1);
            controller.Move(_move * speed * xSpeed * Time.deltaTime);
        }
        else {
            //Animation
            animator.SetBool("isBackwards",false);
            //3D Movement
            Vector3 _move = new Vector3(0, 0, 0);
            controller.Move(_move);
        }
    }

    void Run(){
        if (Input.GetKey(keybidings.run_k) || Input.GetKey(keybidings.run_j)){
            animator.SetBool("isRunning",true);
        }
        else {
            animator.SetBool("isRunning",false);
        }

    }
}
