using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Object.Destroy(other.gameObject);
    }
}
