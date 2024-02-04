using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ArrayButchery : MonoBehaviour
{
    public GameObject[] midButchery;
    public GameObject[] groundButchery;
    public GameObject[] Butchery1;
    public GameObject[] Butchery2;
    public GameObject[] Butchery3;

    [HideInInspector]
    public GameObject[][] array;
    [HideInInspector]
    public Vector3 positionOffset;

    public float eulerRotation = 0f;

    [HideInInspector]
    public List<GameObject> createdObjects= new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdButchery1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdButchery2 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdButchery3 = new List<GameObject>();

    private Quaternion customRotation;

    private void Start()
    {
        // Initialisation du tableau principal (array) avec les sous-tableaux
        array = new GameObject[][]
        {
            midButchery,
            groundButchery,
            Butchery1,
            Butchery2,
            Butchery3
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
            for (int j = 0 ; j < height; j++ )
            {                
                if(j==0)
                {
                    if(v==0)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "groundButchery" });
                        int randomIndex = UnityEngine.Random.Range(0, 1);
            
                        if(randomIndex==0)
                        {
                            positionOffset.y -= 0.3f;

                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                            positionOffset.y += 0.3f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                    }
                   

                }

                if(j>0)
                {
                    var commonObjects1 = FindCommonGameObjects(new string[] { "midButchery" });
                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                    float randomValueX = UnityEngine.Random.Range(-3, 3);
                    float randomValueZ = UnityEngine.Random.Range(-3, 3);
                    if (randomIndex == 0)
                    {
                        positionOffset.y -= 0.3f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(0f, 0f,0f));
                        positionOffset.y += 0.3f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }
                    if (randomIndex == 1)
                    {
                        positionOffset.y -= 0.3f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(0f, 0f,0f));
                        positionOffset.y += 0.3f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if (randomIndex == 3)
                    {
                        positionOffset.y -= 1.5f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-79f, -70f,30f));
                        positionOffset.y += 1.5f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if (randomIndex == 4)
                    {
                        positionOffset.y -= 0.3f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                        positionOffset.y += 0.3f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(randomIndex == 2)
                    {
                        positionOffset.y -=0f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-6f, -84f,50f));
                        positionOffset.y += 0f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }
                    
                    

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
            case "midButchery":
                return midButchery;
            case "groundButchery":
                return groundButchery;
            case "Butchery1":
                return Butchery1;
            case "Butchery2":
                return Butchery2;
            case "Butchery3":
                return Butchery3;     
            default:
                return new GameObject[0];
        }
    }
    
    private void TrierListe()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[i].name.Contains("APMButchery1", StringComparison.OrdinalIgnoreCase))
            {
                createdButchery1.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("APM", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdButchery1.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("APMButchery2", StringComparison.OrdinalIgnoreCase))
            {
                createdButchery2.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("APM", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdButchery2.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("APMButchery3", StringComparison.OrdinalIgnoreCase))
            {
                createdButchery3.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("APMButchery3", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdButchery3.Add(createdObjects[j]);
                }
            }
        }
    }

    
    public void DestroyHouse(int DestroyValue)
    {
        TrierListe();
        if(DestroyValue==5)
        {
            foreach (GameObject obj in createdButchery1)
            {
                Destroy(obj);
            }
            createdButchery1.Clear();
        }

        if(DestroyValue==6)
        {
            foreach (GameObject obj in createdButchery2)
            {
                Destroy(obj);
            }
            createdButchery2.Clear();
        }

        if(DestroyValue==7)
        {
            foreach (GameObject obj in createdButchery3)
            {
                Destroy(obj);
            }
            createdButchery3.Clear();
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
