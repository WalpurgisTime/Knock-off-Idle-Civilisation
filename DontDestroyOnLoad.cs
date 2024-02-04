using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance;
    public GameObject[] objects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroy dans la scène");
            return;
        }

        instance = this;

        // Initialisez le tableau ici s'il n'a pas déjà été initialisé.
        if (objects == null)
            objects = new GameObject[0];

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }

        SceneManager.sceneLoaded += OnSceneLoaded; // Ajoutez cette ligne pour lier l'événement de chargement de scène.
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Désactive tous les objets au début, à l'exception du premier élément
        for (int i = 1; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }

        // Active les objets spécifiques à la scène actuelle
        switch (scene.name)
        {
            case "1er scene":
                //objects[1].SetActive(true);
                objects[2].SetActive(true);
                objects[1].SetActive(false); // Activer l'objet à l'index 3 dans "Battle"
                objects[3].SetActive(true);
                break;
            // Ajoutez d'autres cas pour d'autres scènes si nécessaire
            case "Battle":
                objects[2].SetActive(true);
                objects[1].SetActive(false); 
                objects[3].SetActive(true);
                break;
            case "Internet":
                objects[2].SetActive(false);
                objects[1].SetActive(false); 
                objects[3].SetActive(true);
                break;    
            case "strartGame":
                objects[3].SetActive(true); // Activer l'objet à l'index 3 pour les autres scènes
                break;
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
