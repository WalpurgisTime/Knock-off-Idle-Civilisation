using UnityEngine;
using YourNamespace;

public class SwordScript : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float damage = 10f; // Damage inflicted by the bullet

    private WarriorInfo sword;
    private Vector3 initialDirection;
    private bool Detruite;

    public Animator Spining;

    private sauvegardeFonction sauvegardeFonction3;



    private void Start()
    {
        // Store the initial direction when the bullet is instantiated
        Detruite = false;
        GameObject sauvegardeFonction = GameObject.Find("SauvegardeFonction");
        sauvegardeFonction sauvegardeFonction3 = sauvegardeFonction.GetComponent<sauvegardeFonction>();

        damage = sauvegardeFonction3.Damage*damage + damage;

        // If there's a shooter, adjust the initial direction towards the nearest enemy
        if (sword != null)
        {
            GameObject nearestEnemy = FindNearestEnemyInSphereRadius();

            if (nearestEnemy != null)
            {
                // Calculate the direction towards the nearest enemy
                initialDirection = (nearestEnemy.transform.position - transform.position).normalized;

            }
            
            
        } 

        Spining.speed = 2f;
        Spining.Play("SwordSlash");
        
    }

    public void SetSword(WarriorInfo warrior)
    {
        sword = warrior;
    }

    private void Update()
    {
        if (sword != null && !sword.gameObject.activeSelf)
        {
            // Désactivez le bouclier si le guerrier est désactivé
            Destroy(gameObject);
        }
        if (Spining != null && !Spining.GetCurrentAnimatorStateInfo(0).IsName("SwordSlash"))
        {
            // L'animation est terminée, faire quelque chose ici
            Invoke("DestroySword", 0.3f);
        }
        transform.Translate(initialDirection * speed * Time.deltaTime);
    }

    private void DestroySword()
    {
        Destroy(gameObject);
    }


    private GameObject FindNearestEnemyInSphereRadius()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(sword.GetTarget());

        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                // Check if the enemy is within the sphereRadius
                if (distance < sword.GetSphereRadius() + 1f)
                {
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestEnemy = enemy;
                    }
                }
            }
        }

        return nearestEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assurez-vous que shooter et other ne sont pas null avant d'y accéder
        if (sword != null && other != null )
        {
            // Vérifiez si l'objet en collision a le tag spécifié
            if (other.CompareTag(sword.target))
            {
                
                // Obtenez le composant WarriorInfo de l'objet touché
                WarriorInfo targetWarrior = other.GetComponent<WarriorInfo>();
                
                // Assurez-vous que le composant existe avant d'appeler TakeDamage
                if (targetWarrior != null)
                {
                    // Appelez TakeDamage sur l'objet touché
                    targetWarrior.TakeDamage(damage);
                    
                }
            }
        }
    }


}
