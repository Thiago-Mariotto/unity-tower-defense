using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAmmo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Ammo") && !other.CompareTag("Tower"))
        {
            Destroy(this.gameObject);
        }       
    }
}
