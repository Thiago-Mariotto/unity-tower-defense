using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject turret;
    private readonly int ammoSpeed = 2000;

    public void Fire(Vector3 enemyPosition)
    {
        for (var i = 0; i < spawnPoint.Length; i++)
        {
            GameObject ammoShoted = Instantiate(ammo, spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);
            Rigidbody rb = ammoShoted.GetComponent<Rigidbody>();
            turret.transform.LookAt(enemyPosition);
            rb.AddForce(rb.transform.forward * ammoSpeed);
            Destroy(ammoShoted, 1.2f);
        }
    }
}
