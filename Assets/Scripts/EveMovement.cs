using UnityEngine;

public class EveMovement : MonoBehaviour {
    private float speed = 1f;
    private Vector2 direction = Vector2.right;
    private bool isFighting = false;
    public void Init(float moveSpeed, bool moveLeft = false) {
        speed = moveSpeed;
        direction = moveLeft ? Vector2.left : Vector2.right;
    }

    void Update() {
        if (!isFighting) {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void PauseMovement(bool pause) {
        isFighting = pause;
    }
}
