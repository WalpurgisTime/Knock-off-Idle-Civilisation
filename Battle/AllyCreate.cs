using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace YourNamespace
{
    public class AllyCreate : MonoBehaviour
    {
        public Allytest allyTestScript;
        public GameObject WarriorPrefab;
        public Vector3 newPosition;
        private List<WarriorInfo> myWarriorList = new List<WarriorInfo>();
        private int randomIndex;

        public void StartCreate()
        {
            if (allyTestScript == null)
            {
                Debug.LogError("Veuillez attacher le script AllyTest à cet objet.");
                return;
            }

            if (allyTestScript.myGameObjectInfo.waypoints == null || allyTestScript.myGameObjectInfo.waypoints.Length == 0)
            {
                Debug.LogError("Le script AllyTest doit avoir des waypoints définis.");
                return;
            }

            CreateWarriors();
            WarriorPrefab.SetActive(false);

            foreach (var warriorInfo in myWarriorList)
            {
                warriorInfo.health = allyTestScript.myGameObjectInfo.health + randomIndex;
                warriorInfo.startHealth = allyTestScript.myGameObjectInfo.startHealth + randomIndex;
                warriorInfo.movementSpeed = allyTestScript.myGameObjectInfo.movementSpeed;
                warriorInfo.sphereRadius = allyTestScript.myGameObjectInfo.sphereRadius;
                warriorInfo.isDead = allyTestScript.myGameObjectInfo.isDead;
                warriorInfo.damage = allyTestScript.myGameObjectInfo.damage;
                warriorInfo.target = allyTestScript.myGameObjectInfo.target;
                warriorInfo.className = allyTestScript.myGameObjectInfo.className;
                warriorInfo.bullet = allyTestScript.myGameObjectInfo.bullet;
                
                warriorInfo.particleEffectsChicken = allyTestScript.myGameObjectInfo.particleEffectsChicken;
                warriorInfo.particleEffectsBoom = allyTestScript.myGameObjectInfo.particleEffectsBoom;
            }
        }


        private void CreateWarriors()
        {
            int totalWarriorCount = 0;

            for (int i = 0; i < allyTestScript.myGameObjectInfo.waypoints.Length; i++)
            {
                totalWarriorCount += allyTestScript.myGameObjectInfo.waypoints[i].waypointIndex;
            }

            newPosition = Vector3.zero;

            for (int i = 0; i < allyTestScript.myGameObjectInfo.waypoints.Length; i++)
            {
                GameObject shopToModify  = GameObject.Find("ShopCreated");
                NodeButton shopToModifySctipt = shopToModify.GetComponent<NodeButton>();
                int index = 0;
                if(WarriorPrefab.name == "AllyShielder")
                {
                    foreach(NodeData element in shopToModifySctipt.nodeList)
                    {
                        if(element.nodeName=="ArcherCreated" && element.DoneOrNot == false)
                        {
                            index = shopToModifySctipt.nodeList.IndexOf(element);
                            allyTestScript.myGameObjectInfo.waypoints[element.nodeIndex].waypointTransform.position = shopToModifySctipt.nodeList[index].nodePosition;
                            shopToModifySctipt.nodeList[index].DoneOrNot = true;
                            break;
                        }              
                    }
                    
                    
                }
                if(WarriorPrefab.name == "AllyArcher")
                {
                    foreach(NodeData element in shopToModifySctipt.nodeList)
                    {
                        if(element.nodeName=="ShielderCreated"&& element.DoneOrNot == false)
                        {
                            index = shopToModifySctipt.nodeList.IndexOf(element);
                            allyTestScript.myGameObjectInfo.waypoints[element.nodeIndex].waypointTransform.position = shopToModifySctipt.nodeList[index].nodePosition;
                            shopToModifySctipt.nodeList[index].DoneOrNot = true;
                            break;
                        }              
                    }

                }
                if(WarriorPrefab.name == "AllySword")
                {
                    foreach(NodeData element in shopToModifySctipt.nodeList)
                    {
                        if(element.nodeName=="SwordCreated"&& element.DoneOrNot == false)
                        {
                            index = shopToModifySctipt.nodeList.IndexOf(element);
                            allyTestScript.myGameObjectInfo.waypoints[element.nodeIndex].waypointTransform.position = shopToModifySctipt.nodeList[index].nodePosition;
                            shopToModifySctipt.nodeList[index].DoneOrNot = true;
                            break;
                        }              
                    }

                }

                for (int j = 0; j < allyTestScript.myGameObjectInfo.waypoints[i].waypointIndex; j++)
                {   
                    //Debug.Log(gameObject.name+allyTestScript.myGameObjectInfo.waypoints[i].waypointTransform.position + newPosition.ToString());
                    GameObject newWarrior = Instantiate(WarriorPrefab, allyTestScript.myGameObjectInfo.waypoints[i].waypointTransform.position + newPosition, Quaternion.identity);

                    WarriorInfo warriorInfo = newWarrior.AddComponent<WarriorInfo>();
                    int randomIndex = Random.Range(-100, 100);

                    warriorInfo.health = allyTestScript.myGameObjectInfo.health + randomIndex;
                    warriorInfo.startHealth = allyTestScript.myGameObjectInfo.startHealth + randomIndex;
                    warriorInfo.movementSpeed = allyTestScript.myGameObjectInfo.movementSpeed;
                    warriorInfo.sphereRadius = allyTestScript.myGameObjectInfo.sphereRadius;
                    warriorInfo.isDead = allyTestScript.myGameObjectInfo.isDead;
                    warriorInfo.allyWarrior = newWarrior;
                    warriorInfo.damage = allyTestScript.myGameObjectInfo.damage;
                    warriorInfo.target = allyTestScript.myGameObjectInfo.target;
                    warriorInfo.className = allyTestScript.myGameObjectInfo.className;
                    warriorInfo.bullet = allyTestScript.myGameObjectInfo.bullet;
                    warriorInfo.particleEffectsChicken = allyTestScript.myGameObjectInfo.particleEffectsChicken;
                    warriorInfo.particleEffectsBoom = allyTestScript.myGameObjectInfo.particleEffectsBoom;

                    myWarriorList.Add(warriorInfo);

                    newPosition.z += 1;
                }

                newPosition.z -= allyTestScript.myGameObjectInfo.waypoints[i].waypointIndex;
            }
        }
    }
}
