using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using YourNamespace;
using System.Collections.Generic;

public class EvilNodeData
{
    public string nodeName;
    public int nodeIndex;
    public Vector3 nodePosition;

    public EvilNodeData(string name, int index, Vector3 position)
    {
        nodeName = name;
        nodeIndex = index;
        nodePosition = position;
    }
}
public class EvilNode : MonoBehaviour
{
    private List<EvilNodeData> nodeList = new List<EvilNodeData>();
    private List<int> listeDeChiffres = new List<int>();
    public GameObject Warrior;
    public GameObject Archer;
     public GameObject Sword;

    public Text LocationOfEachNode;
    public GameObject conteneur;
    public PvP pvp;

    void Start()
    {
        
        GameObject archerEnemyObject = GameObject.Find("EnemyArcher2");
        Allytest archerEnemyScript = archerEnemyObject.GetComponent<Allytest>();


        GameObject warriorEnemyObject = GameObject.Find("EnemyWarrior2");
        Allytest warriorEnemyScript = warriorEnemyObject.GetComponent<Allytest>();

        GameObject SwordEnemyObject = GameObject.Find("EnemySword2");
        Allytest SwordEnemyScript = SwordEnemyObject.GetComponent<Allytest>();


        int EnemyThere = warriorEnemyScript.myGameObjectInfo.waypoints.Length+archerEnemyScript.myGameObjectInfo.waypoints.Length+SwordEnemyScript.myGameObjectInfo.waypoints.Length;

        for (int i=0; i<EnemyThere;i++)
        {
            nodeList.Add(new EvilNodeData("Node1", 1, new Vector3(1, 2, 3)));
        }

        int nombreDeSousObjets = conteneur.transform.childCount;

        foreach (Transform child in conteneur.transform)
        {
            if(EnemyThere>0)
            {
                if(nombreDeSousObjets>EnemyThere)
                {
                    int valeurAleatoire = Random.Range(0, 10);
                    if (valeurAleatoire == 9)
                    {
                        int numberOfEnemies = Random.Range(1, 5);

                        int TrueNumberOfEnemies =  numberOfEnemies;
                        string nomDuSousObjet = child.name;
                        Vector3 positionDuSousObjet = child.position;
                        nodeList[EnemyThere-1].nodeName = nomDuSousObjet;
                        nodeList[EnemyThere-1].nodeIndex = TrueNumberOfEnemies;
                        nodeList[EnemyThere-1].nodePosition = positionDuSousObjet;
                        EnemyThere--;
                    }
                }
                else
                {
                    int numberOfEnemies = Random.Range(1, 5);
                    int TrueNumberOfEnemies =  numberOfEnemies;
                    string nomDuSousObjet = child.name;
                    Vector3 positionDuSousObjet = child.position;
                    nodeList[EnemyThere-1].nodeName = nomDuSousObjet;
                    nodeList[EnemyThere-1].nodeIndex = TrueNumberOfEnemies;
                    nodeList[EnemyThere-1].nodePosition = positionDuSousObjet;

                    EnemyThere--;
                }
                nombreDeSousObjets--; 
            }
                 
        }

        int TailledeListe = nodeList.Count-1;
        foreach (EvilNodeData element in nodeList)
        {
            //Debug.Log("Node Name: " + element.nodeName + ", Node Index: " + element.nodeIndex + ", Node Position: " + element.nodePosition);
            listeDeChiffres.Add(TailledeListe);
            TailledeListe--;
        }

        if(pvp.Started == true)
        {
            for (int j = 0; j < 2; j++)
            {
                int indice = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]+1);
                //Debug.Log("indice" + indice.ToString());
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointIndex = nodeList[indice].nodeIndex;
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointTransform.position = nodeList[indice].nodePosition;
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointName = nodeList[indice].nodeName;
                listeDeChiffres.Remove(indice);
                GameObject Warriorprefab = Instantiate(Warrior, nodeList[indice].nodePosition, transform.rotation);
                Warriorprefab.name = "Adetruire2";
                LocationOfEachNode.text += "\nWarrior : " + nodeList[indice].nodePosition.ToString() + nodeList[indice].nodeName + "avec " + nodeList[indice].nodeIndex.ToString() + "ennemis";
            }
    

            for (int i = 0; i < 2; i++)
            {

                int indice2 = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]);
                
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointIndex = nodeList[indice2].nodeIndex;
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointTransform.position = nodeList[indice2].nodePosition;
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointName = nodeList[indice2].nodeName;

                listeDeChiffres.RemoveAt(indice2);
                

                GameObject Archerprefab = Instantiate(Archer,nodeList[indice2].nodePosition,transform.rotation);
                Archerprefab.name = "Adetruire1";
                LocationOfEachNode.text+="\nArcher : " + nodeList[indice2].nodePosition.ToString() + nodeList[indice2].nodeName + "avec " + nodeList[indice2].nodeIndex.ToString() + "ennemies";

            }



            for (int i = 0; i < 2; i++)
            {

                //Debug.Log(listeDeChiffres[listeDeChiffres.Count-1]);
                int indice3 = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]);

            
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointIndex = nodeList[indice3].nodeIndex;
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointTransform.position = nodeList[indice3].nodePosition;
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointName = nodeList[indice3].nodeName;
                listeDeChiffres.RemoveAt(indice3);
                GameObject Swordprefab = Instantiate(Sword,nodeList[indice3].nodePosition,transform.rotation);
                Swordprefab.name = "Adetruire3";
                LocationOfEachNode.text+="\nSword : " + nodeList[indice3].nodePosition.ToString() + nodeList[indice3].nodeName + "avec " + nodeList[indice3].nodeIndex.ToString() + "ennemies";
            }
        }
        else
        {

        
            for (int j = 0; j < warriorEnemyScript.myGameObjectInfo.waypoints.Length; j++)
            {
                int indice = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]+1);
                //Debug.Log("indice" + indice.ToString());
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointIndex = nodeList[indice].nodeIndex;
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointTransform.position = nodeList[indice].nodePosition;
                warriorEnemyScript.myGameObjectInfo.waypoints[j].waypointName = nodeList[indice].nodeName;
                listeDeChiffres.Remove(indice);
                GameObject Warriorprefab = Instantiate(Warrior, nodeList[indice].nodePosition, transform.rotation);
                Warriorprefab.name = "Adetruire2";
                LocationOfEachNode.text += "\nWarrior : " + nodeList[indice].nodePosition.ToString() + nodeList[indice].nodeName + "avec " + nodeList[indice].nodeIndex.ToString() + "ennemis";
            }
    

            for (int i = 0; i < archerEnemyScript.myGameObjectInfo.waypoints.Length; i++)
            {

                int indice2 = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]);
                
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointIndex = nodeList[indice2].nodeIndex;
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointTransform.position = nodeList[indice2].nodePosition;
                archerEnemyScript.myGameObjectInfo.waypoints[i].waypointName = nodeList[indice2].nodeName;

                listeDeChiffres.RemoveAt(indice2);
                

                GameObject Archerprefab = Instantiate(Archer,nodeList[indice2].nodePosition,transform.rotation);
                Archerprefab.name = "Adetruire1";
                LocationOfEachNode.text+="\nArcher : " + nodeList[indice2].nodePosition.ToString() + nodeList[indice2].nodeName + "avec " + nodeList[indice2].nodeIndex.ToString() + "ennemies";

            }



            for (int i = 0; i < SwordEnemyScript.myGameObjectInfo.waypoints.Length; i++)
            {

                //Debug.Log(listeDeChiffres[listeDeChiffres.Count-1]);
                int indice3 = Random.Range(listeDeChiffres[0], listeDeChiffres[listeDeChiffres.Count-1]);

            
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointIndex = nodeList[indice3].nodeIndex;
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointTransform.position = nodeList[indice3].nodePosition;
                SwordEnemyScript.myGameObjectInfo.waypoints[i].waypointName = nodeList[indice3].nodeName;
                listeDeChiffres.RemoveAt(indice3);
                GameObject Swordprefab = Instantiate(Sword,nodeList[indice3].nodePosition,transform.rotation);
                Swordprefab.name = "Adetruire3";
                LocationOfEachNode.text+="\nSword : " + nodeList[indice3].nodePosition.ToString() + nodeList[indice3].nodeName + "avec " + nodeList[indice3].nodeIndex.ToString() + "ennemies";
            }
        }

    }
}