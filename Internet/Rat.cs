using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rat : MonoBehaviour
{
    private float vitesseDeplacement = 2f;
    private Vector3 initialPosition;
    private List<Vector3> redCirclePositions;

    private Vector2 Direction;
    private Vector3 Movement;
    private bool RandomBoolFactor = true;
    private float DurationTime = 0f;

    public GameObject Trail;
    private bool TrailBool = true;


    public ShrinkingCercle shrinkingCercle;
    public PlayerMovement playerMovement;

    public SwitchScene switchScene;
    

    void Start()
    {
        
        // Store the initial position as the previous position
        initialPosition = transform.position;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Direction = randomDirection;
        Vector3 initialMovement = new Vector3(Direction.x, 0f,Direction.y);
        Movement = initialMovement;


    }
    
    // Update is called once per frame
    void Update()
    {
        if(playerMovement.GameEnd == false && switchScene.IsGameStarting)
        {
            DurationTime += Time.deltaTime;
            
            redCirclePositions = shrinkingCercle.GetCirclePositions();
            
            foreach (Vector3 position in redCirclePositions)
            {
            
                float roundedX = Mathf.Round(transform.position.x * 10f) / 10f;
                float roundedZ = Mathf.Round(transform.position.z * 10f) / 10f;

                // Arrondir les valeurs de position.x et position.z au dixième près
                float roundedTargetX = Mathf.Round(position.x * 10f) / 10f;
                float roundedTargetZ = Mathf.Round(position.z * 10f) / 10f;

                
                if (Mathf.Approximately(roundedX, roundedTargetX) && Mathf.Approximately(roundedZ, roundedTargetZ))
                {
                    // Si les positions en x et z sont égales, réinitialise la position du joueur à la position initiale
                    //transform.position = initialPosition;
                    if(RandomBoolFactor==true)
                    {
                        float randomFactor = 0.5f; 
                        Vector2 randomOffset = new Vector2(Random.Range(-randomFactor, randomFactor), Random.Range(-randomFactor, randomFactor));

                        Direction = -Direction + randomOffset;
                        RandomBoolFactor=false;
                        
                    }
                }
                if(RandomBoolFactor==false)
                {
                    Invoke("FunctionBool",0.2f);
                } 

                if(transform.position.z > 7 || transform.position.z < -7 )  
                {
                    transform.position = new Vector3(0f, 0.2f, 0f);
                }
                if(transform.position.x > 7 || transform.position.x < -7 )  
                {  
                    transform.position = new Vector3(0f, 0.2f, 0f);
                }
                
            }
            Vector3 initialMovement1 = new Vector3(Direction.x, 0f,Direction.y);
            Movement = initialMovement1;
            transform.Translate(Movement * vitesseDeplacement * Time.deltaTime, Space.World);

            float roundedDurationTime = (Mathf.Round(DurationTime * 10f) / 10f) * 10;

            int roundedInteger = Mathf.RoundToInt(roundedDurationTime);

            if (roundedInteger%4==0)
            {
                
                if (TrailBool == true)
                {
                    GameObject TrailBall = Instantiate(Trail, transform.position, transform.rotation);
                    TrailBool = false;
                }
                else
                {
                    Invoke("TrailBoolFunction",0.1f);
                }
            }
        }

         
   
    }

    void TrailBoolFunction()
    {
        TrailBool=true;
    }

    void FunctionBool()
    {
        RandomBoolFactor = true;
    }
  
}
