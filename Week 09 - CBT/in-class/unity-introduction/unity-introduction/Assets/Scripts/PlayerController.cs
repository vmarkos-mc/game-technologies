using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private readonly float STEP = 3.0f;
    public InputAction MoveAction;
    Rigidbody2D rigidBody2d;
    Vector2 move;

    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rigidBody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        //Vector2 position = (Vector2) transform.position + move * STEP * Time.deltaTime;
        //transform.position = position;
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidBody2d.position + move * STEP * Time.deltaTime;
        rigidBody2d.MovePosition(position);
    }
}
