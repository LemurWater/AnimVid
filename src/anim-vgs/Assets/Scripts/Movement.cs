using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("REFERENCES")]
    public Animator animatorBasic;
    public Animator animatorGun;
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
        //rb.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Print(){
        Debug.Log("Print");
    }
    void Move() {
        //MovementBasic();
        MovementGun();
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
    public void Move(InputAction.CallbackContext context){
        Debug.Log(context);
        Vector2 move = context.ReadValue<Vector2>();
        Vector3  move2 = new (move.x, move.y, 0);
        controller.Move(move2 * speed * xSpeed * Time.deltaTime);
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
