using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public GameManager.GameState triggerState; // Bu trigger'ın tetikleyeceği durum (Win veya Lose)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) // "Player" tag'ine sahip nesnelerle etkileşimi kontrol eder
        {
            GameManager.instance.SetGameState(triggerState);
        }
    }
}
