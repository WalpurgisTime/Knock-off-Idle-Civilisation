using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForge : MonoBehaviour
{
    public Button boutonHaut;
    public Button boutonBas;
    public Button boutonDroite;
    public Button boutonGauche;


    public ArrayForge arrayForge;

    
    private StartForge startForge;

    public Inventory inventory;
    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        // Initialize ForgeStartForge by finding the GameObject with ForgeStartForge script
        startForge = FindObjectOfType<StartForge>();

        // Check if startForge is still null after attempting to find it
        if (startForge == null)
        {
            Debug.LogError("startForge script not found!");
        }
    }
    public void OnClickHaut()
    {
        if (boutonHaut.IsInteractable())
        {
            arrayForge.DestroyHouse(startForge.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startForge.ValueClass);
            sauvegardeFonction3.retrievedVector3.z -= 1f;
            sauvegardeFonction3.SaveDataToJson(startForge.ValueClass); 
            arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startForge.stringClassName);
        }
    }

    public void OnClickBas()
    {
        if (boutonBas.IsInteractable())
        {
            arrayForge.DestroyHouse(startForge.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startForge.ValueClass);
            sauvegardeFonction3.retrievedVector3.z += 1f;
            sauvegardeFonction3.SaveDataToJson(startForge.ValueClass); 
            arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startForge.stringClassName);
        }
    }

    public void OnClickDroite()
    {
        if (boutonDroite.IsInteractable())
        {
            arrayForge.DestroyHouse(startForge.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startForge.ValueClass);
            sauvegardeFonction3.retrievedVector3.x -= 1f;
            sauvegardeFonction3.SaveDataToJson(startForge.ValueClass); 
            arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startForge.stringClassName);
        }
    }

    public void OnClickGauche()
    {
        if (boutonGauche.IsInteractable())
        {
            arrayForge.DestroyHouse(startForge.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startForge.ValueClass);
            sauvegardeFonction3.retrievedVector3.x += 1f;
            sauvegardeFonction3.SaveDataToJson(startForge.ValueClass); 
            arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startForge.stringClassName);
        }
    }

}
