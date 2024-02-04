using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string sceneToLoad1 = "1er scene";
    public Button Button1;

    public void LoadSCene1ersCnene()
    {
        if(Button1.IsInteractable())
        {
            SceneManager.LoadScene(sceneToLoad1);
        }
        
    }
}
