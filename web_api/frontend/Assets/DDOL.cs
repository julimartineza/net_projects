using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    private static DDOL instance;
    private void Awake()
    {
        int numPlayers = Object.FindObjectsByType<DDOL>(FindObjectsSortMode.None).Length;
        if (numPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
