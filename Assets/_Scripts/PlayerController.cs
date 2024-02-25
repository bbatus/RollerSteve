using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 7f;
    public Rigidbody Rigidbody => _rigidbody;
    private Vector3 _inputVector;

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CheckInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _inputVector = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    private void Move()
    {
        //if (_inputVector != Vector3.zero)
        {
            Vector3 movement = _inputVector * _speed * Time.deltaTime;
            _rigidbody.AddForce(movement, ForceMode.VelocityChange);
        }
    }
}
