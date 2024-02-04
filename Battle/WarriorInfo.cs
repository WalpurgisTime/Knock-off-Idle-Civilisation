using UnityEngine;
using System.Collections;

namespace YourNamespace
{
    public class WarriorInfo : MonoBehaviour
    {
        public delegate void FireBulletHandler(Vector3 position);
        public event FireBulletHandler OnFireBullet;

        public float health;
        public float startHealth;
        public float movementSpeed;
        public float sphereRadius;
        public bool isDead;
        public GameObject allyWarrior;
        public float damage;
        public string target;
        public string className;

        public GameObject bullet;


        public float bulletSpeed;
        private GameObject healthBarsContainer;
        private bool isSpheresTouching = false;
        public GameObject particleEffectsBoom;
        public GameObject particleEffectsChicken;

        private sauvegardeFonction sauvegardeScript;
        private WarriorMovement warriorMovement;

        private bool isCoroutineRunningFire = false;
        private bool isCoroutineRunningSword = false;

        private void OnDrawGizmos()
        {
            // Vérifiez s'il y a des objets avec le tag spécifié dans la sphère de détection
            Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);

            if (colliders.Length > 0)
            {
                // Fix: Pass the WarriorInfo object and movementSpeed
                

                bool enemyPresent = false;

                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag(target))
                    {
                        enemyPresent = true;
                        break;
                    }
                }

                if (enemyPresent)
                {
                    
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.green;
                }
            }
            else
            {
                Gizmos.color = Color.green;
                
            }

            Gizmos.DrawWireSphere(transform.position, sphereRadius);
            
        }

        private void Start()
        {
            healthBarsContainer = transform.GetChild(0).gameObject;
            ActivateHealthBarContainer(healthBarsContainer);

            // Find sauvegardeScript by tag
            GameObject sauvegardeObject = GameObject.FindWithTag("YourSauvegardeScriptTag");
            GameObject warriorMove = GameObject.FindWithTag("warriorMove");

            sauvegardeScript = sauvegardeObject.GetComponent<sauvegardeFonction>();
            warriorMovement = warriorMove.GetComponent<WarriorMovement>();

            if(bullet.name == "Shield")
            {
                GameObject ShieldObject = Instantiate(bullet, transform.position, Quaternion.identity);
                ShieldScript ShieldInstance = ShieldObject.GetComponent<ShieldScript>();
                if (ShieldInstance != null)
                {
                    ShieldInstance.SetShield(this);
                }
            }
                    
            
        }

        private void ActivateHealthBarContainer(GameObject container)
        {
            if (container != null)
            {
                container.SetActive(true);
            }
        }

        private void Update()
        {
            //if (allyWarrior != null && className != "archer")
            //{
                //float distance = Vector3.Distance(transform.position, allyWarrior.transform.position);
                //float combinedRadius = sphereRadius + allyWarrior.GetComponent<WarriorInfo>().sphereRadius;

                //if (distance <= combinedRadius && !isSpheresTouching)
                //{
                    //StartCoroutine(DealDamagePeriodically());

                    //isSpheresTouching = true;
                //}
                //else if (distance > combinedRadius && isSpheresTouching)
                //{
                    //StopCoroutine(DealDamagePeriodically());
                    //isSpheresTouching = false;
                //}
            //}

            if (className == "Warrior")
            {
                float combinedRadius = sphereRadius;

                // Vérifiez s'il y a des objets avec le tag spécifié dans la sphère de détection
                Collider[] colliders = Physics.OverlapSphere(transform.position, combinedRadius);

                if (colliders.Length > 0)
                {
                    bool enemyPresent = false;
                
                    foreach (Collider collider in colliders)
                    {
                        
                        if (collider.CompareTag(target))
                        {
                            enemyPresent = true;
                            
                            break;
                        }
                    }

                    if(bullet.name == "Fire spell")
                    {
                        if (enemyPresent && !isCoroutineRunningFire)
                        {
                            StartCoroutine(CreateBulletPeriodically());
                        
                            isCoroutineRunningFire = true;
                        }

                        else if (!enemyPresent )
                        {
                            if (!isCoroutineRunningFire)
                            {
                                StopCoroutine(CreateBulletPeriodically());
                                isCoroutineRunningFire = false;
                            }
                            
                            
                            warriorMovement.MoveWarrior(this, 10);
                        }
                    }
                    if(bullet.name == "Sword")
                    {
                        if (enemyPresent && !isCoroutineRunningSword)
                        {
                            StartCoroutine(CreateSwordPeriodically());
                        
                            isCoroutineRunningSword = true;
                        }

                        else if (!enemyPresent )
                        {
                            if (!isCoroutineRunningSword)
                            {
                                StopCoroutine(CreateSwordPeriodically());
                                isCoroutineRunningSword = false;
                            }
                            
                            
                            warriorMovement.MoveWarrior(this, 10);
                        }
                    }
                    if(bullet.name == "Shield")
                    {

                        if (!enemyPresent )
                        {
                            
                            warriorMovement.MoveWarrior(this, 10);
                        }
                    }
                    
                }
            }
        }

        private void MoveHealthBars(float normalizedHealth)
        {
            if (healthBarsContainer != null)
            {
                Transform healthBarsTransform = healthBarsContainer.transform;
                float newScaleX = normalizedHealth;
                healthBarsTransform.localScale = new Vector3(newScaleX, healthBarsTransform.localScale.y, healthBarsTransform.localScale.z);
            }
        }

        //private IEnumerator DealDamagePeriodically()
        //{
            //while (!isDead)
            //{
                //TakeDamage(damage);
                //yield return new WaitForSeconds(2f);
            //}
        //}

        public void TakeDamage(float amount)
        {
            if (!isDead)
            {
                health -= amount;
                float normalizedHealth = health / startHealth;
                AdjustHealthBarWidth(normalizedHealth);

                if (health <= 0)
                {
                    Die();
                }
            }
        }

        private void AdjustHealthBarWidth(float normalizedHealth)
        {
            if (healthBarsContainer != null)
            {
                MoveHealthBars(normalizedHealth);
            }
        }

        private void Die()
        {
            isDead = true;
            GameObject chickenBoom = Instantiate(particleEffectsChicken, transform.position, Quaternion.identity);
            GameObject AllyBoom = Instantiate(particleEffectsBoom, transform.position, Quaternion.identity);

            Destroy(chickenBoom, 0.5f);
            Destroy(AllyBoom, 0.5f);

            gameObject.SetActive(false);


            // Check if sauvegardeScript is not null before using it
            if (sauvegardeScript != null && gameObject.name.Contains("Enemy"))
            {
                sauvegardeScript.LoadDataFromJson(0);
                sauvegardeScript.chicken += sauvegardeScript.chicken*0.1f;
                sauvegardeScript.SaveDataToJson(0);
            }
        }

        public Vector3 GetBuildPosition()
        {
            return transform.position;
        }


        private IEnumerator CreateBulletPeriodically()
        {

            
            while (!isDead)
            {
                // Recherchez tous les GameObjects avec le tag spécifié
                GameObject[] enemies = GameObject.FindGameObjectsWithTag(target);

                for (int i =enemies.Length-1 ; i > -1 ; i--)
                {
                    if (enemies[i] != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
                        if (distance < sphereRadius +0.1f)
                        {
                            //FireBullet(transform.position);
                            
                            // Ajoutez ici la logique pour instancier le projectile
                            if (bullet.name == "Sword")
                            {
                                
                                GameObject bulletObject = Instantiate(bullet, transform.position + new Vector3(0f,-1f,0f), Quaternion.identity);
                                BulletScript bulletInstance = bulletObject.GetComponent<BulletScript>();
                                bulletInstance.SetShooter(this);    
                            }
                            else
                            {
                                GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);
                                BulletScript bulletInstance = bulletObject.GetComponent<BulletScript>();
                                bulletInstance.SetShooter(this);    
                            }
                        }

                        break;
                    }
                }
         
                

                yield return new WaitForSeconds(2f);
            }
        }

        private IEnumerator CreateSwordPeriodically()
        {

            
            while (!isDead)
            {
                // Recherchez tous les GameObjects avec le tag spécifié
                GameObject[] enemies = GameObject.FindGameObjectsWithTag(target);

                for (int i =enemies.Length-1 ; i > -1 ; i--)
                {
                    if (enemies[i] != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
                        if (distance < sphereRadius +1f)
                        {
                            //FireBullet(transform.position);
                            
                            // Ajoutez ici la logique pour instancier le projectile
                            if (bullet != null)
                            {
                                
                                GameObject bulletObject = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);

                                SwordScript SwordInstance = bulletObject.GetComponent<SwordScript>();

                                if (SwordInstance != null)
                                {
                                    SwordInstance.SetSword(this); // Assuming this is the WarriorInfo instance firing the bullet.
                                }
                            }
                        }

                        break;
                    }
                }
         
                

                yield return new WaitForSeconds(2f);
            }
        }

        private void FireBullet(Vector3 position)
        {
            if (OnFireBullet != null)
            {
                OnFireBullet(position);
            }

            if (bullet != null)
            {
                //GameObject bulletInstance = Instantiate(bullet, position, Quaternion.identity);

                // Assuming you have a Rigidbody for physics on the bullet prefab
                //Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
                //if (bulletRb != null)
                //{
                    // Adjust bullet speed based on your requirements
                    //bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
                //}
            }
        }

        public string GetTarget()
        {
            return target;
        }

        public float GetSphereRadius()
        {
            return sphereRadius;
        }
    }
}
