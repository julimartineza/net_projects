using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UI;
using System.Reflection.Emit;

public class BuildingMesh : MonoBehaviour
{
    private string id;
    new private string name;

    [Header("Popup on distance variables")]
    [SerializeField]
    private GameObject player;
    private float distanceToPlayer;
    public float triggerDistance;
    private GameObject popupPanel;


    [Header("Debug")]
    public bool drawGizmo = false;
    public Color textColor = Color.white;
    public Vector3 offset = Vector3.up * 2; // Offset for the text position

    private string description;
    GameObject Prueba;

    internal void SetId(string id)
    {
        this.id = id;
    }

    public string getName()
    {
        return this.name;
    }

    internal void SetName(string name)
    {
        this.name = name;
    }

    public string getDescription()
    {
        return this.description;
    }

    internal void SetDescription(string description)
    {
        this.description = description;
    }

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method calculates the distance between the current GameObject and the player's GameObject
    private void labelPopup()
    {
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
    }

    // Method to create a trigger that surrounds the existing BoxCollider
    public void CreateTriggerAroundBoxCollider()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            Debug.LogError("No BoxCollider found on this GameObject!");
            return;
        }

        GameObject triggerObject = new GameObject("TriggerArea");
        triggerObject.transform.SetParent(transform);
        triggerObject.transform.localPosition = Vector3.zero;

        var triggerCollider = triggerObject.AddComponent<BoxCollider>();
        triggerCollider.isTrigger = true;

        Vector3 parentScale = transform.lossyScale; // Use lossyScale for the world scale

        triggerCollider.size = new Vector3(
            (boxCollider.size.x * parentScale.x) + (triggerDistance * 2), // Adding distance to width
            (boxCollider.size.y * parentScale.y) + (triggerDistance * 2), // Adding distance to height
            (boxCollider.size.z * parentScale.z) + (triggerDistance * 2)  // Adding distance to depth
        );

        triggerCollider.center = boxCollider.center;
        TriggerEvent triggerEvent = triggerObject.AddComponent<TriggerEvent>();
        triggerEvent.Setup(this);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (drawGizmo)
        {

            // Set Gizmo color
            Gizmos.color = textColor;

            // Get the Transform information
            Vector3 position = transform.position;
            Vector3 rotation = transform.eulerAngles;
            Vector3 scale = transform.localScale;

            // Format the information as a string
            string transformInfo = $"Name: {name}\nId: {id}\nPos: {position}\nRot: {rotation}\nScale: {scale}";

            // Display the string in the scene at the object's position with an offset
            DrawString(transformInfo, transform.position + offset, textColor);
        }
    }

    // Method to draw text in the scene
    public static void DrawString(string text, Vector3 worldPosition, Color textColor)
    {
        // Store the current GUI color
        GUIStyle style = new GUIStyle();
        style.normal.textColor = textColor;
        Handles.Label(worldPosition, text, style);
    }

    internal void TriggerPopup()
    {
        // Get the Text component from the popupPanel
        PopupPanelManager ppm = popupPanel.GetComponent<PopupPanelManager>();

        // Check if the Text component is found
        if (ppm != null)
            ppm.UpdateText(getDescription());
    }

    public void SetPanel(GameObject panel)
    {
        popupPanel = panel;
    }

#endif

}