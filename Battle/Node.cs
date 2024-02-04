using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color CantpickColor;
    public Color AlreadyCreated;
    private Color startColor;
    private Renderer rend;

    
    public bool Construit;
    private bool IsAlreadyCreated;

    public Vector3 waypointCreated;
  
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        Construit = true;
        IsAlreadyCreated = false;
        string nomDeLObjet = gameObject.name;    
    }


    private void OnMouseDown()
    {
        if(!IsAlreadyCreated)
        {

            if (NodeButton.instance.previousButtonv1()=="ArcherCreated")
            {
                Construit = NodeButton.instance.ArcherToBuildV1();

                if(!Construit)
                {
                    waypointCreated= transform.position;
                    NodeButton.instance.SetwaypointName(gameObject.name);
                    NodeButton.instance.SetPositionWaypoint(waypointCreated);
                    
                    Construit = true;
                    NodeButton.instance.SetArcherToBuild(true);
                    IsAlreadyCreated = true;
                }
                else
                {
                    //Debug.Log("pas construisible");
                }
            }

            if(NodeButton.instance.previousButtonv1()=="ShielderCreated")
            {
                Construit = NodeButton.instance.ShielderToBuildV1();

                if(!Construit)
                {
                    waypointCreated= transform.position;
                    NodeButton.instance.SetwaypointName(gameObject.name);
                    NodeButton.instance.SetPositionWaypoint(waypointCreated);
                    
                    Construit = true;
                    NodeButton.instance.SetShielderToBuild(true);
                    IsAlreadyCreated = true;
                }
                else
                {
                    //Debug.Log("pas construisible");
                }
            }
        }
        if(NodeButton.instance.previousButtonv1()=="SwordCreated")
        {
            Construit = NodeButton.instance.SwordToBuildV1();

            if(!Construit)
            {
                waypointCreated= transform.position;
                NodeButton.instance.SetwaypointName(gameObject.name);
                NodeButton.instance.SetPositionWaypoint(waypointCreated);
                
                Construit = true;
                NodeButton.instance.SetSwordToBuild(true);
                IsAlreadyCreated = true;
            }
            else
            {
                //Debug.Log("pas construisible");
            }
        }
        else
        {
            Debug.Log("deja créé");
        }
        
    }

    private void OnMouseEnter()
    {
        if(!IsAlreadyCreated)
        {
                if (NodeButton.instance.previousButtonv1()=="ArcherCreated")
            {
                Construit = NodeButton.instance.ArcherToBuildV1();

                if(!Construit)
                {
                    rend.material.color = hoverColor;
                }
                else
                {
                    rend.material.color = CantpickColor;
                }
            }

            if(NodeButton.instance.previousButtonv1()=="ShielderCreated")
            {
                Construit = NodeButton.instance.ShielderToBuildV1();

                if(!Construit)
                {
                    rend.material.color = hoverColor;
                }
                else
                {
                    rend.material.color = CantpickColor;
                }
            }
            if(NodeButton.instance.previousButtonv1()=="SwordCreated")
            {
                Construit = NodeButton.instance.SwordToBuildV1();

                if(!Construit)
                {
                    rend.material.color = hoverColor;
                }
                else
                {
                    rend.material.color = CantpickColor;
                }
            }
        }
        else
        {
            rend.material.color = AlreadyCreated;
        }
        

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}