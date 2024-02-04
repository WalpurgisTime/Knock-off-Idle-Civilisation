using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCamp : MonoBehaviour
{
    public Button boutonHaut;
    public Button boutonBas;
    public Button boutonDroite;
    public Button boutonGauche;


    public ArrayCamp arrayCamp;

    
    private StartCamp startCamp;

    public Inventory inventory;
    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        // Initialize CampStartCamp by finding the GameObject with CampStartCamp script
        startCamp = FindObjectOfType<StartCamp>();

        // Check if startCamp is still null after attempting to find it
        if (startCamp == null)
        {
            Debug.LogError("startCamp script not found!");
        }
    }
    public void OnClickHaut()
    {
        if (boutonHaut.IsInteractable())
        {
            arrayCamp.DestroyHouse(startCamp.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startCamp.ValueClass);
            sauvegardeFonction3.retrievedVector3.z -= 1f;
            sauvegardeFonction3.SaveDataToJson(startCamp.ValueClass); 
            arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startCamp.stringClassName);
        }
    }

    public void OnClickBas()
    {
        if (boutonBas.IsInteractable())
        {
            arrayCamp.DestroyHouse(startCamp.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startCamp.ValueClass);
            sauvegardeFonction3.retrievedVector3.z += 1f;
            sauvegardeFonction3.SaveDataToJson(startCamp.ValueClass); 
            arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startCamp.stringClassName);
        }
    }

    public void OnClickDroite()
    {
        if (boutonDroite.IsInteractable())
        {
            arrayCamp.DestroyHouse(startCamp.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startCamp.ValueClass);
            sauvegardeFonction3.retrievedVector3.x -= 1f;
            sauvegardeFonction3.SaveDataToJson(startCamp.ValueClass); 
            arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startCamp.stringClassName);
        }
    }

    public void OnClickGauche()
    {
        if (boutonGauche.IsInteractable())
        {
            arrayCamp.DestroyHouse(startCamp.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startCamp.ValueClass);
            sauvegardeFonction3.retrievedVector3.x += 1f;
            sauvegardeFonction3.SaveDataToJson(startCamp.ValueClass); 
            arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startCamp.stringClassName);
        }
    }

}



