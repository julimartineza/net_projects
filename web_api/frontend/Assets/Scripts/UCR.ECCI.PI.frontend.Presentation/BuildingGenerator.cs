using UnityEngine;
using Zenject;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Unity.DependencyInjection;
using System.Collections.Generic;
using System.Linq;


namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class BuildingGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buildingPrefab;

        [SerializeField]
        private GameObject _panel;

        [Inject]
        IBuildingService _buildingService;

        // Start is called before the first frame update
        void Start()
        {
            

            if (_buildingService == null)
            {
                Debug.Log("Error, null scene context");
            }
            else
            {

                List<Building> buildings = _buildingService.GetBuildings().Where(building => building.Status).ToList();


                if (buildings == null)
                {
                    Debug.Log("Error 402: The information required is not available");
                }
                else
                {
                    foreach (var building in buildings)
                    {
                        var newBuilding = Instantiate(_buildingPrefab);

                        _buildingService.SetBuildingHeight(building);

                        SpawnBuildingInfoPanel spawnPanel = newBuilding.GetComponent<SpawnBuildingInfoPanel>();
                        spawnPanel.BuildingName = building.Characteristics.Name;
                        spawnPanel.BuildingDescription = building.Characteristics.Description;

                        newBuilding.transform.position = new Vector3(
                            building.Location.LocX, building.Location.LocY-2, building.Location.LocZ
                            );
                        newBuilding.transform.rotation = new Quaternion(
                            building.Rotation.RotW, building.Rotation.RotX, building.Rotation.RotY, building.Rotation.RotZ
                        );

                        // Convert to Euler angles, set the Z axis to 0, then convert back to Quaternion
                        Vector3 eulerRotation = newBuilding.transform.rotation.eulerAngles;
                        eulerRotation.z = 0; // Force Z rotation to 0 degrees
                        newBuilding.transform.rotation = Quaternion.Euler(eulerRotation);

                        newBuilding.transform.localScale = new Vector3(
                            building.Scale.ScaleX, building.Scale.ScaleY, building.Scale.ScaleZ
                            );

                        string materialName = building.Characteristics.Color; 
                        Material buildingMaterial = Resources.Load<Material>($"Materials/{materialName}");
                        if (buildingMaterial != null)
                        {
                            Renderer buildingRenderer = newBuilding.GetComponent<Renderer>();
                            if (buildingRenderer != null)
                            {
                                buildingRenderer.material = buildingMaterial;
                            }
                            else
                            {
                                Debug.LogWarning("Renderer component is missing on the building prefab.");
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"Material '{materialName}' not found in Resources/Materials.");
                        }

                        ResizeAttributes resize = newBuilding.GetComponent<ResizeAttributes>();
                        float Yaxis = building.Scale.ScaleY;
                        resize.resizeDoor(Yaxis);

                        CreateFacadeSign facadeSign = newBuilding.GetComponent<CreateFacadeSign>();
                        facadeSign.createSign(Yaxis);
                        facadeSign.SetText(building.Characteristics.Name);
                    }

                }
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}