using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Unity.DependencyInjection;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class LearningSpaceGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _learningSpaceprefab;
        [Inject]
        ILearningSpaceService _learningspaceService;
        // Start is called before the first frame update
        void Start()
        {
            if (_learningspaceService == null)
            {
                Debug.Log("Error, null scene context");
            }
            else { 
                Learning_Space learningspace = _learningspaceService.GetLearningSpace("ECCI");
                if (learningspace.Name == "")
                {
                    Debug.Log("Error, Null data list");
                }
                else
                {
                    var newLearningSpace = Instantiate(_learningSpaceprefab);
                    
                    newLearningSpace.transform.position = new Vector3(0,0,0);
                    newLearningSpace.transform.rotation = new Quaternion(0,0,0,0);
                    newLearningSpace.transform.localScale = new Vector3(
                        learningspace.Scale.ScaleX, learningspace.Scale.ScaleY, learningspace.Scale.ScaleZ
                        );
                    newLearningSpace.name = learningspace.Name;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
