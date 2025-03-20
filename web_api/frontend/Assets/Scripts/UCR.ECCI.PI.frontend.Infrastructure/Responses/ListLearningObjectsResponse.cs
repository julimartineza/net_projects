using System.Collections.Generic;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure.Assets.Scripts.UCR.ECCI.PI.frontend.Infrastructure.Responses
{
    public class ListLearningObjectsResponse
    {
        public IEnumerable<LearningObjectDto> LearningObjects { get; set; }
    }
}
