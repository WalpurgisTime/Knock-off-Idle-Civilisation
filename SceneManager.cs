using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad1 = "1er scene"; // Remplacez par le nom de votre première scène
    public string sceneToLoad2 = "Battle"; // Remplacez par le nom de votre deuxième scène
    public Button boutonSwitch;

    public void KeyDown()
    {    
        if (boutonSwitch.IsInteractable())
        {
            SwitchScene();
        }
    }
    

    public void SwitchScene()
    {
        // Charger la première scène si la scène actuelle est la deuxième, et vice versa.
        string currentScene = SceneManager.GetActiveScene().name;
        string sceneToLoad = (currentScene == sceneToLoad1) ? sceneToLoad2 : sceneToLoad1;

        // Charger la scène sélectionnée.
        SceneManager.LoadScene(sceneToLoad);
    }
}
