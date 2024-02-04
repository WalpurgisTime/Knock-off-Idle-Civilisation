using UnityEngine;
using YourNamespace;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float damage = 10f; // Damage inflicted by the bullet

    private WarriorInfo shooter;
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
        if (shooter != null)
        {
            GameObject nearestEnemy = FindNearestEnemyInSphereRadius();

            if (nearestEnemy != null)
            {
                // Calculate the direction towards the nearest enemy
                initialDirection = (nearestEnemy.transform.position - transform.position).normalized;

            }
            
        } 

        Spining.speed = 5f;
        Spining.Play("boom");     
        
    }

    public void SetShooter(WarriorInfo warrior)
    {
        shooter = warrior;
    }

    private void Update()
    {
        Move();
        Invoke("DestroyBullet", 5f);
    }

    private void Move()
    {
        if(!Detruite)
        {
            transform.Translate(initialDirection * speed * Time.deltaTime);
        }

           
    }

    // This method is called when the collider of the bullet intersects with another collider

    private void DestroyBullet()
    {
        // Destroy the bullet
        Destroy(gameObject);
    }

    private GameObject FindNearestEnemyInSphereRadius()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(shooter.GetTarget());

        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                // Check if the enemy is within the sphereRadius
                if (distance < shooter.GetSphereRadius() + 1f)
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
        if (shooter != null && other != null)
        {
            // Vérifiez si l'objet en collision a le tag spécifié
            if (other.CompareTag(shooter.target))
            {
                

                // Obtenez le composant WarriorInfo de l'objet touché
                WarriorInfo targetWarrior = other.GetComponent<WarriorInfo>();

                // Assurez-vous que le composant existe avant d'appeler TakeDamage
                if (targetWarrior != null)
                {
                    // Appelez TakeDamage sur l'objet touché
                    targetWarrior.TakeDamage(damage);
                }

                // Détruisez la balle
                Invoke("DestroyBullet", 1f);
                Detruite = true;
            }
        }
    }


}
