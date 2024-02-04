using UnityEngine;

public class House : MonoBehaviour
{
    public Color hoverColor;
    public GameObject house;
    private Color startColor;
    private Renderer rend;



    public sauvegardeFonction sauvegardeFonction3;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        house.SetActive(true);
    }


    private void OnMouseDown()
    {
    // You can create the house directly from the ArrayContainer
        ArrayContainer arrayContainer = GetComponentInParent<ArrayContainer>(); // Assuming the ArrayContainer is a parent of this object
        if (arrayContainer != null)
        {
           // mettre position de base+ length de base

            house.SetActive(false);
            sauvegardeFonction3.LoadDataFromJson(0);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayContainer.BuildHouse(sauvegardeFonction3.length,sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,"boulangerie");
            }
            
            sauvegardeFonction3.LoadDataFromJson(1);
            if(sauvegardeFonction3.unlock==true)
            {
                arrayContainer.BuildHouse(sauvegardeFonction3.length,sauvegardeFonction3.height,sauvegardeFonction3.width,sauvegardeFonction3.retrievedVector3,"armurerie");
            }
            
           
        }
        else
        {
            Debug.Log("No ArrayContainer found.");
        }
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public Vector3 GetVector3()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        return sauvegardeFonction3.retrievedVector3;
    }


}

