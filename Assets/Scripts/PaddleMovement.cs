using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    public InputActionReference move;
    public float moveSpeed = 10f;

    void Update() {
        transform.Translate(move.action.ReadValue<float>() * moveSpeed * Time.deltaTime, 0, 0);
    }
}
