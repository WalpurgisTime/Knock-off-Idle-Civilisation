using UnityEngine;
using YourNamespace;

public class ShieldScript : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float damage = 10f; // Damage inflicted by the bullet

    private WarriorInfo shield;
    private Vector3 initialDirection;

    private bool Detruite;


    public void SetShield(WarriorInfo warrior)
    {
        shield = warrior;
    }

    private void Update()
    {
        
        if (shield != null )
        {
            // Follow the warrior's position
            transform.position = shield.transform.position + new Vector3(-0f, 0f, 0.7f);
            
        }
        if (shield != null && !shield.gameObject.activeSelf)
        {
            // Désactivez le bouclier si le guerrier est désactivé
            Destroy(gameObject);
        }
    }





    private void OnTriggerEnter(Collider other)
    {
        // Assurez-vous que shooter et other ne sont pas null avant d'y accéder
        if (shield != null && other != null && other.gameObject.layer == LayerMask.NameToLayer("Chien"))
        {
            Debug.Log(shield.target);
            Debug.Log("Tag de l'objet touché : " + other.name);
            // Vérifiez si l'objet en collision a le tag spécifié
            if (other.CompareTag(shield.target))
            {
                

                // Obtenez le composant WarriorInfo de l'objet touché
                WarriorInfo targetWarrior = other.GetComponent<WarriorInfo>();
                
                // Assurez-vous que le composant existe avant d'appeler TakeDamage
                if (targetWarrior != null)
                {
                    // Appelez TakeDamage sur l'objet touché
                    targetWarrior.TakeDamage(damage);
                    Debug.Log("lu et degas pris");
                    
                }

                // Détruisez la balle
                Detruite = true;
            }
        }
    }


}
