using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActions : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Forward(){
        if (Input.GetKeyDown("w")){
            //transform.forward  += speed * Time.deltaTime;
        }
    }
    private void Backwards(){
        if (Input.GetKeyDown("s")){
            //transform.forward  -= speed * Time.deltaTime;
        }
    }
}
