using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas promptCanvas;
    public TextMeshPro text;
    public GameObject entranceButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in reach of entrance.");
            promptCanvas.enabled = true;
            text.enabled = true;
            entranceButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is out reach of entrance.");
            promptCanvas.enabled = false;
            text.enabled = false;
            entranceButton.SetActive(false);
        }
    }
}
