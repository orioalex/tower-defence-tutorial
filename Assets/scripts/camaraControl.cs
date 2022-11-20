using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camaraControl : MonoBehaviour
{
    public float speed = 30f;
    public float panBoarderThickness = 0.95f;
    public static bool doMovement;
    float minY = 10f , maxY = 200f;
    
    void Start()
    {
        transform.position = new Vector3(-15.5f,75.1f,-38f);
        doMovement = true;
    }

    void Update()
    {
        if(doMovement){
            if(Input.GetKey("a") ){
                transform.Translate(Vector3.forward * speed * Time.deltaTime , Space.World);
            }
            if(Input.GetKey("d") ){
                transform.Translate(Vector3.back * speed * Time.deltaTime , Space.World);
            }
            if(Input.GetKey("w") ){
                transform.Translate(Vector3.right * speed * Time.deltaTime , Space.World);
            }
            if(Input.GetKey("s") ){
                transform.Translate(Vector3.left * speed * Time.deltaTime , Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * Time.deltaTime * panBoarderThickness * 5000f;
        pos.y = Mathf.Clamp(pos.y , minY , maxY);
        transform.position = pos;

        if(Input.GetKey("q")){
            MovementSwitch();
        }
    }

    public void MovementSwitch(){
        if(doMovement){
            doMovement = false;
        }
        else{
            doMovement = true;
        }
    }
}
