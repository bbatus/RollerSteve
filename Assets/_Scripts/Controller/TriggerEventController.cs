using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public GameState triggerState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            GameManager.instance.SetGameState(triggerState);
        }
    }
}
