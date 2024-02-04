using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ArrayArmurerie : MonoBehaviour
{
    public GameObject[] midArmoury;
    public GameObject[] topArmoury;
    public GameObject[] groundArmoury;
    public GameObject[] cornerArmoury;
    public GameObject[] roofArmoury;
    public GameObject[] symbolArmoury;
    public GameObject[] Armoury1;
    public GameObject[] Armoury2;
    public GameObject[] Armoury3;

    [HideInInspector]
    public GameObject[][] array;
    [HideInInspector]
    public Vector3 positionOffset;

    public float eulerRotation = 0f;

    [HideInInspector]
    public List<GameObject> createdObjects= new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdArmoury1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdArmoury2 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdArmoury3 = new List<GameObject>();

    private Quaternion customRotation;

    private void Start()
    {
        // Initialisation du tableau principal (array) avec les sous-tableaux
        array = new GameObject[][]
        {
            midArmoury,
            topArmoury,
            groundArmoury,
            cornerArmoury,
            roofArmoury,
            symbolArmoury,
            Armoury1,
            Armoury2,
            Armoury3
        };
    }

    public void BuildHouse(int length, int height, int width, Vector3 originalPositionOffset,string className)
    {
        positionOffset = originalPositionOffset ;
       
        float originalEulerRotation = eulerRotation;
        float lengthf = length;
        float widthf = width;

        positionOffset.y = -3f; 
        
        for (int v=0 ; v<1 ; v++)
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

            if(v==0)
            {
                positionOffset.x -= 0.5f;
                positionOffset.y += height;
                var commonObjects1 = FindCommonGameObjects(new string[] { "symbolArmoury" });
                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(90f, eulerRotation, 0f));
                _pillar.SetActive(true);
                createdObjects.Add(_pillar);
                positionOffset.x += 0.5f;
                positionOffset.y -= height;
            }

            
            for (int i = 0 ; i < height; i++ )
            {
                eulerRotation=0f;
                for (int j = 0 ; j < length; j++ )
                {

                    
                    if(i==0)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "groundArmoury" });
                        int randomIndex = UnityEngine.Random.Range(0, 2);
            
                        if(randomIndex==0)
                        {
                            positionOffset.y += 0.5f;
                            positionOffset.x -= 1f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-12f, 270f+eulerRotation, -90f));
                            positionOffset.y -= 0.5f;
                            positionOffset.x += 1f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                       
                        if(randomIndex==1)
                        {
                            positionOffset.y += 0.7f;
                            positionOffset.x -= 1f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-54f, 90f+eulerRotation, -90f));
                            positionOffset.y -= 0.7f;
                            positionOffset.x += 1f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }

                    }

                
                    if(i>0 && i<height-1)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "midArmoury" });
                        int randomIndex = UnityEngine.Random.Range(0, 2);
                        if(randomIndex==0)
                        {
                            positionOffset.x -= 1f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f, 0f+eulerRotation));
                            positionOffset.x += 1f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                        if(randomIndex==1)
                        {
                            positionOffset.x -= 1f;
                            positionOffset.y += 0.61f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-40f, 90f+eulerRotation, -90f));
                            positionOffset.x += 1f;
                            positionOffset.y -= 0.61f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                        
                    }

                    if(i < height-1 )
                    {   
                        if(v==0)
                        {
                            if(j<length)
                            {
                                var commonObjects1 = FindCommonGameObjects(new string[] { "cornerArmoury","groundArmoury" });
                                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                positionOffset.x-=0.9f;
                                positionOffset.z-=0.1f;
                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, 0f, 0f));
                                positionOffset.x+=0.9f;
                                positionOffset.z+=0.1f;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                            
                        }
                        
                        
                    }

                    eulerRotation+= 360/length ;

                    if(eulerRotation<(360/length)*2)
                    {
                        positionOffset.x +=1;
                    }
                    
                    if(eulerRotation == (360/length)*2)
                    {
                        positionOffset.x +=Mathf.Cos(45* Mathf.PI / 180f);
                        positionOffset.z -=Mathf.Cos(45* Mathf.PI / 180f);
                    }
                    if(eulerRotation == (360/length)*3)
                    {
                        
                        positionOffset.z -= 1f;
                    }

                    if(eulerRotation == (360/length)*4)
                    {
                        
                        positionOffset.z -=Mathf.Cos(45* Mathf.PI / 180f);
                        positionOffset.x -=Mathf.Cos(45* Mathf.PI / 180f);
                    }

                    if(eulerRotation == (360/length)*5)
                    {
                        
                        
                        positionOffset.x -=1;
                    }

                    if(eulerRotation == (360/length)*6)
                    {
                        
                        positionOffset.z +=Mathf.Cos(45* Mathf.PI / 180f);
                        positionOffset.x -=Mathf.Cos(45* Mathf.PI / 180f);
                    }

                    if(eulerRotation==(360/length)*7)
                    {
                        positionOffset.z +=1f;
                    }

                    
                    
                }

                positionOffset.y += 1;
                positionOffset.x+= Mathf.Cos(45* Mathf.PI / 180f);
                positionOffset.z += Mathf.Cos(45* Mathf.PI / 180f);
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
            case "midArmoury":
                return midArmoury;
            case "topArmoury":
                return topArmoury;
            case "groundArmoury":
                return groundArmoury;
            case "cornerArmoury":
                return cornerArmoury;
            case "roofArmoury":
                return roofArmoury;
            case "symbolArmoury":
                return symbolArmoury;
            case "Armoury1":
                return Armoury1;
            case "Armoury2":
                return Armoury2;
            case "Armoury3":
                return Armoury3;     
            default:
                return new GameObject[0];
        }
    }
    
    private void TrierListe()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[i].name.Contains("DLSArmoury1", StringComparison.OrdinalIgnoreCase))
            {
                createdArmoury1.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("DLS", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdArmoury1.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("DLSArmoury2", StringComparison.OrdinalIgnoreCase))
            {
                createdArmoury2.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("DLS", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdArmoury2.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("DLSArmoury3", StringComparison.OrdinalIgnoreCase))
            {
                createdArmoury3.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("DLS", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdArmoury3.Add(createdObjects[j]);
                }
            }
        }
    }

    
    public void DestroyHouse(int DestroyValue)
    {
        TrierListe();
        if(DestroyValue==2)
        {
            foreach (GameObject obj in createdArmoury1)
            {
                Destroy(obj);
            }
            createdArmoury1.Clear();
        }

        if(DestroyValue==3)
        {
            foreach (GameObject obj in createdArmoury2)
            {
                Destroy(obj);
            }
            createdArmoury2.Clear();
        }

        if(DestroyValue==4)
        {
            foreach (GameObject obj in createdArmoury3)
            {
                Destroy(obj);
            }
            createdArmoury3.Clear();
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
