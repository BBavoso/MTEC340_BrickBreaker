using System;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {
    private int _lives = 3;
    private SpriteRenderer _renderer;

    private void Start() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.transform.CompareTag("Ball")) return;
        switch (_lives) {
            case 3:
                _lives--;
                _renderer.color = Color.dodgerBlue;
                AudioController.Instance.PlayBrickBounce();
                break;
            case 2:
                _lives--;
                _renderer.color = Color.softRed;
                AudioController.Instance.PlayBrickBounce();
                break;
            case 1:
                GameBehavior.Instance.BreakBrick();
                AudioController.Instance.PlayBrickBreak();
                Destroy(gameObject);
                break;
        }
    }
}
