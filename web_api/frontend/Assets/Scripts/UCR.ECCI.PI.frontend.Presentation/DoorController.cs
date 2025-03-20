using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftDoor;
    public GameObject rightDoor;
    private float openingRotationLeft = 90;
    private float closingRotation = 0;
    private float speed = 5;
    private bool opening;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in reach of doors.");
            opening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is out reach of doors.");
            opening = false;
        }
    }

    void Update()
    {
        if (opening)
        {
            Vector3 currentRotationLeft = leftDoor.transform.localEulerAngles;

            if (currentRotationLeft.y < openingRotationLeft)
            {
                leftDoor.transform.localEulerAngles = Vector3.Lerp(currentRotationLeft, new Vector3(currentRotationLeft.x, openingRotationLeft, currentRotationLeft.z), speed * Time.deltaTime);
            }
            Vector3 currentRotationRight = rightDoor.transform.localEulerAngles;
            float targetRotationRightY = 270f;  // The desired Y rotation for the right door to open

            // Handle Right Door Rotation - Avoid Quaternion.Slerp
            if (Mathf.Abs(currentRotationRight.y - targetRotationRightY) > 0.5f)  // Allow small tolerance
            {
                float newYRotation = Mathf.LerpAngle(currentRotationRight.y, targetRotationRightY, speed * Time.deltaTime);
                rightDoor.transform.localEulerAngles = new Vector3(currentRotationRight.x, newYRotation, currentRotationRight.z);
            }

        }
        else
        {
            Vector3 currentRotationLeft = leftDoor.transform.localEulerAngles;
            if (currentRotationLeft.y > closingRotation)
            {
                leftDoor.transform.localEulerAngles = Vector3.Lerp(currentRotationLeft, new Vector3(currentRotationLeft.x, closingRotation, currentRotationLeft.z), speed * Time.deltaTime);
            }
            Vector3 currentRotationRight = rightDoor.transform.localEulerAngles;

            if (Mathf.Abs(currentRotationRight.y - 0f) > 0.5f)  // Allow small tolerance
            {
                float newYRotation = Mathf.LerpAngle(currentRotationRight.y, 0f, speed * Time.deltaTime);
                rightDoor.transform.localEulerAngles = new Vector3(currentRotationRight.x, newYRotation, currentRotationRight.z);
            }
            else if (currentRotationRight.y >= 360 || currentRotationRight.y < 1)
            {
                rightDoor.transform.localEulerAngles = new Vector3(currentRotationRight.x, 0, currentRotationRight.z);
            }
        }
    }
}
