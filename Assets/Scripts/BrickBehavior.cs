using System;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Ball")) {
            GameBehavior.Instance.BreakBrick();
            Destroy(gameObject);
        }
    }
}
