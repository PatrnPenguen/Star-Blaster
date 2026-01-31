using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveInput;
    InputAction fireInput;
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 10f;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    [SerializeField] float paddingX = 1.5f;
    [SerializeField] float paddingY = 2f;
    [SerializeField] float paddingYBottom = 4f;
    
    Shooter playerShooter;
    void Start()
    {
        playerShooter = GetComponent<Shooter>();
        moveInput = InputSystem.actions.FindAction("Move");
        fireInput = InputSystem.actions.FindAction("Fire");
        SetupBounds();
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
    }

    void SetupBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector *  moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + paddingX, maxBounds.x -  paddingX);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + paddingYBottom, maxBounds.y -  paddingY);
        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireInput.IsPressed();
    }
}
