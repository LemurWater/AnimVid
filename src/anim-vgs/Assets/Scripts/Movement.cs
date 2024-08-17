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
    [Range(1.0f, 5.0f)]
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
    public GameObject cam;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        keybidings = GetComponent<Keybindings>();
    }

    void FixedUpdate() 
    {
        if (movementByRigidbody == true) {
            MoveRB();
        }
    }
    void Update()
    {
        if (movementByRigidbody == false) {
            MoveCC();
        }
        CheckAnimations();
    }


    public void MoveEvent(InputAction.CallbackContext context){
        Vector2 move = context.ReadValue<Vector2>();
        Debug.Log(move);
        moveDir = new (move.x, 0, move.y);
        //PrimitiveAnimations();
    }

    void CheckAnimations(){
        if (moveDir.z > 0){
            animatorBasic.SetBool("isForward",true);
            animatorBasic.SetBool("isBackwards",false);
        }if (moveDir.z < 0){
            animatorBasic.SetBool("isForward",false);
            animatorBasic.SetBool("isBackwards",true);
        }else{
            animatorBasic.SetBool("isForward",false);
            animatorBasic.SetBool("isBackwards", false);
        }
        moveDir = new();
        /*
        if (move.x > 0){
            animatorBasic.SetBool("isStrifeLeft",true);
            animatorBasic.SetBool("isStrifeRight", false);
        } else  if (move.x > 0){
            animatorBasic.SetBool("isStrifeLeft",false);
            animatorBasic.SetBool("isStrifeRight", true);
        }else{
            animatorBasic.SetBool("isStrifeLeft",false);
            animatorBasic.SetBool("isStrifeRight", false);
        }*/
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

    void PrimitiveAnimations(){
        WalkForward();
        WalkBackwards();
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
    void WalkBackwards(){
        if (Input.GetKey(keybidings.k_backwards) || Input.GetKey(keybidings.j_backwards)){
            //Animation
            animatorBasic.SetBool("isBackwards",true);
            //3D Movement
            //Vector3 _move = new Vector3(0, 0, 1); delete
            //CharacterMovement(new Vector3(0, 0, 1), speed);
            //controller.Move(_move * speed * xSpeed * Time.deltaTime); delete
        }
        else {
            //Animation
            animatorBasic.SetBool("isBackwards",false);
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
