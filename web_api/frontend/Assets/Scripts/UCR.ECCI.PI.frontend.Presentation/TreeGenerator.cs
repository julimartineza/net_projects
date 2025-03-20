using UnityEngine;
using Zenject;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UCR.ECCI.PI.frontend.Unity.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class TreeGenerator : MonoBehaviour
    {
        [Inject]
        ITreeService _treeService;

        [SerializeField]
        private GameObject _treePrefab;

        [SerializeField]
        private GameObject _signPrefab;
        // Start is called before the first frame update
        void Start()
        {
            if (_treeService == null)
            {
                Debug.Log("Error, null scene context");
            }
            else
            {

                List<Domain.Tree> trees = _treeService.GetTrees().ToList();

                if (trees.Count == 0)
                {
                    // Inserted values for testing with only one 
                    var newSign = Instantiate(_signPrefab);
                    newSign.transform.position = new Vector3(
                        (float)362.0923, (float)2.608, (float)162.2699);
                    Debug.Log("No trees found.");
                }
                else
                {
                    Debug.Log($"Found {trees.Count} trees:");
                    foreach (var tree in trees)
                    {
                        var newTree = Instantiate(_treePrefab);

                        newTree.transform.position = new Vector3(
                        (float)tree.LocationX, (float)tree.LocationY, (float)tree.LocationZ
                        );
                        newTree.transform.localScale = new Vector3(
                        (float)tree.Scale, (float)tree.Scale, (float)tree.Scale
                        );

                        Debug.Log(tree.Id.ToString());
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
