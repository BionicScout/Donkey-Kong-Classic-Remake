using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody DKbody;
    public float speed = 3.5f;
    public float jump = 3f;
    public float rotateSpeed = 3f;

    bool direction = false; //true = left, false = right



    void Update() {
        //Update button press
        float currentSpeed = 0; ;

        if (Input.GetKey(KeyCode.D)) {
            currentSpeed = speed;
            if (direction)
            {
                direction = false;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = -1 * speed;

            if (!direction)
            {
                direction = true;
            }
        }

        DKbody.velocity = new Vector3(0, DKbody.velocity.y, currentSpeed);



        int dir = 1;

        if (direction)
        {
            dir = 0;
        }

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion change = Quaternion.Euler(0, 180 * dir, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, change, Time.deltaTime * rotateSpeed);

        //Update Jump
        if (Input.GetKeyDown(KeyCode.W) && DKbody.velocity.y == 0)
        {
            DKbody.AddForce(0, jump, 0, ForceMode.Acceleration);
        }

        Debug.Log(DKbody.velocity.y);
    }
}
