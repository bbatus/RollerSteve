using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance { get; private set; }
    public Transform Target; // Hedef objenin Transform bileşeni
    public Vector3 Offset; // Hedef ile kamera arasındaki mesafe
    public float SmoothTime = 0.3f; // Pozisyonun ne kadar sürede hedefe ulaşacağını belirleyen süre
    private Vector3 velocity = Vector3.zero; // Yumuşak geçiş için kullanılacak hız vektörü

    private void Awake()
    {
        Debug.Log("Camera Awake basladi");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Hedef ile kamera arasındaki başlangıç mesafesini hesapla
        Offset = transform.position - Target.position;
    }

    private void FixedUpdate()
    {
        // Hedefin pozisyonunu ve rotasyonunu takip et
        FollowPosition();
        FollowRotation();
    }

    void FollowPosition()
    {
        // Hedefin pozisyonuna göre kameranın yeni pozisyonunu hesapla
        Vector3 targetPosition = Target.position + Offset;
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    }

    void FollowRotation()
    {
        // Hedefe doğru kameranın rotasyonunu ayarla
        Quaternion targetRotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, SmoothTime * Time.deltaTime);
    }
}
