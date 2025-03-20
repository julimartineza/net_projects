using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    public GameObject loadingScene;
    [SerializeField]
    public Canvas canvas;
    [SerializeField]
    public Text text;
    public Slider loadingBar;
    void OnMouseDown()
    {
        canvas.enabled = true;
        loadingScene.SetActive(true);
        text.enabled = true;
        loadingBar.enabled = true;
        Debug.Log("3d object works as button");
        StartCoroutine(LoadSceneAsynchronously(sceneToLoad));
    }

    IEnumerator LoadSceneAsynchronously(string sceneLoading)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneLoading);

        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }

}
