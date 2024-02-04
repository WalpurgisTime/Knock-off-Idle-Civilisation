using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private float vitesseDeplacement = 1.5f;
    private Vector3 initialPosition;
    private List<Vector3> redCirclePositions;
    public int Health = 200;

    public Text Healthtext;
    public bool GameEnd = false;

    private bool AdditionConfirmed;



    public ShrinkingCercle shrinkingCercle;
    public GameObject redCanvas;

    public GameObject HealthCanvas;
    public Text Gain;
    public Text Perdu;
    public Button MainCanvas;
    public GameObject Canvas;

    public GameObject ButtonPanel;
    private bool IsGameFinished = true;

    public SwitchScene switchScene;
    public sauvegardeFonction sauvegardeFonction3;



    void Start()
    {
        // Store the initial position as the previous position
        initialPosition = transform.position;
        Healthtext.text = Health.ToString() ;
        redCanvas.SetActive(false);
        HealthCanvas.SetActive(false);
        ButtonPanel.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {
        if( switchScene.IsGameStarting)
        {
            HealthCanvas.SetActive(true);
    
            if(GameEnd == false )
            {
                if(Health==0)
                {
                    GameEnd = true;
                }
            
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    // Déplace le GameObject vers la gauche
                    transform.Translate(Vector3.left * vitesseDeplacement * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    // Déplace le GameObject vers la droite
                    transform.Translate(Vector3.right * vitesseDeplacement * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {

                    transform.Translate(Vector3.back * vitesseDeplacement * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    transform.Translate(Vector3.forward * vitesseDeplacement * Time.deltaTime);
                }

                
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
                        transform.position = initialPosition;
                        Health-=10;
                        Healthtext.text = Health.ToString();
                        redCanvas.SetActive(true);
                        
                        Invoke("RedCanbasBool",1f);
                    }
                    
                }
            }
            else
            {
                redCanvas.SetActive(IsGameFinished);
                HealthCanvas.SetActive(IsGameFinished);
                ButtonPanel.SetActive(true);
                Perdu.text = "Perdu";
                if (AdditionConfirmed==false)
                {
                    AdditionConfirmed=true;
                    float GainValue = 0.0f;
                    if(shrinkingCercle.DurationTime<30.0f)
                    {
                        GainValue = 0.5f;
                    }
                    if(shrinkingCercle.DurationTime<40.0f)
                    {
                        GainValue = 0.75f;
                    }
                    if(shrinkingCercle.DurationTime>=40.0f)
                    {
                        GainValue = 1.0f + (shrinkingCercle.DurationTime-40.0f)*0.01f;
                    }
                    Gain.text = "Le gain est de " + (sauvegardeFonction3.goldCoins*GainValue-sauvegardeFonction3.goldCoins).ToString();
                    sauvegardeFonction3.goldCoins = sauvegardeFonction3.goldCoins*GainValue;

                    
                    
                    

                }

            }
        }
    }

    public void OnClickMain()
    {
        if(MainCanvas.IsInteractable())
        {
            Canvas.SetActive(true);
            redCanvas.SetActive(false);
            
            IsGameFinished=false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Storm") && switchScene.IsGameStarting)
        {
            Health-=10;
            Healthtext.text = Health.ToString();
            redCanvas.SetActive(true);
            Invoke("RedCanbasBool",1f);
        }
    }

    private void RedCanbasBool()
    {
        redCanvas.SetActive(false);
    }


   
}
