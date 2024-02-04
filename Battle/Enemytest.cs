using UnityEngine;
using UnityEngine.UI;

public class Enemytest : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectInfo
    {
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
                //Die();
            }
        }
    }

    public GameObjectInfo myGameObjectInfo; // This creates a single GameObjectInfo object

    // You can add other methods or code here as needed
}
