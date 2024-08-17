using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("SETTINGS")]
    public bool movementByRigidbody = true;

    [Header("REFERENCES")]
    public Animator animatorBasic;
    public Animator animatorGun;

    CharacterController controller;
    Rigidbody rigidbody;
    Keybindings keybidings;

    [Space(20)]
    [Header("VARIABLES ---------------------------")]
    [Header("MOVEMENT")]
    public float xSpeed = 1.0f;
    [Range(1.0f, 5.0f)]
    public float speed = 2.0f;
    [Range(1, 4)]
    public float runSpeed = 3.0f;

    Vector3 moveDir;

    [Space(10)]
    [Header("CHARACTER")]
    public GameObject character;
    
    [Space(10)]
    [Header("EQUIPMENT")]
    public GameObject gun;
    public bool gunEquiped;

    [Space(10)]
    [Header("CAMERAS")]
    public GameObject camera;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        keybidings = GetComponent<Keybindings>();
    }

    void FixedUpdate() 
    {
        if (movementByRigidbody) {
            MoveRB();
        }
    }
    void Update()
    {
        if (!movementByRigidbody) {
            MoveCC();
        }
    }


    public void MoveEvent(InputAction.CallbackContext context){
        Vector2 move = context.ReadValue<Vector2>();
        moveDir = new (move.x, 0, move.y);
    }

    void MoveCC(){
        controller.Move(moveDir * speed * xSpeed * Time.deltaTime);
    }
    void MoveRB(){
        rigidbody.MovePosition(transform.position + moveDir * speed * xSpeed * Time.deltaTime);
    }
    void MovementBasic(){
        WalkForward();
        Run();
    }
        void MovementGun(){
        Reload();
        Aim();
        Shoot();
        ShootAuto();
    }


    void WalkForward(){
        if (Input.GetKey(keybidings.k_forward) || Input.GetKey(keybidings.j_forward)){
            //Animation
            animatorBasic.SetBool("isForward",true);
            //3D Movement
            //Vector3 _move = new Vector3(0, 0, 1); delete
            //CharacterMovement(new Vector3(0, 0, 1), speed);
            //controller.Move(_move * speed * xSpeed * Time.deltaTime); delete
        }
        else {
            //Animation
            animatorBasic.SetBool("isForward",false);
            //3D Movement
        }
    }


    void Run(){
        if (Input.GetKey(keybidings.k_run) || Input.GetKey(keybidings.j_run)){
            animatorBasic.SetBool("isRunning",true);
        }
        else {
            animatorBasic.SetBool("isRunning",false);
        }
    }



    // Gun ---------------------------------------
    void Reload(){
        if (Input.GetKey(keybidings.k_reload) || Input.GetKey(keybidings.j_reload)){
            animatorGun.SetBool("isAiming",true);
        }
        else {
            animatorGun.SetBool("isAiming",false);
        }
    }
    void Aim(){
        if (Input.GetKey(keybidings.k_aim) || Input.GetKey(keybidings.j_aim)){
            animatorGun.SetBool("isAiming",true);
        }
        else {
            animatorGun.SetBool("isAiming",false);
        }
    }
    void Shoot(){
        if (Input.GetKey(keybidings.k_shoot) || Input.GetKey(keybidings.j_shoot)){
            animatorGun.SetBool("isShooting",true);
        }
        else {
            animatorGun.SetBool("isShooting",false);
        }
    }
    void ShootAuto(){
        if (Input.GetKey(keybidings.k_auto) || Input.GetKey(keybidings.j_auto)){
            animatorGun.SetBool("isAuto",true);
        }
        else {
            animatorGun.SetBool("isAuto",false);
        }
    }
}
