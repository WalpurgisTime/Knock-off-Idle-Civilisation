using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public ArrayContainer arrayContainer; // Ajoutez une référence à l'objet ArrayContainer
    public Vector3 vector3;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Déjà un build manager.");
        }
    }

    public void CreateHouseOnMouseDown()
    {
        if (arrayContainer == null)
        {
            Debug.LogError("Aucune référence à ArrayContainer n'a été définie dans BuildManager.");
            return; // Retourne null en cas d'erreur
        }


        // Appeler la méthode BuildHouse de l'instance d'ArrayContainer
       
        // Obtenir les GameObjects créés depuis ArrayContainer
        GameObject[] createdHouse = arrayContainer.GetCreatedObjects();

        foreach (GameObject house in createdHouse)
        {
            house.SetActive(true);
        }
    }

   
}
