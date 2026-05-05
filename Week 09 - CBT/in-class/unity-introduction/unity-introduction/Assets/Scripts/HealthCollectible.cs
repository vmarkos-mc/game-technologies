using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // other corresponds to the other collision object
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && !controller.hasMaxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
