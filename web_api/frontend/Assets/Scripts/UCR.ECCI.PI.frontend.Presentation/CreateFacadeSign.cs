using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateFacadeSign : MonoBehaviour
{
    // public GameObject mytextObjectReference;
    public GameObject backgroundObjectReference;
    public GameObject signPrefab;

    private GameObject signReference;
    public void createSign(float yaxis)
    {
        // Instantiate the signPrefab at the backgroundObjectReference's position without rotation
        signReference = Instantiate(signPrefab, backgroundObjectReference.transform.position, Quaternion.identity);

        // Set the rotation to match the backgroundObjectReference's rotation
        signReference.transform.rotation = backgroundObjectReference.transform.rotation;

        // Convert to Euler angles, set the Z axis to 0, then convert back to Quaternion
        Vector3 eulerRotation = signReference.transform.rotation.eulerAngles;
        eulerRotation.z = 0; // Force Z rotation to 0 degrees
        eulerRotation.y -= 90; // Rotate the sign so it faces correctly
        signReference.transform.rotation = Quaternion.Euler(eulerRotation);



        // Adjust the position by raising the Y value by 5
        Vector3 newPosition = signReference.transform.position;
        newPosition.y += 5;
        signReference.transform.position = newPosition;
    }

    /// <summary>
    /// Set the sign text to display the building title.
    /// </summary>
    /// <param name="text"></param>
    /// <returns> 0 if the code ran correctly. </returns>
    internal int SetText(string text)
    {
        if (signReference == null)
        {
            Debug.LogWarning("signReference doesnt exist.");
            return 1;
        }

        // Find the TextMeshPro component in the child object of the signReference
        var textComponent = signReference.GetComponentInChildren<TextMeshPro>();

        if (textComponent != null)
        {
            // Update the text of the TextMeshPro component
            textComponent.text = text;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not found in child object.");
            return 2;
        }

        return 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
