using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bulletSpawn;

    public Rigidbody bullet;

    public float shootForce = 30f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Rigidbody bulletInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;

        bulletInstance.velocity = shootForce * bulletSpawn.forward;
    }
}
