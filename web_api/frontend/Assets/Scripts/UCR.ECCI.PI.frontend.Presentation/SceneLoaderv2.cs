using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class SceneLoaderv2 : MonoBehaviour
    {
        [SerializeField]
        private string sceneToLoad;
        //[SerializeField]
        // public GameObject loadingScene;
        // [SerializeField]
        // public Canvas canvas;
        // [SerializeField]
        // public Text text;
        // public Slider loadingBar;
        void OnMouseDown()
        {
            //canvas.enabled = true;
            //loadingScene.SetActive(true);
            //text.enabled = true;
            //loadingBar.enabled = true;
            Debug.Log("3d object works as button");
            //loadingScene.enabled = true;
            StartCoroutine(LoadSceneAsynchronously(sceneToLoad));
            //AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

            //while (!operation.isDone)
            //{
            //    loadingBar.value = operation.progress;
            //    yield return null;
            //}

            //SceneManager.LoadScene(sceneToLoad);
        }

        IEnumerator LoadSceneAsynchronously(string sceneLoading)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneLoading);

            while (!operation.isDone)
            {
                // loadingBar.value = operation.progress;
                yield return null;
            }
        }
    }
}
