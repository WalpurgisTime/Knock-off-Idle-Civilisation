using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // Cette méthode est appelée lorsque quelque chose entre dans le trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision a un tag spécifique
        if (other.CompareTag("NomDeVotreTag"))
        {
            Debug.Log("Collision détectée avec l'objet ayant le tag 'NomDeVotreTag'");
        }
        else
        {
            Debug.Log("Collision détectée avec un objet ne possédant pas le tag 'NomDeVotreTag'");
        }
    }

    // Cette méthode est appelée lorsque quelque chose sort du trigger
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Plus de collision avec l'objet ayant le tag 'NomDeVotreTag'");
    }
}
