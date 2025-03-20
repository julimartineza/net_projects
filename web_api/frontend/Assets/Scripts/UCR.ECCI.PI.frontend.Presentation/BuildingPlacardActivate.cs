using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacardActivate : MonoBehaviour
{
    public GameObject BuildingPlacard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Activation();
    }
    public void Activation()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            BuildingPlacard.SetActive(true);
        }
    }

}

