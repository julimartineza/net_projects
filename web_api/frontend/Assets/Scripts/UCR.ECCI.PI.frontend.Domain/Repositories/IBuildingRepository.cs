using System.Collections.Generic;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface IBuildingRepository
    {
        public List<Building> GetBuildings();
    }
}
