using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float fireDelay;

    private AudioSource audioSource;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", fireDelay, fireRate);
	}

    void Fire()
    {
        Instantiate(shot, transform.position, transform.rotation);
        audioSource.Play();
    }
}
