using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 

public class ShrinkingCercle : MonoBehaviour
{
    public float shrinkDuration = 5f;
    public float finalScale = 0.1f;
    
    private Vector3 initialScale;
    private float elapsedTime = 0f;
    private bool countdownBool = true;

    public float DurationTime = 0f;
    public Text TimeText;

    private float ShrinkingRadius = 5.8f;
    private float LastValue1;
    private float LastValue2;

    private bool Once = true;
    private bool Twice = true;

    public GameObject rat;
    public GameObject rat2;

    public List<Vector3> CirclePositions { get; private set; }
    public PlayerMovement playerMovement;

    public SwitchScene switchScene;
    

    void Start()
    {
        initialScale = transform.localScale;
        CirclePositions = new List<Vector3>();
       
    }

    void Update()
    {   
        if(playerMovement.GameEnd == false && switchScene.IsGameStarting )
        {
            DurationTime += Time.deltaTime;
            int durationTimeInt = Mathf.RoundToInt(DurationTime);
            TimeText.text = durationTimeInt.ToString() + " secondes";

            if(durationTimeInt == 20 && Once==true)
            {
                rat.SetActive(true);
                Once = false;
            }

            if(durationTimeInt == 40 && Twice == true)
            {
                rat2.SetActive(true);
                Twice = false;
            }
            DrawRedCircle(ShrinkingRadius);
            if (countdownBool == true)
            {
                Invoke("TempsAttente", 0.2f);
                Invoke("Shrinking", 0.2f);
                
            }
            countdownBool = false;
            DestroyCircle();
        }
    }

    void Shrinking()
    {
        ShrinkingRadius-=0.015f;
    }

    void TempsAttente()
    {
        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / shrinkDuration);
        float newScaleX = Mathf.Lerp(initialScale.x, finalScale, t);
        float newScaleY = Mathf.Lerp(initialScale.y, finalScale, t);

        transform.localScale = new Vector3(newScaleX, newScaleY, initialScale.z);

        if (elapsedTime >= shrinkDuration)
        {
            // Shrink is complete, you can add other actions here if necessary
            
        }
        countdownBool = true;
    }

    void DrawRedCircle(float radius)
    {
        // Create a new empty GameObject to hold the LineRenderer component
        LastValue1 = LastValue2;
        LastValue2 = DurationTime;
        GameObject circleObject = new GameObject("RedCircle"+LastValue2.ToString());
        

        // Attach LineRenderer component to the GameObject
        LineRenderer lineRenderer = circleObject.AddComponent<LineRenderer>();

        // Set LineRenderer properties
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Set the color to red
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // Set the number of positions (points) in the circle
        int numPositions = 300;

        // Set the positions (points) in the circle using polar coordinates
        Vector3[] positions = new Vector3[numPositions];

        for (int i = 0; i < numPositions; i++)
        {
            float theta = 2 * Mathf.PI * i / numPositions;
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            positions[i] = new Vector3(x, 0f + 0.2f, z);
        }

        // Set the positions to the LineRenderer
        lineRenderer.positionCount = numPositions;
        lineRenderer.SetPositions(positions);
        if (CirclePositions.Count > 1150)
        {
            CirclePositions.RemoveRange(0, 300);
        }
        CirclePositions.AddRange(positions);

        // Debug positions
        for (int i = 0; i < numPositions; i++)
        {
            //Debug.Log("Position " + i + ": " + positions[i]);
        }
    }

    void DestroyCircle()
    {
        Destroy(GameObject.Find("RedCircle"+LastValue1.ToString()));
        
    }

    public List<Vector3> GetCirclePositions()
    {
        return CirclePositions;
    }

}
