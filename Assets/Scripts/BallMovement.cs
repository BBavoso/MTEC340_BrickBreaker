using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float startingAngleSpread = 45;

    private Vector2 direction;

    void Start() {
        float angle = Random.Range(-startingAngleSpread, startingAngleSpread);
        direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
    }

    void Update() {
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
