using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxColliderVisualizer : MonoBehaviour
{
    private void Start()
    {
        sauvegardeFonction sauvegardeFonction3 = FindObjectOfType<sauvegardeFonction>();

        if (sauvegardeFonction3 != null)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                // Set the size of the BoxCollider
                boxCollider.size = new Vector3(sauvegardeFonction3.length + 2, sauvegardeFonction3.height + 1, sauvegardeFonction3.width + 1);

                // Calculate the new position for the BoxCollider (top-right corner)
                Vector3 newPosition = transform.position +
                    transform.forward * (sauvegardeFonction3.length + 2) / 2f +
                    transform.right * (sauvegardeFonction3.width + 1) / 2f +
                    transform.up * (sauvegardeFonction3.height + 1) / 2f;

                boxCollider.center = transform.InverseTransformPoint(newPosition);
            }
            else
            {
                Debug.LogError("BoxCollider not found on the GameObject.");
            }
        }
        else
        {
            Debug.LogError("sauvegardeFonction3 not found in the scene.");
        }
    }


}
