using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using LootLocker.Requests;
using UnityEngine.Networking;

public class PvP : MonoBehaviour
{
    public NodeButton nodeButton;
    public Button buttonPvP;
    public Button StartbuttonPvP;
    public string scorePvP;
    private bool Clicked;
    public bool Started;

    public int WinningRate;
    private int Output; 

    public string AdresseEmail;
    public bool Perdu;
    
    public sauvegardeFonction sauvegardeFonction;
    private Leaderboard leaderBoard;
    private AccountManager AccountManager;
    public PvPSetUp pvpSetup;

    public Text ResultFight;

    public int pvpSetupValue;
    // Start is called before the first frame update
    void Start()
    {
        Clicked = true;
        scorePvP = "";
    }

    
    [System.Serializable]
    public class Donnees
    {
        public bool isActive;
        public string Date;
        public int jouanh5;
        public int jouanh2202;
    

        public int this[string email]
        {
            get
            {
                switch (email)
                {
                    case "jouanh5@hotmail.com":
                        return jouanh5;
                    case "julojannot@gmail.com": // Remplacez par l'e-mail approprié
                        return jouanh2202;
                    // Ajoutez d'autres cas selon vos besoins
                    default:
                        Debug.LogError("Email not found in Donnees");
                        return 0; // Ou une valeur par défaut appropriée
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattleOnClick()
    {
        if(StartbuttonPvP.IsInteractable())
        {
            if(Started == false)
            {
                Started = true;
            }

            
        }
    }

    public void OnClickPvp()
    {
        if(buttonPvP.IsInteractable())
        {
            GameObject LeaderBoard = GameObject.Find("Upload");
            Leaderboard leaderBoard = LeaderBoard.GetComponent<Leaderboard>();

            GameObject AccoutnManager = GameObject.Find("AccountManager");
            AccountManager AccountManager = AccoutnManager.GetComponent<AccountManager>();
            string url = "https://raw.githubusercontent.com/Serachan64/JeuVideal_api/main/JeuVideal.json";

            UnityWebRequest www = UnityWebRequest.Get(url);
            www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Lecture du contenu du fichier JSON
                string jsonText = www.downloadHandler.text;
                Donnees donnees = JsonUtility.FromJson<Donnees>(jsonText);

                AdresseEmail = donnees[AccountManager.email].ToString();
            }

            if(AccountManager.email == "jouanh5@hotmail.com")
            {
                AdresseEmail = "1";
            }
            if(AccountManager.email == "julojannot@gmail.com")
            {
                AdresseEmail = "2";
            }

            sauvegardeFonction.LoadDataFromJson(0);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(1);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(2);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(3);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(4);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(5);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(6);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(7);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(8);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(9);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(10);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(11);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }
            sauvegardeFonction.LoadDataFromJson(12);
            if(sauvegardeFonction.unlock ==true)
            {
                WinningRate ++;
            }





            
            if(Clicked == true && Started == true)
            {

                scorePvP += AdresseEmail;
                Debug.Log("AdressEmail :" + AdresseEmail);
                scorePvP += pvpSetup.spoted;
                Debug.Log("Spoted :" + pvpSetup.spoted);

                if (int.TryParse(pvpSetup.rank, out int NotStringValue))
                {
                    Output = NotStringValue;
                }

                if (Output< 0)
                {
                    pvpSetupValue = 0;
                }
                if (Output > 20)
                {
                    pvpSetupValue =20;
                }
                else
                {
                    pvpSetupValue = Output;

                }

                string NewNumber = (pvpSetupValue + pvpSetup.Gain).ToString("D2");
                scorePvP += NewNumber;
                Debug.Log("NewNumber :" + NewNumber);
                Debug.Log("WinnningRate :" + WinningRate.ToString() + "Output : ");

                WinningRate = WinningRate*(Output+1);
                float flottant = (float)WinningRate;
                string formattedWinningRate = WinningRate.ToString("D3");      
                scorePvP += formattedWinningRate;
                Debug.Log("formattedWinningRate :" + formattedWinningRate);

                if(pvpSetup.IsFighting==true)
                {
                   AfficherVainqueur(flottant,pvpSetup.EnemyPowerFloat);
                    if(Perdu == true)
                    {
                        scorePvP +="6";
                    }
                    else
                    {
                        scorePvP +="5";
                    }
                }
                else
                {
                    
                    scorePvP += pvpSetup.bloodlust;
                    Debug.Log("Bloodlust :" + pvpSetup.bloodlust);

                }

                if (int.TryParse(scorePvP, out int number))
                {
                    // Convert the long to int before passing it to SubmitScoreRoutine
                    leaderBoard.SubmitScoreRoutine(number);
                    Debug.Log(scorePvP);
                    Debug.Log(number);
                    Clicked = false;
                }
                else
                {
                    // Parsing failed, log an error message and print the value of scorePvP
                    Debug.LogError("Failed to parse scorePvP to a long integer");
                    
                }
                Clicked = false;
            }
            else
            {
                scorePvP += "1232345680";
            }
        }
    }

    string ExtractNumbers(string input)
    {
        // Utilisation d'une expression régulière pour extraire les chiffres de la chaîne
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(input, pattern);

        // Concaténation des chiffres extraits en une seule chaîne
        string result = "";
        foreach (Match match in matches)
        {
            result += match.Value;
        }

        return result;
    }

    string ReadFile(string fileName)
    {
        // Chemin du fichier
        string filePath = Application.persistentDataPath + "/" + fileName;

        // Vérification de l'existence du fichier
        if (System.IO.File.Exists(filePath))
        {
            // Lecture du contenu du fichier
            string fileContent = System.IO.File.ReadAllText(filePath);
            return fileContent;
        }
        else
        {
            Debug.LogError("Le fichier " + fileName + " n'existe pas.");
            return null;
        }
    }

    void AfficherVainqueur(float nombre1, float nombre2)
    {
        if(nombre1>=nombre2*1.5f)
        {
            Perdu = false;
        }
        if(nombre2>=nombre1*1.5f)
        {
            Perdu = true;
        }
        if(nombre1<nombre2*1.5f && nombre1>nombre2)
        {
            float nombreAleatoire = UnityEngine.Random.Range( 0, 51f);
            if(nombreAleatoire>=(1-(nombre1/nombre2))*100)
            {
                Perdu = true;
            }

        }
        if(nombre2<nombre1*1.5f && nombre2>nombre1)
        {
            float nombreAleatoire = UnityEngine.Random.Range( 0, 51f);
            if(nombreAleatoire>=(1-(nombre2/nombre1))*100)
            {
                Perdu = false;
            }
        }


    }

}
