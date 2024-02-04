using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using YourNamespace;
using System.Collections.Generic;

public class NodeData
{
    public string nodeName;
    public int nodeIndex;
    public Vector3 nodePosition;
    public bool DoneOrNot;
    public string WaypointName;



    public NodeData(string name, int index, Vector3 position,bool Done,string Waypoint)
    {
        nodeName = name;
        nodeIndex = index;
        nodePosition = position;
        DoneOrNot = Done;
        WaypointName = Waypoint;
    }
}
public class NodeButton : MonoBehaviour
{
    public static NodeButton instance;

    public Button StartGame;
    public bool StartGameBool { get;  set; }

    public Button ArcherCreated;
    public bool ArcherToBuild { get; set; }
    private int isSetPositionClickedArcher = 0;

    public Button ShielderCreated;
    public bool ShielderToBuild { get; set; }
    private int isSetPositionClickedShielder = 0;

    public Button SwordCreated;
    public bool SwordToBuild { get; set; }
    private int isSetPositionClickedSword = 0;
    

    private string previousButton{ get; set; }
    private string wayPointName{ get; set; } 
    private Vector3 VectorWaypoint { get; set; }

    public Button AddShielder;
    public Text AddShielderText;
    private int AddShielderint = 1;

    public Button AddArcher;
    public Text AddArcherText;
    private int AddArcherint = 1;

    public Button AddSword;
    public Text AddSwordText;
    private int AddSwordint = 1;

    public GameObject Shielder;
    public GameObject Archer;
    public GameObject Sword;
    
    public List<NodeData> nodeList = new List<NodeData>();
    private int nbrIteration;

    public Text nombreRestantArcher;
    public Text nombreRestantShielder;
    public Text nombreRestantSword;

    public Text LocationOfEachNode;

    public PvP pvp;
    public bool Desactivate;
    private bool BoolBefore;

    public GameObject CanvasPerdu;
    public GameObject CanvasGagné;



    private void Awake()
    {
        instance = this;
        ArcherToBuild = true;
        ShielderToBuild = true;
        StartGameBool = false;
        previousButton = "ArcherCreated";
        Desactivate = false;
        BoolBefore = true;

    }

    public void OnclickButtonArcher()
    {
        if(ArcherCreated.IsInteractable())
        {
            ArcherToBuild = false;
            previousButton = "ArcherCreated";
            Desactivate = true;
        }

    }

    public void OnclickButtonShielder()
    {
        if(ShielderCreated.IsInteractable())
        {
            ShielderToBuild = false;
            previousButton = "ShielderCreated";
            Desactivate = true;
        }

    }
    public void OnclickButtonSword()
    {
        if(SwordCreated.IsInteractable())
        {
            SwordToBuild = false;
            previousButton = "SwordCreated";
            Desactivate = true;
            
        }

    }


    public void OnclickButtonAddArcher()
    {
        if(AddArcher.IsInteractable())
        {
            Desactivate = true;
            if(pvp.Started == true)
            {
                if(AddArcherint<2)
                {
                    AddArcherint++;
                    AddArcherText.text = "Archer : " + AddArcherint.ToString();
                }
                else
                {
                    AddArcherText.text = " Peu pas faire plus ";
                }
            }
            else
            {
                if(AddArcherint<4)
                {
                    AddArcherint++;
                    AddArcherText.text = "Archer : " + AddArcherint.ToString();
                }
                else
                {
                    AddArcherText.text = " Peu pas faire plus ";
                }
            }
            
        }

    }

    public void OnclickButtonAddShielder()
    {
        if(AddShielder.IsInteractable())
        {
            Desactivate = true;
            if(pvp.Started == true)
            {
                if(AddShielderint<2)
                {
                    AddShielderint ++;
                    AddShielderText.text = "Shielder" + AddShielderint.ToString();
                }
                else
                {
                    AddShielderText.text = "Peu pas faire plus ";
                }
            }
            else
            {
                if(AddShielderint<4)
                {
                    AddShielderint ++;
                    AddShielderText.text = "Shielder" + AddShielderint.ToString();
                }
                else
                {
                    AddShielderText.text = "Peu pas faire plus ";
                }
            }
            
            
        }

    }
    public void OnclickButtonAddSword()
    {
        if(AddSword.IsInteractable())
        {
            Desactivate = true;
            if(pvp.Started == true)
            {
                if(AddSwordint<2)
                {
                    AddSwordint ++;
                    AddSwordText.text = "Sword" + AddSwordint.ToString();
                }
                else
                {
                    AddSwordText.text = "Peu pas faire plus ";
                }
            }
            else
            {
                if(AddSwordint<4)
                {
                    AddSwordint ++;
                    AddSwordText.text = "Sword" + AddSwordint.ToString();
                }
                else
                {
                    AddSwordText.text = "Peu pas faire plus ";
                }
            }
            
            
        }

    }


    public void OnClickStartGame()
    {
        
        if(StartGame.IsInteractable())
        {
            foreach(NodeData element in nodeList)
            {
                Debug.Log(element.nodeName.ToString()+element.nodePosition.ToString()+element.nodeIndex.ToString());
            }


            StartGameBool=true;
            GameObject[] allObjectsNode = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjectsNode)
            {
                if (obj.name.StartsWith("Node"))
                {
                    obj.SetActive(false);
                }
                if(obj.name.StartsWith("Adetruire"))
                {
                    Destroy(obj);
                }
            }
            
            

        }
    }

    void Update()
    {
        if(StartGameBool && BoolBefore)
        {
            BoolBefore = false;
            Invoke("BoolBeforeStarting",5f);
            Debug.Log(BoolBefore.ToString() + " Je l'ai ecrit dsjfsdfhsfd");
            if(BoolBefore == true)
            {
                
            
                if(TousLesAlliesDesactives()==true)
                {
                    Debug.Log("Perdu");
                    StartGameBool = false;
                    BoolBefore = false;
                    CanvasPerdu.SetActive(true);
                    Invoke("CanvasDesactivate",4f);
                }

                if(TousLesEnemiesDesactives() == true)
                {
                    Debug.Log("Gagné");
                    StartGameBool = false;
                    BoolBefore = false;
                    CanvasGagné.SetActive(true);
                    Invoke("CanvasDesactivate",4f);
                }
            }
        }
    }

    private void BoolBeforeStarting()
    {
        BoolBefore = true;
    } 


    bool TousLesAlliesDesactives()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");

        foreach (GameObject ally in allies)
        {
            Debug.Log(ally.name);
            if (ally.name.StartsWith("Ally") && ally.activeSelf)
            {

                return false;

            }
        }

        // Tous les "Ally" sont désactivés
        return true;
    }

    bool TousLesEnemiesDesactives()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.name.StartsWith("Enemy") && enemy.activeSelf )
            {
                // Il y a au moins un "Ally" qui est activé
                return false;
            }
        }

        // Tous les "Ally" sont désactivés
        return true;
    }

    private void CanvasDesactivate()
    {
        CanvasPerdu.SetActive(false);
        CanvasGagné.SetActive(false);
    }


    public bool GetBoolStartGame()
    {
        return StartGameBool;
    }

    public void SetBoolStartGame(bool value)
    {
        StartGameBool = value;
        
    }

    public void SetPositionWaypoint(Vector3 value)
    {
        VectorWaypoint = value;
        if (previousButton == "ArcherCreated")
        {
            GameObject archerAllyObject = GameObject.Find("AllyArcher2");
            Allytest archerAllyScript = archerAllyObject.GetComponent<Allytest>();

            if(pvp.Started == true)
            {
                if(isSetPositionClickedArcher < 1)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedArcher;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointIndex = AddArcherint;
                    AddArcherint = 1;
                    AddArcherText.text = AddArcherint.ToString();
                    //archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointTransform.position = VectorWaypoint;
                    archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointName = wayPointName;

                    GameObject Archerprefab = Instantiate(Archer,VectorWaypoint,Quaternion.Euler(-90f, 0f, 0f));
                    Archerprefab.name = "Adetruire1";
                    //Debug.Log("Archer pour l'indice "+ isSetPositionClickedArcher.ToString() +archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointTransform.position.ToString());
                    isSetPositionClickedArcher++;
                    nombreRestantArcher.text = "Nombre restant de troupes  Archer: "+ (archerAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedArcher).ToString();
                    LocationOfEachNode.text+="\nArcher : " + VectorWaypoint.ToString() + wayPointName;
                

                }
                else
                {
                    nombreRestantArcher.text = "Nombre restant de troupes  Archer: impossible";
                }

            }
            else
            {
                if(isSetPositionClickedArcher < archerAllyScript.myGameObjectInfo.waypoints.Length)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedArcher;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointIndex = AddArcherint;
                    AddArcherint = 1;
                    AddArcherText.text = AddArcherint.ToString();
                    //archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointTransform.position = VectorWaypoint;
                    archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointName = wayPointName;

                    GameObject Archerprefab = Instantiate(Archer,VectorWaypoint,Quaternion.Euler(-90f, 0f, 0f));
                    Archerprefab.name = "Adetruire1";
                    //Debug.Log("Archer pour l'indice "+ isSetPositionClickedArcher.ToString() +archerAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedArcher].waypointTransform.position.ToString());
                    isSetPositionClickedArcher++;
                    nombreRestantArcher.text = "Nombre restant de troupes  Archer: "+ (archerAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedArcher).ToString();
                    LocationOfEachNode.text+="\nArcher : " + VectorWaypoint.ToString() + wayPointName;
                

                }
                else
                {
                    nombreRestantArcher.text = "Nombre restant de troupes  Archer: impossible";
                }
            }
            

            
        }

        if(previousButton == "ShielderCreated")
        {
            GameObject ShielderAllyObject = GameObject.Find("AllyShielder2");
            Allytest ShielderAllyScript = ShielderAllyObject.GetComponent<Allytest>();

            if(pvp.Started == true)
            {
                if(isSetPositionClickedShielder < 1)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedShielder;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointIndex = AddShielderint;
                    AddShielderint=1;
                    AddShielderText.text = AddShielderint.ToString();
                    //ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointTransform.position = VectorWaypoint;
                    ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointName = wayPointName;

                    GameObject Shielderprefab = Instantiate(Shielder,VectorWaypoint,Quaternion.Euler(-100f, 0f, 0f));
                    Shielderprefab.name = "Adetruire2";

                    //Debug.Log("Shielder pour l'indice : " + isSetPositionClickedShielder.ToString() + ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointTransform.position.ToString());
                    isSetPositionClickedShielder++;
                    nombreRestantShielder.text = "Nombre restant de troupes  Shielder: " + (ShielderAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedShielder).ToString();
                    LocationOfEachNode.text+="\nShielder : " + VectorWaypoint.ToString() + wayPointName;
                    
                }
            }
            else
            {
                if(isSetPositionClickedArcher < ShielderAllyScript.myGameObjectInfo.waypoints.Length)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedShielder;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointIndex = AddShielderint;
                    AddShielderint=1;
                    AddShielderText.text = AddShielderint.ToString();
                    //ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointTransform.position = VectorWaypoint;
                    ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointName = wayPointName;

                    GameObject Shielderprefab = Instantiate(Shielder,VectorWaypoint,Quaternion.Euler(-100f, 0f, 0f));
                    Shielderprefab.name = "Adetruire2";

                    //Debug.Log("Shielder pour l'indice : " + isSetPositionClickedShielder.ToString() + ShielderAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedShielder].waypointTransform.position.ToString());
                    isSetPositionClickedShielder++;
                    nombreRestantShielder.text = "Nombre restant de troupes  Shielder: " + (ShielderAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedShielder).ToString();
                    LocationOfEachNode.text+="\nShielder : " + VectorWaypoint.ToString() + wayPointName;
                
                
                    
                    
                }
                
            }


             
        }

        if(previousButton == "SwordCreated")
        {
            GameObject SwordAllyObject = GameObject.Find("AllySword2");
            Allytest SwordAllyScript = SwordAllyObject.GetComponent<Allytest>();
            
            if(pvp.Started == true)
            {
                if(isSetPositionClickedSword < 1)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedSword;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointIndex = AddSwordint;
                    AddSwordint=1;
                    AddSwordText.text = AddSwordint.ToString();
                    //SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointTransform.position = VectorWaypoint;
                    SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointName = wayPointName;

                    GameObject Swordprefab = Instantiate(Sword,VectorWaypoint,Quaternion.Euler(-100f, 0f, 0f));
                    Swordprefab.name = "Adetruire3";

                    //Debug.Log("Sword pour l'indice : " + isSetPositionClickedSword.ToString() + SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointTransform.position.ToString());
                    isSetPositionClickedSword++;
                    nombreRestantSword.text = "Nombre restant de troupes  Sword: " + (SwordAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedSword).ToString();
                    LocationOfEachNode.text+="\nSword : " + VectorWaypoint.ToString() + wayPointName;
                    
                }
            }
            else
            {
                if(isSetPositionClickedSword < SwordAllyScript.myGameObjectInfo.waypoints.Length)
                {
                    nodeList.Add(new NodeData("Node1", 1, new Vector3(1, 2, 3),false,""));
                    nodeList[nbrIteration].nodeName = previousButton;
                    nodeList[nbrIteration].nodeIndex = isSetPositionClickedSword;
                    nodeList[nbrIteration].nodePosition = VectorWaypoint;
                    nodeList[nbrIteration].WaypointName= wayPointName;
                    nbrIteration++;

                    SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointIndex = AddSwordint;
                    AddSwordint=1;
                    AddSwordText.text = AddSwordint.ToString();
                    //SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointTransform.position = VectorWaypoint;
                    SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointName = wayPointName;

                    GameObject Swordprefab = Instantiate(Sword,VectorWaypoint,Quaternion.Euler(-100f, 0f, 0f));
                    Swordprefab.name = "Adetruire3";

                    //Debug.Log("Sword pour l'indice : " + isSetPositionClickedSword.ToString() + SwordAllyScript.myGameObjectInfo.waypoints[isSetPositionClickedSword].waypointTransform.position.ToString());
                    isSetPositionClickedSword++;
                    nombreRestantSword.text = "Nombre restant de troupes  Sword: " + (SwordAllyScript.myGameObjectInfo.waypoints.Length-isSetPositionClickedSword).ToString();
                    LocationOfEachNode.text+="\nSword : " + VectorWaypoint.ToString() + wayPointName;
                    
                }
            }
        
             
        }
        

    }

    public void SetArcherToBuild(bool value)
    {
        ArcherToBuild = value;
    }

    public bool ArcherToBuildV1()
    {
        return ArcherToBuild;
    }

    public void SetShielderToBuild(bool value)
    {
        ShielderToBuild = value;
    }

    public bool ShielderToBuildV1()
    {
        return ShielderToBuild;
    }

    public void SetSwordToBuild(bool value)
    {
        SwordToBuild = value;
    }

    public bool SwordToBuildV1()
    {
        return SwordToBuild;
    }

    public void SetPreviousButtonToBuild(string value)
    {
        previousButton = value;
    }

    public string previousButtonv1()
    {
        return previousButton;
    }

    public void SetwaypointName(string value)
    {
        wayPointName = value;
    }

}
