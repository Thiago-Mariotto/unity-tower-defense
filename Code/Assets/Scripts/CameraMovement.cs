using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] int cameraSpeed = 10;
    private void Update()
    {
        float xAxisValue = Input.GetAxisRaw("Horizontal") * cameraSpeed;
        float zAxisValue = Input.GetAxisRaw("Vertical") * cameraSpeed;

        if(xAxisValue != 0) {
            transform.position += Time.deltaTime * xAxisValue * new Vector3(cameraSpeed, 0, 0);
            if (transform.position.x <= 15)
            {
                transform.position = new Vector3(15, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= 90)
            {
                transform.position = new Vector3(90, transform.position.y, transform.position.z);
            }
        }
        
        if (zAxisValue != 0)
        {
            transform.position += Time.deltaTime * zAxisValue * new Vector3(0, 0, cameraSpeed);
            if (transform.position.z <= -2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            } else if(transform.position.z >= 60)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 60);
            }
        }

        if(Input.GetKey(KeyCode.E)) {
            transform.position += Time.deltaTime * zAxisValue * new Vector3(0, cameraSpeed, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Time.deltaTime * zAxisValue * new Vector3(0, -cameraSpeed, 0);
        }
    }
}
