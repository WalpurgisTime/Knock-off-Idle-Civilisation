using UnityEngine;
using UnityEngine.UI;

public class Buttons2 : MonoBehaviour
{
    public Button boutonHaut;
    public Button boutonBas;
    public Button boutonDroite;
    public Button boutonGauche;

    public BuildManager buildManager; 
    public ArrayContainer arrayContainer;

    
    private ManyButtons manyButtons;
    public House house;
    public Inventory inventory;
    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        // Initialize manyButtons by finding the GameObject with ManyButtons script
        manyButtons = FindObjectOfType<ManyButtons>();

        // Check if manyButtons is still null after attempting to find it
        if (manyButtons == null)
        {
            Debug.LogError("ManyButtons script not found!");
        }
    }
    public void OnClickHaut()
    {
        if (boutonHaut.IsInteractable())
        {
            arrayContainer.DestroyHouse(manyButtons.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(manyButtons.ValueClass);
            sauvegardeFonction3.retrievedVector3.z -= 1f;
            sauvegardeFonction3.SaveDataToJson(manyButtons.ValueClass); 
            arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,manyButtons.stringClassName);
        }
    }

    public void OnClickBas()
    {
        if (boutonBas.IsInteractable())
        {
            arrayContainer.DestroyHouse(manyButtons.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(manyButtons.ValueClass);
            sauvegardeFonction3.retrievedVector3.z += 1f;
            sauvegardeFonction3.SaveDataToJson(manyButtons.ValueClass); 
            arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,manyButtons.stringClassName);
        }
    }

    public void OnClickDroite()
    {
        if (boutonDroite.IsInteractable())
        {
            arrayContainer.DestroyHouse(manyButtons.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(manyButtons.ValueClass);
            sauvegardeFonction3.retrievedVector3.x -= 1f;
            sauvegardeFonction3.SaveDataToJson(manyButtons.ValueClass); 
            arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,manyButtons.stringClassName);
        }
    }

    public void OnClickGauche()
    {
        if (boutonGauche.IsInteractable())
        {
            arrayContainer.DestroyHouse(manyButtons.ValueClass);
            sauvegardeFonction3.LoadDataFromJson(manyButtons.ValueClass);
            sauvegardeFonction3.retrievedVector3.x += 1f;
            sauvegardeFonction3.SaveDataToJson(manyButtons.ValueClass); 
            arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,manyButtons.stringClassName);
        }
    }

    
}

