using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ArrayContainer : MonoBehaviour
{
    public GameObject[] mid;
    public GameObject[] top;
    public GameObject[] ground;
    public GameObject[] corner;
    public GameObject[] roof;
    public GameObject[] symbol;
    public GameObject[] boulangerie;
    public GameObject[] armurerie;

    [HideInInspector]
    public GameObject[][] array;
    [HideInInspector]
    public Vector3 positionOffset;

    public float eulerRotation = 0f;

    [HideInInspector]
    public List<GameObject> createdObjects= new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdArmurerie = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> createdBoulangerie = new List<GameObject>();

    private Quaternion customRotation;

    private void Start()
    {
        // Initialisation du tableau principal (array) avec les sous-tableaux
        array = new GameObject[][]
        {
            mid,
            top,
            ground,
            corner,
            roof,
            symbol,
            boulangerie,
            armurerie
        };
    }

    public void BuildHouse(int length, int height, int width, Vector3 originalPositionOffset,string className)
    {
        positionOffset = originalPositionOffset ;
       
        float originalEulerRotation = eulerRotation;
        float lengthf = length;
        float widthf = width;

        positionOffset.y = -1f; 
        

        

        for (int v=0 ; v<2 ; v++)
        {   
            if(v==0)
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
                    float nombreFlottant = Convert.ToSingle(length);
                    positionOffset.x += nombreFlottant/2;
                    positionOffset.y += height;
                    var commonObjects1 = FindCommonGameObjects(new string[] { "symbol" });
                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-43f,13f, 81f));
                    _pillar.SetActive(true);
                    createdObjects.Add(_pillar);
                    positionOffset.x -= nombreFlottant/2;
                    positionOffset.y -= height;
                }

                if(height==1)
                {
                    positionOffset.x += lengthf/2;
                    positionOffset.z -= widthf/2; 
                    positionOffset.y+= height;
                    var commonObjects1 = FindCommonGameObjects(new string[] { "roof" });
                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                    positionOffset.x +=1;
                    _pillar.SetActive(true);
   
                    createdObjects.Add(_pillar);
                    Vector3 newScale = new Vector3(length, width, height); 
                    _pillar.transform.localScale = newScale;
                    positionOffset.y-= height;
                    positionOffset.x -= lengthf/2;
                    positionOffset.z += widthf/2;
                }
                else
                {
                    positionOffset.x += lengthf/2;
                    positionOffset.z -= widthf/2; 
                    positionOffset.y+= height-1;
                    var commonObjects1 = FindCommonGameObjects(new string[] { "roof" });
                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                    positionOffset.x +=1;
                    _pillar.SetActive(true);

                    createdObjects.Add(_pillar);
                    Vector3 newScale = new Vector3(length, width, height); //0,3 et 0.5
                    _pillar.transform.localScale = newScale;
                    positionOffset.y-= height-1;
                    positionOffset.x -= lengthf/2;
                    positionOffset.z += widthf/2;
                }
                
               
            }
           
            for (int i = 0 ; i < height; i++ )
            {
                for (int j = 0 ; j < length; j++ )
                {
                    if(j==0 )
                    {
                        if(v==0)
                        {
                            if(i==0)
                            {
                                var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                positionOffset.x -=1f;
                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                positionOffset.x +=1f;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                            else
                            {
                                if(i<height-1)
                                {
                                    if(v==0)
                                    {
                                        var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                        positionOffset.x -=1;
                                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                        positionOffset.x +=1;
                                        _pillar.SetActive(true);
                                        createdObjects.Add(_pillar);
                                    }
                                    
                                }
                            }
                        }
                        
                        
                    }

                    if(j==0 && i == height-1 && i!=0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "corner","top" });
                            int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                            positionOffset.x -=1;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                            positionOffset.x +=1;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                        
                    }
                    
                    if(i==0)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "ground" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(i!=0 && i==height-1)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "top" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(i>0 && i<height-1)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "mid" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(j == length-1 )
                    {   
                        if(v==0)
                        {
                            if(i==0)
                            {
                                var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                            else
                            {
                                if(i<height-1)
                                {
                                    var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                    _pillar.SetActive(true);
                                    createdObjects.Add(_pillar);
                                }
                            }
                        }
                        
                        
                    }

                    if( j==length-1 && i == height-1 && i!=0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "corner","top" });
                            int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                            positionOffset.x +=0.06f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                            positionOffset.x -=0.06f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                        
                    }
                

                    positionOffset.x +=1;
                    

                }

                positionOffset.x -= length;
                positionOffset.y += 1;

            }

            if(v==0)
            {
                positionOffset.x -= 1;
            }
            else
            {
                 positionOffset.x += length;
            }
            eulerRotation -=90f;
            positionOffset.y -= height;
            if(v==0)
            {
                positionOffset.z -= 0;
            }
            else
            {
                 positionOffset.z += width-1 ;
            }

            for (int i = 0 ; i < height; i++ )
            {
                for (int j = 0 ; j < width ; j++ )
                {
                    if(v==1)
                    {
                        if(j==0 )
                        {
                            if(i==0)
                            {
                                var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                positionOffset.z -=width-1;
                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                positionOffset.z +=width-1;
                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                            else
                            {
                                if(i<height-1)
                                {
                                    var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                    positionOffset.z -=width-1;
                                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                    positionOffset.z +=width-1;
                                    _pillar.SetActive(true);
                                    createdObjects.Add(_pillar);
                                }
                            }
                        } 
                    }

                    if(j==0 && i == height-1 && i!=0)
                    {
                        if(v==0)
                        {
                            var commonObjects1 = FindCommonGameObjects(new string[] { "corner","top" });
                            int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                            positionOffset.z -=1;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                            positionOffset.z +=1;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                        
                    }
                    
                    if(i==0)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "ground" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset,Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(i!=0 && i==height-1)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "top" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(i>0 && i<height-1)
                    {
                        var commonObjects1 = FindCommonGameObjects(new string[] { "mid" });
                        int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                        GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                        _pillar.SetActive(true);
                        createdObjects.Add(_pillar);
                    }

                    if(j == width-1  )
                    {   
                        if(v==0)
                        {
                            if(i==0)
                            {
                                var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                positionOffset.z-=1;
                                GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                positionOffset.z+=1;

                                _pillar.SetActive(true);
                                createdObjects.Add(_pillar);
                            }
                            else
                            {
                                if(i<height-1)
                                {
                                    var commonObjects1 = FindCommonGameObjects(new string[] { "corner","ground" });
                                    int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                                    positionOffset.z-=1;
                                    GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                                    positionOffset.z+=1;

                                    _pillar.SetActive(true);
                                    createdObjects.Add(_pillar);
                                }
                            }
                        }
                       
                        
                    }

                    if( j==width-1 && i == height-1 && i!=0)
                    {
                        if(v==1)
                        {   
                            var commonObjects1 = FindCommonGameObjects(new string[] { "corner","top" });
                            int randomIndex = UnityEngine.Random.Range(0, commonObjects1.Length);
                            positionOffset.z -=0.06f;
                            GameObject _pillar = Instantiate(commonObjects1[randomIndex], transform.position + positionOffset, Quaternion.Euler(-90f, eulerRotation, 0f));
                            positionOffset.z +=0.06f;
                            _pillar.SetActive(true);
                            createdObjects.Add(_pillar);
                        }
                    }
                        
                

                    positionOffset.z -=1;
                    

                }

                positionOffset.z += width;
                positionOffset.y += 1;

            }
            positionOffset.y-=height;

            positionOffset.z-=width;
            
            eulerRotation += 270f;
        }
        
        


        eulerRotation = originalEulerRotation;

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
            case "mid":
                return mid;
            case "top":
                return top;
            case "ground":
                return ground;
            case "corner":
                return corner;
            case "roof":
                return roof;
            case "symbol":
                return symbol;
            case "boulangerie":
                return boulangerie;
            case "armurerie":
                return armurerie;    
            default:
                return new GameObject[0];
        }
    }
    
    private void TrierListe()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[i].name.Contains("tagArmurerie", StringComparison.OrdinalIgnoreCase))
            {
                createdArmurerie.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("tag", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdArmurerie.Add(createdObjects[j]);
                }
            }

            if (createdObjects[i].name.Contains("tagBoulangerie", StringComparison.OrdinalIgnoreCase))
            {
                createdBoulangerie.Add(createdObjects[i]);

                for (int j = i + 1; j < createdObjects.Count; j++)
                {
                    if (createdObjects[j].name.Contains("tag", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    createdBoulangerie.Add(createdObjects[j]);
                }
            }
        }
    }

    
    public void DestroyHouse(int DestroyValue)
    {
        TrierListe();
        if(DestroyValue==1)
        {
            foreach (GameObject obj in createdArmurerie)
            {
                Destroy(obj);
            }
            createdArmurerie.Clear();
        }

        if(DestroyValue==0)
        {
            foreach (GameObject obj in createdBoulangerie)
            {
                Destroy(obj);
            }
            createdBoulangerie.Clear();
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
