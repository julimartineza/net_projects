using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingInfoPanelObject : MonoBehaviour
{
    public TextMeshProUGUI buildingNameText;

    public TextMeshProUGUI buildingDescriptionText;

    //private BuildingInfoPanel panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetBuildingName(string name)
    {
        // Update the text of the TMP_Text component with the building's name
        buildingNameText.text = name;

    }

    public void SetBuildingDescription(string description)
    {
        // Update the text of the TMP_Text component with the building's name
        buildingDescriptionText.text = description;

    }
}
