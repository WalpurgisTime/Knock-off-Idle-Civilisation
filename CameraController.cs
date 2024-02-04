using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public string targetTag = "VotreTag"; // Remplacez "VotreTag" par le tag que vous ciblez.
    public float rotationSpeed = 2.0f;
    public float cameraMoveSpeed = 10.0f; // Vitesse de rotation de la caméra.

    private Camera mainCamera;
    private Transform cameraTransform;
    private Vector3 originalCameraPosition;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion originalCameraRotation;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraTransform = mainCamera.transform;
        originalCameraPosition = cameraTransform.position;
        originalCameraRotation = cameraTransform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(targetTag))
            {
                targetPosition = hit.point;
                StartCoroutine(MoveCameraToTarget());
            }
        }

        // Rotation de la caméra en fonction des touches de direction gauche et droite.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        cameraTransform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
        cameraTransform.Rotate(Vector3.left, verticalInput * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.R)&& !isMoving)
        {
            ResetCameraRotation();
        }

        if (Input.GetKeyDown(KeyCode.G)&& !isMoving)
        {
            TopCameraPosition();
        }
        
    }

    private IEnumerator MoveCameraToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(cameraTransform.position, targetPosition) > 0.01f)
        {
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
            yield return null;
        }

        // Réinitialiser la caméra à sa position d'origine après le déplacement.
        isMoving = false;
    }

    private void ResetCameraRotation()
    {
        originalCameraRotation = Quaternion.Euler(0,0,0);
        cameraTransform.rotation = originalCameraRotation;
    }

    private void TopCameraPosition()
    {
        originalCameraRotation = Quaternion.Euler(90,0f,0);
        cameraTransform.rotation = originalCameraRotation;
        cameraTransform.position = new Vector3(0,30f,0);
    }
}
