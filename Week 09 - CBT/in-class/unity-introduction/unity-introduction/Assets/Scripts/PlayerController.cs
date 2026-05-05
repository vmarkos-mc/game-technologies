using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
    public float STEP = 3.0f;
    public InputAction MoveAction;
    Rigidbody2D rigidBody2d;
    public int maxHealth = 5;
    //public int health { get { return currentHealth;  } }
    public bool hasMaxHealth { get { return currentHealth == maxHealth; } }
    public bool isDead {  get { return currentHealth == 0; } }
    int currentHealth;
    Vector2 move;

    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        rigidBody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                // We do not check for damageCooldown == 0
                // because a sudden FPS drop will deltaTime
                // so damageCooldown might abruptly skip zero
                // and become negative.
                isInvincible = false;
            }
        }
        //Vector2 position = (Vector2) transform.position + move * STEP * Time.deltaTime;
        //transform.position = position;
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidBody2d.position + move * STEP * Time.deltaTime;
        animator.SetFloat("Move X", move[0]);
        animator.SetFloat("Move Y", move[1]);
        rigidBody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        // Mathf.Clamp(x, a, b) ensures that x is in [a, b].
        // Values of x < a are rounded to a.
        // Values of x > b are rounded to b.
        Debug.Log(currentHealth);
    }
}
