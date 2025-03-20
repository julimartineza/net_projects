namespace UCR.ECCI.PI.frontend.Application.Services
{
    public interface IBuildingInfoPanelService
    {
        string LoadBuildingName(int buildingId);
        string LoadBuildingDescription(int buildingId);
    }
}