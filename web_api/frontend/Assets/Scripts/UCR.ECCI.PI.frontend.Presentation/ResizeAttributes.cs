using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UCR.ECCI.PI.frontend.Unity.Presentation.BuildingGenerator;

public class ResizeAttributes : MonoBehaviour
{
    public GameObject doorEntrance;
    void Start()
    {

    }
    public void resizeDoor(float y) 
        {
            if (1 <= y && y < 5)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)-0.115, doorEntrance.transform.localPosition.z);
            }
            if (5 <= y && y < 10)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)(-1 * ((0.23 / (y / 5)) / 2)), doorEntrance.transform.localPosition.z);
            }
            if (10 <= y && y < 15)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)-0.315, doorEntrance.transform.localPosition.z);
            }
            if (15 <= y && y < 20)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)-0.360, doorEntrance.transform.localPosition.z);
            }
            if (20 <= y && y <= 25)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)-0.415, doorEntrance.transform.localPosition.z);
            }
            if (25 < y)
            {
                doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)-0.430, doorEntrance.transform.localPosition.z);
            }
            //doorEntrance.transform.localPosition = new Vector3(doorEntrance.transform.localPosition.x, (float)((-1*((0.23 / (buildingData.scale.y / 5))/2))* (buildingData.scale.y / 5)*5), doorEntrance.transform.localPosition.z);
            doorEntrance.transform.localScale = new Vector3((float)0.1, (float)(0.23/(y/ 4)), (float)0.024);
    }

}
