using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cameraTransform;
    private Vector3 originalCameraPosition;

    private BuildManager buildManager; 

    private void Awake()
    {
        buildManager = FindObjectOfType<BuildManager>(); // Trouvez le script BuildManager
        if (buildManager == null)
        {
            Debug.LogError("Aucun script BuildManager n'a été trouvé.");
        }

    }

    private void Start()
    {
        mainCamera = Camera.main;
        cameraTransform = mainCamera.transform;
        originalCameraPosition = cameraTransform.position;
    }

    private void OnApplicationQuit()
    {
        // Réinitialise la position de la caméra lorsque le jeu est quitté.
        cameraTransform.position = originalCameraPosition;   
    
    }
}
