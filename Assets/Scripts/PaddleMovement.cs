using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    public InputActionReference move;
    public float moveSpeed = 10f;
    
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        _rb.linearVelocityX = move.action.ReadValue<float>() * moveSpeed;
    }
}
