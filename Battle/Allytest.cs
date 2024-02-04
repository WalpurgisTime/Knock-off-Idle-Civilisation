namespace YourNamespace
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Allytest : MonoBehaviour
    {
        public AllyCreate allyCreate;

        void Update()
        {
            if(NodeButton.instance.GetBoolStartGame()==true)
            {
                
                GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
                int allyArcherCount = 0;
                int allyShielderCount = 0;
                int allySwordCount = 0;
                int EnemyArcherCount = 0;
                int EnemyWarriorCount = 0;
                int EnemySwordCount = 0;

                foreach (GameObject obj in allObjects)
                {
                    if (obj.name.StartsWith("AllyArcher"))
                    {
                        allyArcherCount++;
                    }
                    if (obj.name.StartsWith("AllyShilder"))
                    {
                        allyShielderCount++;
                    }
                    if (obj.name.StartsWith("AllySword"))
                    {
                        allySwordCount++;
                    }
                    if (obj.name.StartsWith("EnemyArcher"))
                    {
                        EnemyArcherCount++;
                    }
                    if (obj.name.StartsWith("EnemyWarrior"))
                    {
                        EnemyWarriorCount++;

                    }
                    if (obj.name.StartsWith("EnemySword"))
                    {
                        EnemySwordCount++;

                    }

                }

                if(myGameObjectInfo.allyWarrior.name.StartsWith("AllyArcher"))
                {
                    //Debug.Log("Ally Creat");
                    if(myGameObjectInfo.waypoints[0].waypointIndex+1>allyArcherCount)
                    {  
                        
                        allyCreate.StartCreate();
                    }

                }

                if(myGameObjectInfo.allyWarrior.name.StartsWith("AllyShielder"))
                {
                    if(myGameObjectInfo.waypoints[0].waypointIndex+1>allyShielderCount)
                    {

                        allyCreate.StartCreate();

                    }

                }
                if(myGameObjectInfo.allyWarrior.name.StartsWith("AllySword"))
                {
                    if(myGameObjectInfo.waypoints[0].waypointIndex+1>allySwordCount)
                    {

                        allyCreate.StartCreate();

                    }

                }
                if(myGameObjectInfo.allyWarrior.name.StartsWith("EnemyWarrior"))
                {

                    
                    if(myGameObjectInfo.waypoints[0].waypointIndex+2>EnemyWarriorCount-1)
                    {
                        allyCreate.StartCreate();
                        EnemyWarriorCount++;
                           
                    }

                }
                if(myGameObjectInfo.allyWarrior.name.StartsWith("EnemySword"))
                {

                    
                    if(myGameObjectInfo.waypoints[0].waypointIndex+2>EnemySwordCount-1)
                    {
                        allyCreate.StartCreate();
                        EnemySwordCount++;
                           
                    }

                }

                if(myGameObjectInfo.allyWarrior.name.StartsWith("EnemyArcher"))
                {
                    if(myGameObjectInfo.waypoints[0].waypointIndex+1>EnemyArcherCount)
                    {
                        allyCreate.StartCreate();
                    }
                    else
                    {
                        NodeButton.instance.SetBoolStartGame(false);
                        
                    } 
    
                }

                
                
                
            }
        }

        [System.Serializable]
        public class WaypointData
        {
            public int waypointIndex;
            public string waypointName;
            public Transform waypointTransform;
        }

        [System.Serializable]
        public class GameObjectInfo
        {
            
            public float health;
            public float startHealth;
            public float movementSpeed;
            public float sphereRadius;
            public bool isDead;
            public GameObject allyWarrior;
            public float damage;
            public string target;
            public string className;
            public GameObject bullet;
            public GameObject particleEffectsChicken;
            public GameObject particleEffectsBoom;
            

            public WaypointData[] waypoints;

            // Implementation of the interface or common base class
            
        }

        public GameObjectInfo myGameObjectInfo;
     

        // You can add other methods or code here as needed
    }
}
