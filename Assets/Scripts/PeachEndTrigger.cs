using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachEndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.objComplete();
    }
}
