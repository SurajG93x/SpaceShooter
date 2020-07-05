﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    public Rigidbody rb;

    private void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;          //angularvelocity gives speed of rotation
    }
}
