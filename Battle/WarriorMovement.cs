using UnityEngine;

namespace YourNamespace
{
    public class WarriorMovement : MonoBehaviour
    {
        public void MoveWarrior(WarriorInfo warriorInfo, float movementSpeed)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(warriorInfo.target);
            Transform nearestTarget = FindNearestTarget(warriorInfo.allyWarrior.transform.position, targets);

            
            if (nearestTarget != null)
            {
                Vector3 targetPosition = nearestTarget.position;
                Vector3 direction = targetPosition - warriorInfo.allyWarrior.transform.position;
                Vector3 desiredPosition = warriorInfo.allyWarrior.transform.position + direction.normalized * 0.5f * movementSpeed * Time.deltaTime;

                float minX = -10;
                float maxX = 10;
                float minZ = -10;
                float maxZ = 10;

                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
                desiredPosition.z = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

                bool canMove = CanMoveToPosition(desiredPosition, warriorInfo.allyWarrior);

                if (canMove)
                {
                    Vector3 newPosition = new Vector3(desiredPosition.x, warriorInfo.allyWarrior.transform.position.y, desiredPosition.z);
                    warriorInfo.allyWarrior.transform.position = newPosition;
                }
            }
        }

        public bool CanMoveToPosition(Vector3 desiredPosition, GameObject currentWarrior)
        {
            float collisionRadius = 1f;
            Collider[] colliders = Physics.OverlapSphere(desiredPosition, collisionRadius, LayerMask.GetMask("Warrior"));

            foreach (var collider in colliders)
            {
                if (collider.gameObject != currentWarrior && Vector3.Distance(desiredPosition, collider.ClosestPoint(desiredPosition)) < collisionRadius)
                {
                    Debug.Log("Collision Detected with: " + collider.gameObject.name);
                    return false;
                }
            }

            return true;
        }

        public Transform FindNearestTarget(Vector3 position, GameObject[] targets)
        {
            Transform nearestTarget = null;
            float nearestDistance = float.MaxValue;

            foreach (var target in targets)
            {
                float distance = Vector3.Distance(position, target.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = target.transform;
                }
            }

            return nearestTarget;
        }
    }

    public class AttractionForce : MonoBehaviour
    {
        public float attractionForce = 5f;
        public float minAttractionDistance = 1f;

        void Update()
        {
            ApplyAttractionForce();
        }

        private void ApplyAttractionForce()
        {
            Vector3 center = Vector3.zero;
            Vector3 directionToCenter = center - transform.position;
            float distanceToCenter = directionToCenter.magnitude;

            // Vérifier si l'objet est suffisamment éloigné du centre
            if (distanceToCenter > minAttractionDistance)
            {
                // Utiliser une équation inverse proportionnelle pour régler la force
                float attractionStrength = attractionForce / Mathf.Pow(distanceToCenter, 2);
                Vector3 attractionVector = directionToCenter.normalized * attractionStrength;

                // Inverser la direction de la force
                attractionVector *= -1;

                // Appliquer la force au Rigidbody
                GetComponent<Rigidbody>().AddForce(attractionVector);
            }
        }
    }
}
