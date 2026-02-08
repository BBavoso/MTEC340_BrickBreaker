using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private float StartingAngleSpread = 45;

    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
        
    }

    private void ResetBall() {
        transform.position = Vector2.zero;
        
        float angle = Random.Range(-StartingAngleSpread, StartingAngleSpread);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
        _rb.linearVelocity = direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ResetBall();
    }
}
