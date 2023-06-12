using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int damageAmount = 10; // Ilość obrażeń zadawanych przez ten obiekt

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy kolider należy do obiektu Enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Zadajemy obrażenia obiektowi Enemy
            enemy.TakeDamage(damageAmount);
        }
    }
}

