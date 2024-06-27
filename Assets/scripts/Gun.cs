using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] ParticleSystem gunParticle;
    [SerializeField] MicrophoneInput decibel;
    [SerializeField] float decibelThreshold = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (decibel.decibel > decibelThreshold)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        gunParticle.Play();
    }
}
