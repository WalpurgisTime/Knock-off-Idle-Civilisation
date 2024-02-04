using UnityEngine;
using UnityEngine.UI;

public class Ally : MonoBehaviour
{
    [System.Serializable]
    public class EnemyInfo
    {
        public GameObject enemyObject;
        public float distanceToEnemy; // Ajouter la distance à l'ennemi pour suivre celui qui est le plus proche
        // Ajoutez d'autres informations sur l'ennemi au besoin
    }

    public EnemyInfo[] enemiesArray;

    [System.Serializable]
    public class GameObjectInfo
    {
        public GameObject gameObject;
        public Image healthBarImage;
        public float health;
        public float startHealth;
        public float movementSpeed;
        public float sphereRadius;
        public bool isDead;

        public float damage;

        // Implémentation de l'interface ou classe de base commune
        public void TakeDamage(float amount)
        {
            health -= amount;

            // Utilisation de vos propres propriétés
            if (healthBarImage != null)
            {
                healthBarImage.fillAmount = health / startHealth;
            }

            if (health <= 0 && !isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            isDead = true;

            // Vérifier si l'objet a été détruit
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }

    public GameObjectInfo[] gameObjectsArray;

    void Update()
    {
        // Trouver l'ennemi le plus proche
        GameObjectInfo allyInfo = gameObjectsArray[0];
        GameObject nearestEnemy = FindNearestEnemy(allyInfo.gameObject.transform.position);

        if (nearestEnemy != null)
        {
            // Suivre l'ennemi le plus proche
            MoveTowardsEnemy(allyInfo, nearestEnemy);
        }
    }

    void MoveTowardsEnemy(GameObjectInfo allyInfo, GameObject enemy)
    {
        if (allyInfo.isDead) return; // Arrêter le mouvement si l'allié est mort

        // Logique pour se déplacer vers l'ennemi
        Vector3 directionToEnemy = (enemy.transform.position - allyInfo.gameObject.transform.position).normalized;
        Rigidbody rb = allyInfo.gameObject.GetComponent<Rigidbody>();

        RaycastHit hit;
        if (Physics.SphereCast(allyInfo.gameObject.transform.position, allyInfo.sphereRadius, directionToEnemy, out hit, allyInfo.movementSpeed * Time.deltaTime))
        {
            // Collision détectée avec le Sphere Collider
            Debug.Log("Collision détectée avec le Sphere Collider sur : " + allyInfo.gameObject.name);

            // Appliquer des dégâts à l'objet touché (si nécessaire)
            // ApplyDamage(allyInfo, hit.collider.gameObject);
        }
        else
        {
            // Pas de collision, déplacer l'allié vers l'ennemi
            rb.MovePosition(rb.position + directionToEnemy * allyInfo.movementSpeed * Time.deltaTime);
        }
    }

    GameObject FindNearestEnemy(Vector3 position)
    {
        float minDistance = float.MaxValue;
        GameObject nearestEnemy = null;

        foreach (EnemyInfo enemyInfo in enemiesArray)
        {
            float distance = Vector3.Distance(position, enemyInfo.enemyObject.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemyInfo.enemyObject;
            }
        }

        return nearestEnemy;
    }
}
