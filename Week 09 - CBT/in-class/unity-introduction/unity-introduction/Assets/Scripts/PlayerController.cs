using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private readonly float STEP = 0.1f;
    public InputAction MoveAction;

    void Start()
    {
        MoveAction.Enable();
    }

    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2) transform.position + move * STEP;
        transform.position = position;
    }
}
