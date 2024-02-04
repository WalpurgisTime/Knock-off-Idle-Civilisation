using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeathParticleSystem",1f);
    }

    void DeathParticleSystem()
    {
        // Détruire le GameObject (l'instance spécifique du système de particules)
        Destroy(gameObject);
    }
}
