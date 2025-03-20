using System.Collections.Generic;
using System.Linq;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class LearningObjectsGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tvprefab;
        [SerializeField]
        private GameObject _whiteboardprefab;
        [SerializeField]
        private GameObject _projectorprefab;

        [Inject]
        private ILearningObjectService _learningObjectService;

        [Inject]
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        void Start()
        {
            if (_learningObjectService == null)
            {
                Debug.Log("Error, null scene context");
            }
            else
            {
                List<Learning_Object> objects = _learningObjectService.GetLearningObject("Lab 4-6").ToList();

                if (objects == null)
                {
                    Debug.Log("Error 402: The information required is not available");
                }
                else
                {
                    foreach (var learningObject in objects)
                    {
                        if (learningObject.Type == "TV")
                        {
                            var newLearningObject = _instantiator.InstantiatePrefab(_tvprefab);
                            newLearningObject.transform.position = new Vector3(
                                learningObject.Location.LocX, learningObject.Location.LocY, learningObject.Location.LocZ
                            );
                            newLearningObject.transform.rotation = new Quaternion(
                                learningObject.Rotation.RotW, learningObject.Rotation.RotX, learningObject.Rotation.RotY, learningObject.Rotation.RotZ
                            );

                            Vector3 eulerRotation = newLearningObject.transform.rotation.eulerAngles;
                            eulerRotation.z = 0; // Force Z rotation to 0 degrees
                            newLearningObject.transform.rotation = Quaternion.Euler(eulerRotation);

                            newLearningObject.transform.localScale = new Vector3(
                                learningObject.Scale.ScaleX, learningObject.Scale.ScaleY, learningObject.Scale.ScaleZ
                            );
                            newLearningObject.name = learningObject.Id;
                        }
                        else if (learningObject.Type == "Whiteboard")
                        {
                            var newLearningObject = _instantiator.InstantiatePrefab(_whiteboardprefab);
                            newLearningObject.transform.position = new Vector3(
                                learningObject.Location.LocX, learningObject.Location.LocY, learningObject.Location.LocZ
                            );
                            newLearningObject.transform.rotation = new Quaternion(
                                learningObject.Rotation.RotW, learningObject.Rotation.RotX, learningObject.Rotation.RotY, learningObject.Rotation.RotZ
                            );

                            Vector3 eulerRotation = newLearningObject.transform.rotation.eulerAngles;
                            eulerRotation.z = 0; // Force Z rotation to 0 degrees
                            newLearningObject.transform.rotation = Quaternion.Euler(eulerRotation);

                            newLearningObject.transform.localScale = new Vector3(
                                learningObject.Scale.ScaleX, learningObject.Scale.ScaleY, learningObject.Scale.ScaleZ
                            );
                            newLearningObject.name = learningObject.Id;
                        }
                        else if (learningObject.Type == "Projector")
                        {
                            var newLearningObject = _instantiator.InstantiatePrefab(_projectorprefab);
                            newLearningObject.transform.position = new Vector3(
                                learningObject.Location.LocX, learningObject.Location.LocY, learningObject.Location.LocZ
                            );
                            newLearningObject.transform.rotation = new Quaternion(
                                learningObject.Rotation.RotW, learningObject.Rotation.RotX, learningObject.Rotation.RotY, learningObject.Rotation.RotZ
                            );

                            Vector3 eulerRotation = newLearningObject.transform.rotation.eulerAngles;
                            eulerRotation.z = 0; // Force Z rotation to 0 degrees
                            newLearningObject.transform.rotation = Quaternion.Euler(eulerRotation);

                            newLearningObject.transform.localScale = new Vector3(
                                learningObject.Scale.ScaleX, learningObject.Scale.ScaleY, learningObject.Scale.ScaleZ
                            );
                            newLearningObject.name = learningObject.Id;
                        }
                        else
                        {
                            Debug.Log("Error 403: No Learning object category equals inserted");
                        }
                    }
                }
            }
        }
    }
}