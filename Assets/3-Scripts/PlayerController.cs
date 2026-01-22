using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveInput;
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
