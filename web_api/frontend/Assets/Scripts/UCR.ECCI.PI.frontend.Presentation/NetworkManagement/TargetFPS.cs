using UnityEngine;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class TargetFps : MonoBehaviour
    {
        [SerializeField] private int targetFPS = 60;

        private static void Awake()
        {
            QualitySettings.vSyncCount = 0;
          
        }
    }
}
