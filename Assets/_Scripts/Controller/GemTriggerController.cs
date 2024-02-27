using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            UIManager.instance.UpdateGem(100);
            Debug.Log("Gold toplandi");
        }
    }

}
