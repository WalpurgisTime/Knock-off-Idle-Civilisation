using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ArrayForge : MonoBehaviour
{
    public GameObject[] midForge;
    public GameObject[] groundForge;
    public GameObject[] topForge;
    public GameObject[] roofForge;
    public GameObject[] Forge1;
    public GameObject[] Forge2;


    [HideInInspector]
    public GameObject[][] array;
    [HideInInspector]
    public Vector3 positionOffset;

    public float eulerRotation = 0f;

    [HideInInspector]
    public List<GameObject> createdObjects= new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdForge1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdForge2 = new List<GameObject>();

    private Quaternion customRotation;

    private void Start()
    {
        // Initialisation du tableau principal (array) avec les sous-tableaux
        array = new GameObject[][]
        {
            midForge,
            groundForge,
            topForge,
            roofForge,
            Forge1,
            Forge2
 
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
                if(v==0)
                {
                    if(j==0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "groundForge" });
                            int randomIndex = UnityEngine.Random.Range(0, 1);
                
                            if(randomIndex==0)
                            {
                                positionOffset.y -= 0.3f;

                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(0f, 90f,0f));
                                positionOffset.y += 0.3f;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                        }
                    

                    }
                    if(j==0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "midForge" });
                            int randomIndex = UnityEngine.Random.Range(0, 1);
                
                            if(randomIndex==0)
                            {
                                positionOffset.y -= 0.3f;
                                positionOffset.x -= 3f;

                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                                positionOffset.y += 0.3f;
                                positionOffset.x += 3f;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                        }
                    

                    }
                    if(j==0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "topForge" });
                            int randomIndex = UnityEngine.Random.Range(0, 1);
                
                            if(randomIndex==0)
                            {
                                positionOffset.y += 0.3f;
                                positionOffset.z += 1f;

                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(90f, 180f,0f));
                                positionOffset.y -= 0.3f;
                                positionOffset.z -= 1f;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                        }
                    

                    }
                }            
                

                if(j>0)
                {
                    var commonObjects1 = FindCommonGameObjects(new string[] { "roofForge" });
                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                    float randomValueX = UnityEngine.Random.Range(-3, 3);
                    float randomValueZ = UnityEngine.Random.Range(-4, 0);
                    if (randomIndex == 0)
                    {
                        positionOffset.y -= 0.15f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(0f, 0f,0f));
                        positionOffset.y += 0.15f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }
                    if (randomIndex == 1)
                    {
                        positionOffset.y -= 0.15f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(0f, 0f,0f));
                        positionOffset.y += 0.15f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if (randomIndex == 3)
                    {
                        positionOffset.y -= 0.15f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-79f, -70f,30f));
                        positionOffset.y += 0.15f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if (randomIndex == 4)
                    {
                        positionOffset.y -= 0.1f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                        positionOffset.y += 0.1f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(randomIndex == 2)
                    {
                        positionOffset.y -=0.1f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                        positionOffset.y += 0.1f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }
                    if(randomIndex == 5)
                    {
                        positionOffset.y -=0.1f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f,0f));
                        positionOffset.y += 0.1f;
                        positionOffset.x += randomValueX;
                        positionOffset.z += randomValueZ;
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }
                    if(randomIndex == 6)
                    {
                        positionOffset.y -=0.1f;
                        positionOffset.x -= randomValueX;
                        positionOffset.z -= randomValueZ;
                        
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, -0f,0f));
                        positionOffset.y += 0.1f;
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
            case "midForge":
                return midForge;
            case "groundForge":
                return groundForge;
            case "topForge":
                return topForge;
            case "roofForge":
                return roofForge;
            case "Forge1":
                return Forge1;
            case "Forge2":
                return Forge2;    
            default:
                return new GameObject[0];
        }
    }
    
    private void TrierListe()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[i].name.Contains("GPTForge1", StringComparison.OrdinalIgnoreCase))
            {
                createdForge1.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("GPT", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdForge1.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("GPTForge2", StringComparison.OrdinalIgnoreCase))
            {
                createdForge2.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("GPT", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdForge2.Add(createdObjects[j]);
                }
            }

        }
    }

    
    public void DestroyHouse(int DestroyValue)
    {
        TrierListe();
        if(DestroyValue==8)
        {
            foreach (GameObject obj in createdForge1)
            {
                Destroy(obj);
            }
            createdForge1.Clear();
        }

        if(DestroyValue==9)
        {
            foreach (GameObject obj in createdForge2)
            {
                Destroy(obj);
            }
            createdForge2.Clear();
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
