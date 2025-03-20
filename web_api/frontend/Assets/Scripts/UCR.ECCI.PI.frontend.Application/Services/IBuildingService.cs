using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    public interface IBuildingService
    {
        public List<Building> GetBuildings();
        public void SetBuildingHeight(Building building);
    }
}