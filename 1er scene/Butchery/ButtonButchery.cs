using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonButchery : MonoBehaviour
{
    public Button boutonHaut;
    public Button boutonBas;
    public Button boutonDroite;
    public Button boutonGauche;


    public ArrayButchery arrayButchery;

    
    private StartButchery startButchery;

    public Inventory inventory;
    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        // Initialize ButcheryStartButchery by finding the GameObject with ButcheryStartButchery script
        startButchery = FindObjectOfType<StartButchery>();

        // Check if startButchery is still null after attempting to find it
        if (startButchery == null)
        {
            Debug.LogError("startButchery script not found!");
        }
    }
    public void OnClickHaut()
    {
        if (boutonHaut.IsInteractable())
        {
            arrayButchery.DestroyHouse(startButchery.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startButchery.ValueClass);
            sauvegardeFonction3.retrievedVector3.z -= 1f;
            sauvegardeFonction3.SaveDataToJson(startButchery.ValueClass); 
            arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startButchery.stringClassName);
        }
    }

    public void OnClickBas()
    {
        if (boutonBas.IsInteractable())
        {
            arrayButchery.DestroyHouse(startButchery.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startButchery.ValueClass);
            sauvegardeFonction3.retrievedVector3.z += 1f;
            sauvegardeFonction3.SaveDataToJson(startButchery.ValueClass); 
            arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startButchery.stringClassName);
        }
    }

    public void OnClickDroite()
    {
        if (boutonDroite.IsInteractable())
        {
            arrayButchery.DestroyHouse(startButchery.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startButchery.ValueClass);
            sauvegardeFonction3.retrievedVector3.x -= 1f;
            sauvegardeFonction3.SaveDataToJson(startButchery.ValueClass); 
            arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startButchery.stringClassName);
        }
    }

    public void OnClickGauche()
    {
        if (boutonGauche.IsInteractable())
        {
            arrayButchery.DestroyHouse(startButchery.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startButchery.ValueClass);
            sauvegardeFonction3.retrievedVector3.x += 1f;
            sauvegardeFonction3.SaveDataToJson(startButchery.ValueClass); 
            arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startButchery.stringClassName);
        }
    }

}
