using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Button boutonRespawn;

    public BuildManager buildManager;
    public ArrayContainer arrayContainer;
    public ArrayArmurerie arrayArmurerie;
    public ArrayButchery arrayButchery;
    public ArrayForge arrayForge;
    public ArrayCamp arrayCamp;


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

    public void OnClickRespawn()
    {
        if (boutonRespawn.IsInteractable())
        {
            // Charger les données depuis le fichier JSON
            sauvegardeFonction3.LoadDataFromJson(0);
            // Utiliser les données chargées pour construire la maison
            arrayContainer.DestroyHouse(0);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"boulangerie");
            }
           
            sauvegardeFonction3.LoadDataFromJson(1);
            arrayContainer.DestroyHouse(1);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"armurerie");
            }
            
            sauvegardeFonction3.LoadDataFromJson(2);
            arrayArmurerie.DestroyHouse(2);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayArmurerie.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Armoury1");
            }

            sauvegardeFonction3.LoadDataFromJson(3);
            arrayArmurerie.DestroyHouse(3);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayArmurerie.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Armoury2");
      
            }
            sauvegardeFonction3.LoadDataFromJson(4);
            
            arrayArmurerie.DestroyHouse(4);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayArmurerie.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Armoury3");
            }

            sauvegardeFonction3.LoadDataFromJson(5);
            
            arrayButchery.DestroyHouse(5);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Butchery1");
            }
            sauvegardeFonction3.LoadDataFromJson(6);  
            arrayButchery.DestroyHouse(6);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Butchery2");
            }
            
            sauvegardeFonction3.LoadDataFromJson(7);
            arrayButchery.DestroyHouse(7);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayButchery.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Butchery3");
            }

            sauvegardeFonction3.LoadDataFromJson(8);
            arrayForge.DestroyHouse(8);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Forge1");
            }

            sauvegardeFonction3.LoadDataFromJson(9);
            arrayForge.DestroyHouse(9);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Forge2");
            }

            sauvegardeFonction3.LoadDataFromJson(10);
            arrayCamp.DestroyHouse(10);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Camp1");
            }
            sauvegardeFonction3.LoadDataFromJson(11);
            arrayCamp.DestroyHouse(11);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Camp2");
            }
            
            sauvegardeFonction3.LoadDataFromJson(12);
            arrayCamp.DestroyHouse(12);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayCamp.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,"Camp3");

            }

 
            
        }
    }

   
}
