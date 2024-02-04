using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsArmoury : MonoBehaviour
{
    public Button boutonHaut;
    public Button boutonBas;
    public Button boutonDroite;
    public Button boutonGauche;


    public ArrayArmurerie arrayArmoury;

    
    private StartArmoury startArmoury;

    public Inventory inventory;
    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        // Initialize ArmouryStartArmoury by finding the GameObject with ArmouryStartArmoury script
        startArmoury = FindObjectOfType<StartArmoury>();

        // Check if startArmoury is still null after attempting to find it
        if (startArmoury == null)
        {
            Debug.LogError("startArmoury script not found!");
        }
    }
    public void OnClickHaut()
    {
        if (boutonHaut.IsInteractable())
        {
            arrayArmoury.DestroyHouse(startArmoury.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startArmoury.ValueClass);
            sauvegardeFonction3.retrievedVector3.z -= 1f;
            sauvegardeFonction3.SaveDataToJson(startArmoury.ValueClass); 
            arrayArmoury.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startArmoury.stringClassName);
        }
    }

    public void OnClickBas()
    {
        if (boutonBas.IsInteractable())
        {
            arrayArmoury.DestroyHouse(startArmoury.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startArmoury.ValueClass);
            sauvegardeFonction3.retrievedVector3.z += 1f;
            sauvegardeFonction3.SaveDataToJson(startArmoury.ValueClass); 
            arrayArmoury.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startArmoury.stringClassName);
        }
    }

    public void OnClickDroite()
    {
        if (boutonDroite.IsInteractable())
        {
            arrayArmoury.DestroyHouse(startArmoury.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startArmoury.ValueClass);
            sauvegardeFonction3.retrievedVector3.x -= 1f;
            sauvegardeFonction3.SaveDataToJson(startArmoury.ValueClass); 
            arrayArmoury.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startArmoury.stringClassName);
        }
    }

    public void OnClickGauche()
    {
        if (boutonGauche.IsInteractable())
        {
            arrayArmoury.DestroyHouse(startArmoury.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(startArmoury.ValueClass);
            sauvegardeFonction3.retrievedVector3.x += 1f;
            sauvegardeFonction3.SaveDataToJson(startArmoury.ValueClass); 
            arrayArmoury.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,startArmoury.stringClassName);
        }
    }

}
