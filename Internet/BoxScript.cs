using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab;

    void Start()
    {
        Invoke("Death", 2.4f);

        // Instancier le système de particules
        ParticleSystem particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        particleSystemInstance.Play();

    }

    void Death()
    {
        Destroy(gameObject);
    }


}
