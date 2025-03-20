using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UCR.ECCI.PI.frontend.Unity.Domain;
using System.Linq;
using UnityEngine.UIElements;




public class ListInputBuilding : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buildingList;

    [Inject]
    IBuildingService _buildingService;

    // Start is called before the first frame update
    void Start()
    {
        List<Building> buildings = _buildingService.GetBuildings();

        string reportBuildings = ClassifyBuildings(buildings);

        _buildingList.text = reportBuildings;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Classify the buildings based on: faultless and problematic buildings, identifying the type of fault presented. 
    /// </summary>
    /// <param name="buildings">The list of buildings to classify.</param>
    /// <returns>A string representing the classification report of the buildings.</returns>
    public string ClassifyBuildings(List<Building> buildings)
    {
        var buildingsGenerated = buildings.Where(building => building.Status).ToList();

        // Cases of error of generation of buildings
        var buildingsWithStatusFalse = buildings.Where(building => !building.Status).ToList();

        var buildingsWithCollision = buildings.GroupBy(building => (building.Location.LocX, building.Location.LocY, building.Location.LocZ))
                                              .Where(buildings => buildings.Count() > 1)
                                              .SelectMany(buildings => buildings)
                                              .ToList();
        var buildingsWithLocationZero = buildings.Where(building => building.Location.LocX == 0 && building.Location.LocY == 0 && building.Location.LocZ == 0).ToList();

        // Function to get the information of a building for the report

        string GetBuildingInfo(Building b) =>
            $"Nombre: {b.Characteristics.Name}, Descripción: {b.Characteristics.Description}, ID: {b.Characteristics.ID}, Color: {b.Characteristics.Color}, Acrónimo: {b.Characteristics.Acronym}, \n  " +
            $"Localización: ({b.Location.LocX}, {b.Location.LocY}, {b.Location.LocZ}), \n" +
            $"Rotación: ({b.Rotation.RotW}, {b.Rotation.RotX}, {b.Rotation.RotY}, {b.Rotation.RotZ}),\n " +
            $"Escala: ({b.Scale.ScaleX}, {b.Scale.ScaleY}, {b.Scale.ScaleZ}), \n" +
            $"Estatus: {b.Status}\n";


        // Construction of the classification report of the buildings generated and buildings with errors

        string classification = "Reporte de edificios generados:\n\n";

        classification += "** Edificios generados correctamente:\n\n" +
                  $"{string.Join("\n", buildingsGenerated.Select(b => $"- {GetBuildingInfo(b)}"))}\n\n";

        classification += "** Edificios con Status = False:\n\n" +
                  $"{string.Join("\n", buildingsWithStatusFalse.Select(b => $"- {GetBuildingInfo(b)}"))}\n\n";

        classification += "** Edificios con colision en localización:\n\n" +
                  $"{string.Join("\n", buildingsWithCollision.Select(b => $"- {GetBuildingInfo(b)}"))}\n\n";

        classification += "** Edificios con las cordenadas X Y Z en 0:\n\n" +
                  $"{string.Join("\n", buildingsWithLocationZero.Select(b => $"- {GetBuildingInfo(b)}"))}";

        return classification;
    }
}
