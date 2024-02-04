using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnApplicaltionQuit : MonoBehaviour
{
    public GameObject[] arrayToSetActive;
    void OnApplicationQuit()
    {
        foreach(GameObject element in arrayToSetActive)
        {
            element.SetActive(true);
        }
    }
}
