using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 7f;
    public Rigidbody Rigidbody => _rigidbody; // rigidbody e okuma izni saglar. Disaridan sadece okunabilir(get). Ancak degistirilemez
    //cünkü set yoktur. Daha sıkı bir kapsülleme yöntemidir.

   // [field: SerializeField] public Rigidbody _rigidbody { get; private set; } // burasi ise inspectorda gözükmesini saglar. disaridan okunabilir
   // ve sınıf icinde degistirilebilir. Private set. 
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
