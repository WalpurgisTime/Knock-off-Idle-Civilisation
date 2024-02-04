using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneConnexion : MonoBehaviour
{
    public GameObject PanelStart;
    public GameObject PanelConnexion;
    public Button ButtonConnexion;

    public void OnClickConnexion()
    {
        if(ButtonConnexion.IsInteractable())
        {
            PanelStart.SetActive(false);
            PanelConnexion.SetActive(true);
        }
        
    }
}
