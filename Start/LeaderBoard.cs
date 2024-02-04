using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using LootLocker;
using System.Text.RegularExpressions;


public class Leaderboard : MonoBehaviour
{
    string leaderboardKey = "LeaderBoardIDle"; // Change the type to string
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    public InputField playerNameInputfield;

    public List<string> playerNamesList = new List<string>();
    public List<string> playerScoresList = new List<string>();

    public bool Updatebool;
    public int Value;

    private LootLockerServerApi lootLockerApiInstance;
    
    

    


    // Start is called before the first frame update
    void Start()
    {
        Updatebool = true;
        Value = 300;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            // Lancez votre coroutine ici
            if(Updatebool==true)
            {
                //SubmitScoreRoutine(Value);
                playerNamesList.Clear();
                playerScoresList.Clear();
                FetchTopHighscoresRoutine();
                Value++;

                Updatebool = false;
            }
        }
        else
        {
            Updatebool = true;
        }
    }

    public void SetPlayerName()
    {
        
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.errorData.message);
            }
        });
    }

    public void SubmitScoreRoutine(int scoreToUpload)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score");

            }
            else
            {
                Debug.Log("Failed" + response.errorData.message);

            }
        });
  
    }

    public void FetchTopHighscoresRoutine()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => // Replace ) with =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                lootLockerApiInstance = new LootLockerServerApi();
                string responseBody = LootLockerServerApi.LastResponseBody;

                string pattern = @"score\D+(\d+)";
    
                // Créer une correspondance avec le modèle
                MatchCollection matches = Regex.Matches(responseBody, pattern);

                // Parcourir tous les matches
                foreach (Match match in matches)
                {
                    // Extraire la valeur numérique du match
                    string scoreNumber = match.Groups[1].Value;

                    // Ajouter le score à la liste
                    playerScoresList.Add(scoreNumber);
                    tempPlayerScores +=  scoreNumber+ "\n";

                    // Afficher le score extrait dans la console (facultatif)
                    Debug.Log("Nombre extrait de la sous-chaîne de 'score': " + scoreNumber);
                }



                

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {

                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                        playerNamesList.Add(members[i].player.name);
                        
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                        playerNamesList.Add(members[i].player.id.ToString());
                       
                    }

                    
                    
                    tempPlayerNames += "\n";
                }


                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.errorData.message);

            }
        });
    }
}
