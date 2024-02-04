using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public AnimationCurve curve;
    public float curveLength = 100f; // Longueur totale de la courbe
    public int numPoints = 100; // Nombre de points pour le Line Renderer
    public float lineWidth = 0.2f; // Largeur du Line Renderer
    public Vector2 startCoordinates = new Vector2(0f, 0f); // Coordonnées de début
    public Vector2 endCoordinates = new Vector2(10f, 10f); // Coordonnées de fin

    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("Veuillez attacher un Line Renderer à l'objet.");
            return;
        }

        lineRenderer.positionCount = numPoints;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        for (int i = 0; i < numPoints; i++)
        {
            float t = i / (float)(numPoints - 1);
            float x = Mathf.Lerp(startCoordinates.x, endCoordinates.x, t) + curveLength;
            float y = Mathf.Lerp(startCoordinates.y, endCoordinates.y, t) + curve.Evaluate(t);

            lineRenderer.SetPosition(i, new Vector3(x, y, 0f));
        }
    }

    void Update()
    {
        UpdateLineRenderer();
    }
}
