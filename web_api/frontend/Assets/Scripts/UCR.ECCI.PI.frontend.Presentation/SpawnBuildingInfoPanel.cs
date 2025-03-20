using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildingInfoPanel : MonoBehaviour
{
    [SerializeField]
    public GameObject BuildingInfoPanel;
    private Transform canvasTransform;

    private Renderer _renderer;

    public string BuildingName { get; set; }
    public string BuildingDescription { get; set; }

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        canvasTransform = GameObject.Find("Canvas").transform;
    }

    void OnMouseDown()
    {

        Debug.Log("Click");
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject panel = Instantiate(BuildingInfoPanel, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity, canvasTransform);
        panel.GetComponent<RectTransform>().anchoredPosition = cursorPos;

        BuildingInfoPanelObject buildingInfoPanel = panel.GetComponent<BuildingInfoPanelObject>();

        buildingInfoPanel.SetBuildingName(BuildingName);
        buildingInfoPanel.SetBuildingDescription(BuildingDescription);

    }
}
