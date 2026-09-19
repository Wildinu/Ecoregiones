using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.8f; 

    [Header("Cámara")]
    [SerializeField] private Transform _playerCamera;

    private CharacterController _controller;
    private float _xRotation = 0f;
    private float _verticalVelocity; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Look();
        Move();
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        if (_playerCamera != null)
        {
            _playerCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }

        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        
        if (_controller.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _verticalVelocity += _gravity * Time.deltaTime;

        Vector3 finalVelocity = (move * _moveSpeed) + (Vector3.up * _verticalVelocity);

        _controller.Move(finalVelocity * Time.deltaTime);
    }
}
