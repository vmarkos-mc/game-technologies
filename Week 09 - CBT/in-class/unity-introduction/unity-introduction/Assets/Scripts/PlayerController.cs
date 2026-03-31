using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private readonly float STEP = 0.1f;
    // TODO: Refactor this by using a single Move InputAction and four bindings!
    public InputAction LeftAction;
    public InputAction RightAction;
    public InputAction UpAction;
    public InputAction DownAction;

    void Start()
    {
        LeftAction.Enable(); // Enables the left action, i.e., movement towards left (west)
        RightAction.Enable();
        UpAction.Enable();
        DownAction.Enable();
    }

    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;
        if (LeftAction.IsPressed())
            horizontal -= 1.0f;
        else if (RightAction.IsPressed())
            horizontal += 1.0f;
        if (UpAction.IsPressed())
            vertical += 1.0f;
        else if (DownAction.IsPressed())
            vertical -= 1.0f;
        Vector2 position = transform.position; // Vector2 is just a 2-tuple of floats
        position.x += STEP * horizontal; // position.x = position.x + 0.1f
        position.y += STEP * vertical; // Update vertical movement
        transform.position = position;
    }
}
