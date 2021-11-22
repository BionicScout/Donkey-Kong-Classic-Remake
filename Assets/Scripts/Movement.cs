using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody DKbody;
    public float speed = 3.5f;
    public float jumpHeight = 3f;
    public float rotateSpeed = 3f;

    bool direction = false; //true = left, false = right
    bool jump = false;



    void Update() {
        //Update sideways motion
        float currentSpeed = 0;

        if (Input.GetKey(KeyCode.D)) {
            currentSpeed = speed;

            if (direction)            
                direction = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = -1 * speed;

            if (!direction)            
                direction = true;
        }

        DKbody.velocity = new Vector3(0, DKbody.velocity.y, currentSpeed);


    //Rotate DK on direction switch
        int dir = 1;

        if (direction)       
            dir = 0;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180 * dir, 0), Time.deltaTime * rotateSpeed);

        //Update Jump
        if (Input.GetKeyDown(KeyCode.W) && !jump)
        {
            DKbody.AddForce(0, jumpHeight, 0, ForceMode.Acceleration);
            jump = true;
        }

        Debug.Log(DKbody.velocity);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Floor"){
            jump = false;
        }
    }
}
