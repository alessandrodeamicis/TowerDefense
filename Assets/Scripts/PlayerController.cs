using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    Rigidbody _rb;
    float inputX;
    float inputY;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3(inputX, 0f, inputY) * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + move);
    }
}
