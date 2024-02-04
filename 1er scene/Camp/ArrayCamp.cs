using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class ArrayCamp : MonoBehaviour
{
    public GameObject[] midCamp;
    public GameObject[] groundCamp;
    public GameObject[] topCamp;
    public GameObject[] Camp1;
    public GameObject[] Camp2;
    public GameObject[] Camp3;


    [HideInInspector]
    public GameObject[][] array;
    [HideInInspector]
    public Vector3 positionOffset;

    public float eulerRotation = 0f;

    [HideInInspector]
    public List<GameObject> createdObjects= new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdCamp1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdCamp2 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdCamp3 = new List<GameObject>();

    private Quaternion customRotation;

    private void Start()
    {
        // Initialisation du tableau principal (array) avec les sous-tableaux
        array = new GameObject[][]
        {
            midCamp,
            groundCamp,
            topCamp,
            Camp1,
            Camp2,
            Camp3
        };
    }

    public void BuildHouse(int length, int height, int width, Vector3 originalPositionOffset,string className)
    {
        positionOffset = originalPositionOffset ;
       
        float originalEulerRotation = eulerRotation;
        float lengthf = length;
        float widthf = width;

        positionOffset.y = -3f; 
        
        for (int v=0 ; v<3 ; v++)
        {   
            if(v==0)
            {
                positionOffset.x -= 2;
                var commonObjects1 = FindCommonGameObjects(new string[] { className });
                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                _pillar.SetActive(true);
                createdObjects.Add(_pillar);
                
                BoxCollider boxCollider = _pillar.GetComponent<BoxCollider>();
                boxCollider.enabled = true;

                // Attach a script to visualize the Box Collider
                boxCollider.gameObject.AddComponent<BoxColliderVisualizer>();
                positionOffset.x += 2;
            }
            if(v==1)
            {

                var commonObjects1 = FindCommonGameObjects(new string[] { "midCamp" });
                int randomIndex = UnityEngine.Random.Range(0, 1);
                positionOffset.y -= 0.3f;
                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                positionOffset.y += 0.3f;

                _pillar.SetActive(true);
                createdObjects.Add(_pillar);
            }
        
                    
            if(v==2)
            {
                
                if(className == "Camp1")
                {
                    positionOffset.y += 4f;
                    positionOffset.x += 6f;
                    positionOffset.z -= 3f;
                    groundCamp[0].transform.position = positionOffset ;
                    positionOffset.z += 3f;
                    positionOffset.y -= 4f;
                    positionOffset.x -= 6f;

                }
                if(className == "Camp2")
                {
                    positionOffset.y += 4f;
                    positionOffset.x += 6f;
                    positionOffset.z -= 3f;
                    groundCamp[1].transform.position = positionOffset ;
                    positionOffset.z += 3f;
                    positionOffset.y -= 4f;
                    positionOffset.x -= 5f;

                }
                if(className == "Camp3")
                {
                    positionOffset.y += 4f;
                    positionOffset.x += 6f;
                    positionOffset.z -= 3f;
                    groundCamp[2].transform.position = positionOffset ;
                    positionOffset.z += 3f;
                    positionOffset.y -= 4f;
                    positionOffset.x -= 6f;

                }
                

            
                   

                
     
                
            }


        }

    }

    public GameObject[] GetCreatedObjects()
    {
        return createdObjects.ToArray();
    }

    private GameObject[] FindCommonGameObjects(string[] subArrayNames)
    {
        if (subArrayNames.Length == 1)
        {
            return GetCommonObjectsByTag(subArrayNames[0]);
        }

        GameObject[] commonObjects = GetSubarrayByName(subArrayNames[0]);

        for (int i = 1; i < subArrayNames.Length; i++)
        {
            GameObject[] subArray = GetSubarrayByName(subArrayNames[i]);

            // Sélectionner uniquement les éléments présents dans commonObjects et subArray
            commonObjects = commonObjects.Intersect(subArray).ToArray();
        }

        return commonObjects;
    }

    private GameObject[] GetCommonObjectsByTag(string tagName)
    {
        GameObject[] objectsWithSameTag = GameObject.FindGameObjectsWithTag(tagName);
        return objectsWithSameTag;
    }

    private GameObject[] GetSubarrayByName(string subArrayName)
    {
        switch (subArrayName)
        {
            case "midCamp":
                return midCamp;
            case "groundCamp":
                return groundCamp;
            case "topCamp":
                return topCamp;
            case "Camp1":
                return Camp1;
            case "Camp2":
                return Camp2;
            case "Camp3":
                return Camp3;     
            default:
                return new GameObject[0];
        }
    }
    
    private void TrierListe()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[i].name.Contains("BRRCamp1", StringComparison.OrdinalIgnoreCase))
            {
                createdCamp1.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("BRR", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdCamp1.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("BRRCamp2", StringComparison.OrdinalIgnoreCase))
            {
                createdCamp2.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("BRR", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdCamp2.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("BRRCamp3", StringComparison.OrdinalIgnoreCase))
            {
                createdCamp3.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("BRR", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdCamp3.Add(createdObjects[j]);
                }
            }
        }
    }

    
    public void DestroyHouse(int DestroyValue)
    {
        TrierListe();
        if(DestroyValue==10)
        {
            foreach (GameObject obj in createdCamp1)
            {
                Destroy(obj);
            }
            createdCamp1.Clear();
        }

        if(DestroyValue==11)
        {
            foreach (GameObject obj in createdCamp2)
            {
                Destroy(obj);
            }
            createdCamp2.Clear();
        }

        if(DestroyValue==12)
        {
            foreach (GameObject obj in createdCamp3)
            {
                Destroy(obj);
            }
            createdCamp3.Clear();
        }
        
        
        createdObjects.Clear();
 
    }

    public void MoveObjects(float xValue, float zValue)
    {
        foreach (GameObject obj in createdObjects)
        {
            // Déplace chaque objet en ajoutant xValue à la coordonnée x et zValue à la coordonnée z
            obj.transform.Translate(new Vector3(zValue, xValue,0f));
        }
    }  
} 
