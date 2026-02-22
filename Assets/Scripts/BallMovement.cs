using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour {
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private float StartingAngleSpread = 45;
    [SerializeField] private float PaddleInfluence = .5f;
    [SerializeField] private float SpeedMultiplier = 1.1f;

    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
    }
    
    private void FixedUpdate() {
        _rb.simulated = GameBehavior.Instance.GameState == Utilities.GameState.Playing;
    }

    private void ResetBall() {
        float angle = Random.Range(-StartingAngleSpread, StartingAngleSpread);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
        _rb.linearVelocity = direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameBehavior.Instance.Death();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Paddle")) {
            if (!Mathf.Approximately(other.rigidbody.linearVelocityX, 0)) {
                Vector2 direction = _rb.linearVelocity * (1 - PaddleInfluence) +
                                    PaddleInfluence * other.rigidbody.linearVelocity;
                _rb.linearVelocity = direction.normalized * _rb.linearVelocity.magnitude;
            }
            AudioController.Instance.PlayPaddleBounce();
        } else if (other.transform.CompareTag("Brick")) {
            // Don't play brick bounce, as the brick will play the sound based on health
            // AudioController.Instance.PlayBrickBounce();
        } else {
            // Hitting Wall
            AudioController.Instance.PlayWallBounce();
        }

        _rb.linearVelocity *= SpeedMultiplier;
    }
}