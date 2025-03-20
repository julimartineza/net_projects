using UnityEngine;
using UCR.ECCI.PI.frontend.Application.Services;

namespace UCR.ECCI.PI.frontend.Presentation
{
    public class BuildingInfoPanelService : IBuildingInfoPanelService
    {
        public string LoadBuildingName(int buildingId)
        {
            // Implement logic to load building name, possibly using Unity-specific APIs
            return "Building Name";
        }

        public string LoadBuildingDescription(int buildingId)
        {
            // Implement logic to load building description, possibly using Unity-specific APIs
            return "Building Description";
        }
    }
}