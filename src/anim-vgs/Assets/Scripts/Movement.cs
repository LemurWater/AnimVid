using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("REFERENCES")]
    public Animator animatorBasic;
    public Animator animatorGun;
    public InputActionReference move;
    Vector2 moveDirection;

    CharacterController controller;
    Rigidbody rb;
    Keybindings keybidings;

    [Space(20)]
    [Header("VARIABLES ---------------------------")]
    [Header("MOVEMENT")]
    public float xSpeed = 1.0f;
    [Range(1, 4)]
    public float speed = 1.5f;
    [Range(1, 4)]
    public float runSpeed = 3.0f;

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
        rb = GetComponent<Rigidbody>();
        keybidings = GetComponent<Keybindings>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime);    
    }
    // Update is called once per frame
    void Update()
    {
        //Move();
        moveDirection = move.action.ReadValue<Vector2>();
    }


    void Move() {
        //MovementBasic();
        MovementGun();
    }
    void MovementBasic(){
        WalkForward();
        Backwards();
        Run();
    }
        void MovementGun(){
        Reload();
        Aim();
        Shoot();
        ShootAuto();
    }


    void CharacterMovement(Vector3 direction, float _speed) {
        controller.Move(direction * _speed * xSpeed * Time.deltaTime);
    }
    void WalkForward(){
        if (Input.GetKey(keybidings.k_forward) || Input.GetKey(keybidings.j_forward)){
            //Animation
            animatorBasic.SetBool("isForward",true);
            //3D Movement
            //Vector3 _move = new Vector3(0, 0, 1); delete
            CharacterMovement(new Vector3(0, 0, 1), speed);
            //controller.Move(_move * speed * xSpeed * Time.deltaTime); delete
        }
        else {
            //Animation
            animatorBasic.SetBool("isForward",false);
            //3D Movement
        }
    }
    public void WalkForward2(InputAction.CallbackContext context){
        //moveDirection = move.action.ReadValue<Vector2>();
        //moveDirection = move.action.ReadValue<Vector2>();
        Vector3 _move = new Vector3(0, 0, -1);
        controller.Move(_move * speed * xSpeed * Time.deltaTime);
    }
    void Backwards(){
        if (Input.GetKey(keybidings.k_backwards) || Input.GetKey(keybidings.j_backwards)){
            //Animation
            animatorBasic.SetBool("isBackwards",true);
            //3D Movement
            Vector3 _move = new Vector3(0, 0, -1);
            controller.Move(_move * speed * xSpeed * Time.deltaTime);
        }
        else {
            //Animation
            animatorBasic.SetBool("isBackwards",false);
            //3D Movement
            Vector3 _move = new Vector3(0, 0, 0);
            controller.Move(_move);
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
