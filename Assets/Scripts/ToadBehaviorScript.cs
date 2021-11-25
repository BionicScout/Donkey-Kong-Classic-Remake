using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadBehaviorScript : MonoBehaviour
{
    public float rightSwitch = 1, leftSwitch = 0;
    public float speed = 20f;
    public Rigidbody body;
    int dir = 1;

    void Start()
    {
        body.velocity = new Vector3(0, body.velocity.y, speed * dir);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Switch direction
        if (transform.position.z >= rightSwitch)
        {
            dir = -1;

            Debug.Log("Right");
        }
        else if (transform.position.z <= leftSwitch)
        {
            dir = 1;

            Debug.Log("Left");
        }

       body.velocity = new Vector3(0, body.velocity.y, speed * dir);

        //Rotatate Toad
        if (dir == -1)
            dir = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90 * dir, 0), Time.deltaTime * 30);

        if (dir == 0)
            dir = -1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Toad")
        {
            dir =  dir * -1;
            body.velocity = new Vector3(0, body.velocity.y, speed * dir);
        }
    }

}
