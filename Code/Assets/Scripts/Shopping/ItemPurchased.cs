using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchased : MonoBehaviour
{
    private Camera mainCamera;
    private Collider planeCollider;
    private RaycastHit hit;
    private Ray ray;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Ground").GetComponent<TerrainCollider>();
    }

    private void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 25);
            }
        }
    }
}
