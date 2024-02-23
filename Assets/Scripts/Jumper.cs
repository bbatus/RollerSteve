using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
[SerializeField]
    float ziplamaCarpani, ziplamaYuksekligi;
    ParticleSystem efekt;
    void Start () {
        //AltObjedeki ParticleSystem bileşenine erişiyoruz
        efekt = GetComponentInChildren<ParticleSystem> ();
    }
    //Obje ile diğer diğer objenin çakışması-içiçe geçmesi bittiği anda çalışacak
    void OnTriggerExit (Collider digerObje) {
        //diğer objenin içerisinde KarakterKontrol bileşenine erişmeye çalışıyoruz
        PlayerController karakter = digerObje.GetComponent<PlayerController> ();
        //eğer diğer objeden KarakterKontrol isimli bileşene erişebilirsek 
        //karaktere kuvvet uygulayıp, efekti aktif hale getiriyoruz
        if (karakter != null) {
            karakter.KarakterRgb.AddExplosionForce (ziplamaCarpani, transform.position, 3, ziplamaYuksekligi, ForceMode.Impulse);
          efekt.Play ();
        }
    }
}
