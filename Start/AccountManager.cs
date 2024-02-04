using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;

public class AccountManager : MonoBehaviour
{
    public InputField loginEmailInput;
    public InputField loginPasswordInput;

    public InputField signupUsernameInput;
    public InputField signupEmailInput;
    public InputField signupPasswordInput;
    public InputField signupConfirmPasswordInput;

    public Button loginButton;
    public Button signupButton;

    public Canvas canvasToDisable;
    public Canvas canvasActive;

    public string email;
    public sauvegardeFonction sauvegardeFonction;

    public Leaderboard leaderboard;
    public UploadManager uploadManager;
    public string json;

    private void Start()
    {
        canvasActive.gameObject.SetActive(false);
        //StartCoroutine(SetupRoutine());
    }

    //IEnumerator SetupRoutine()
    //{
        //yield return leaderboard.FetchTopHighscoresRoutine();
    //}

    public void LogIn()
    {
       
        {
            email = loginEmailInput.text;
            string password = loginPasswordInput.text;

            // Vérifiez que les champs ne sont pas vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Debug.Log("Veuillez remplir tous les champs.");
                return;
            }

            // Appelez la méthode de connexion de LootLocker
            LootLockerSDKManager.WhiteLabelLoginAndStartSession(email, password, false, response =>
            {
                if (!response.success)
                {
                    Debug.Log("Erreur lors de la connexion : " + response.errorData.message);
                    return;
                }

                Debug.Log("Connexion réussie !");

                canvasToDisable.gameObject.SetActive(false);
                canvasActive.gameObject.SetActive(true);
                if(email == "jouanh5@hotmail.com")
                {
                   json = "/InventoryData.json";
                }
                if(email == "julojannot@gmail.com")
                {
                    json = "/InventoryData2.json";
                }
                sauvegardeFonction.LoadDataFromJson(0);

                




                // Gérez ici la suite du processus après la connexion
            });
        }
        
    }

    public void CreateAccount()
    {
        
        string username = signupUsernameInput.text;
        string email = signupEmailInput.text;
        string password = signupPasswordInput.text;
        string confirmPassword = signupConfirmPasswordInput.text;

        // Vérifiez que les champs ne sont pas vides
        if (loginButton.IsInteractable())
        {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                Debug.Log("Veuillez remplir tous les champs.");
                return;
            }

            // Vérifiez que les mots de passe correspondent
            if (password != confirmPassword)
            {
                Debug.Log("Les mots de passe ne correspondent pas.");
                return;
            }

            // Appelez la méthode de création de compte de LootLocker
            LootLockerSDKManager.WhiteLabelSignUp(email, password, (response) =>
            {
                if (!response.success)
                {
                    Debug.Log("Erreur lors de la création du compte : " + response.errorData.message);
                    return;
                }

                Debug.Log("Compte créé avec succès !");
            });
        }
        
    }
}
