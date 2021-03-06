﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    GameManager manager;

    // The amount of health each tank starts with
    public float m_StartingHealth = 100f;
    // Prefab that gets spawned on Awake and plays when tank dies
    // public GameObject m_ExplosionPrefab; --- CHANGE THIS TO BLOOD DEATH

    public float m_CurrentHealth;
    private bool m_Dead;

    // The particle system that will play when the tank is destroyed
    // private ParticleSystem m_ExplosionParticles; --- CHANGE THIS ''

    private void Awake()
    {
        // Instantiate the explosion prefab and get a reference to the particle system on it
        // m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

        // Disable the prefab so it can be activated when required (on death)
        // m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // Whent he tank is enabled, reset the tank's health + dead status
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }

    private void SetHealthUI()
    {
        /// TO DO: Update the user interface showing the tanks health
    }


    public void TakeDamage(float amount)
    {
        // Reduce current health by damage done
        m_CurrentHealth -= amount;

        // Update the UI accordingly
        SetHealthUI();

        // If the current health is <= 0 and it has not yet been registered, call OnDeath
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            onDeath();
        }
    }

    private void onDeath()
    {
        // Set the flag so that this function is only called once
        m_Dead = true;

        // Move the instantiated explosion prefab to the tank's position and turn it on
        // m_ExplosionParticles.transform.position = transform.position;
        // m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system
        // m_ExplosionParticles.Play();

        // Turn the tank off
        gameObject.SetActive(false);

        manager.GameEnd();
    }
}