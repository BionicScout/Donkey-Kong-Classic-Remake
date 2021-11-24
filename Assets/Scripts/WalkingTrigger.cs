using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTrigger : MonoBehaviour {

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Animator>().Play("DonkeyKong-WalkingAnimation");
        }
    }
}
