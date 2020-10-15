using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    public float lastAttackTime = 0f;

    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (targetRigidbody != null)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                lastAttackTime = Time.time;

                PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth>();

                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damage);
                }
            }
        }
    }
}
