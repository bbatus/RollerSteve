using UnityEngine;
public class Jumper : MonoBehaviour
{
    [SerializeField]
    private float _jumpForceMultiplier = 10f;
    [SerializeField]
    private float _jumpHeight = 2f;

    private ParticleSystem _effect;

    private void Start()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerExit(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Rigidbody playerRigidbody = playerController.Rigidbody;
            if (playerRigidbody != null)
            {
                playerRigidbody.AddExplosionForce(_jumpForceMultiplier, transform.position, 3, _jumpHeight, ForceMode.Impulse);
                _effect.Play();
            }
        }
    }
}
