using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPointFinder : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    private GameObject spawnPoint;
    private string previousScene;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LobbyAnexo")
        {
            spawnPoint = GameObject.Find("SpawnPointLobbyAnexo");
            player.SetPositionAndRotation(spawnPoint.transform.position, player.transform.rotation);
            Physics.SyncTransforms();
            previousScene = scene.name;
        }
        if (previousScene == "LobbyAnexo")
        {
            if (scene.name == "EcciTinoco")
            {
                spawnPoint = GameObject.Find("SpawnPointAnexoO");
                player.SetPositionAndRotation(spawnPoint.transform.position, player.transform.rotation);
                Physics.SyncTransforms();
            }
            else if (scene.name == "4-6")
            {
                spawnPoint = GameObject.Find("SpawnPointLab");
                player.SetPositionAndRotation(spawnPoint.transform.position, player.transform.rotation);
                Physics.SyncTransforms();
            }
        }
    }
}
