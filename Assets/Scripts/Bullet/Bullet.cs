using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Time (secs) before shell is removed
    public float m_MaxLifeTime = 2f;
    // Amount of damage done if the explosion is centred on a tank
    public float m_MaxDamage = 34f;
    // Maximum distance away from the explosion that tanks can be and still be affected
    public float m_ExplosionRadius = 5f;
    // The amount of force added to a tank at the centre of an explosion
    public float m_ExplosionForce = 100f;

    // A reference to the particles that will play on explosion --- CHANGE TO BULLET PARTICLES
    // public ParticleSystem m_ExplosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        // If not destroyed by maxlifetime, destroy the shell
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Find the rigidbody of the collision object
        Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // Only tanks have rigidbody scripts
        if (targetRigidbody != null)
        {
            // Add an explosion force
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            // Find the tankhealth script associated w/ rigidbody
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (targetHealth != null)
            {
                // Calculate the amount of damage the target should take based on its distance from the shell
                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }
        }

        // Unparent the particles from the shell
        // m_ExplosionParticles.transform.parent = null;
        // Play particle effect
        // m_ExplosionParticles.Play();

        // Destroy the shell
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosion radius) the target is away
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage
        float damage = relativeDistance * m_MaxDamage;

        // Make sure that minimum damage is always 0
        damage = Mathf.Max(0f, damage);

        return damage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
