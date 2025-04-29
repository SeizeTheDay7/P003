using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] InputActionReference mv;
    [SerializeField] GameObject planet;
    [SerializeField] float fallSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    float verticalVel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Fall();
        Rotate();
        Move();
    }

    private void Fall()
    {
        verticalVel = -10f;
        // else verticalVel -= fallSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector3 upDir = (transform.position - planet.transform.position).normalized;
        Quaternion targetRot = Quaternion.FromToRotation(transform.up, upDir) * transform.rotation;
        transform.rotation = targetRot;
    }

    private void Move()
    {
        Vector2 movement = mv.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y).normalized;
        move = transform.TransformDirection(move) * moveSpeed;
        move += verticalVel * transform.up;
        rb.linearVelocity = move;
        // Debug.DrawRay(transform.position, move, Color.red, 2f);
    }
}
