using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    private static SceneSetup _instance;

    public static SceneSetup Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject); // Setup GameObject'i işaretleyin
    }

    // Sahne ayarlarını başlatmak için gerekli fonksiyonlar buraya eklenebilir

}
