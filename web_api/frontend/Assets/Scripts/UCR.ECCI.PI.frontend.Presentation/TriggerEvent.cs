using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerEvent : MonoBehaviour
{

    private BuildingMesh myBuilding;
    private bool canBeCalled = true;
    internal void Setup(BuildingMesh building)
    {
        myBuilding = building;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method that triggers the panel when character collides
    void OnTriggerEnter(Collider other)
    {
        CharacterController characterController = other.GetComponent<CharacterController>();

        if((characterController != null)&&(canBeCalled))
        {
            canBeCalled = false;
      //      myBuilding.TriggerPopup();
        }
    }
}
