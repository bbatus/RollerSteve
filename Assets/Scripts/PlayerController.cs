using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
Rigidbody rgb;
    //dışarıdan erişim için gerekli alan-özellik
    public Rigidbody KarakterRgb {
        get {
            return rgb;
        }
    }
    //kullanıcının kontrolünde kullanacağımız hız değişkeni
    [SerializeField]
    float hiz = 7f;
    void Start () {
        //başlangıça Rigidbody bileşenine erişiyoruz
        rgb = GetComponentInChildren<Rigidbody> ();
    }
    void Update () {
        //Horizontal(A-D tuşları) ve Vertical(W-S tuşları) ile
        //kullanıcıdan komutlar alıyoruz. Bu değerler -1 veya 1 olabiliyor
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");
        //eğer herhangi bir şekilde kullanıcı bize değer gönderiyorsa
        //yani kontrol ettiğimiz axis değerlerinden ikisi de 0 değilse 
        //objeye kuvvet uyguluyoruz
        if (h != 0 || v != 0) {
            Vector3 hareket = new Vector3 (h, 0, v) * hiz;
            rgb.AddForce (hareket);
        }
    }
}