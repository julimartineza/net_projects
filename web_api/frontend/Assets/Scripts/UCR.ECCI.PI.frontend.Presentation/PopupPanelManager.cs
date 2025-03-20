using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanelManager : MonoBehaviour
{
    private Text displayText;

    // Method ensures that a text component is attached to the GameObject
    void Awake()
    {
        displayText = GetComponent<Text>();
        if (displayText == null)
        {
            Debug.LogError("Text component not found on this GameObject!");
        }
    }

    // Method to update the text displayed and start the fade-out effect
    public void UpdateText(string newText)
    {
        if (displayText != null)
        {
            displayText.text = newText;
            displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, 1f);

            StartCoroutine(FadeOutText(10f)); // Number is amount of secs
        }
    }

    // Method to fade out the text over a specified duration
    private IEnumerator FadeOutText(float duration)
    {
        float startAlpha = displayText.color.a; 
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0f, time / duration);
            displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, alpha);

            yield return null;
        }

        displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, 0f);
    }
}
