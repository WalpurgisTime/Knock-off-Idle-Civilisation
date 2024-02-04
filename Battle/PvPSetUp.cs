using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using LootLocker.Requests;
using UnityEngine.Networking;
using System;




public class EvilCreated
{
    public string EvilName;
    public Vector3 Evilposition;


    public EvilCreated (string Name, Vector3 position)
    {
        EvilName = Name;
        Evilposition = position;
    }
}

public class PvPSetUp : MonoBehaviour
{
    public PvP pvp;
    public Button buttonPvP;
    public NodeButton nodeButton;
    private List<EvilCreated> EvilList = new List<EvilCreated>();

    private bool IsDesactivated;
    public string AdresseEmail;
    private AccountManager AccountManager;

    public string spoted;
    public string bloodlust;
    public int Gain;
    public string rank;
    public string EnemyPower;
    public string MyPower;

    public bool Inqueue;
    private bool OnlyOne;
    public Text DebugData;
    public float EnemyPowerFloat;

    public bool IsFighting;




    private Leaderboard leaderboard;

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
    
    // Start is called before the first frame update
    void Start()
    {
        IsDesactivated = true;
        Inqueue = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(buttonPvP.IsInteractable())
        {
            if(nodeButton.Desactivate ==true)
            {
                IsDesactivated = false;
                
            }
            else
            {
                Debug.Log("Partie is Activated");
                IsDesactivated = true;
            }

            if(pvp.Started ==true && nodeButton.Desactivate == IsDesactivated);
            {
                GameObject LeaderBoard = GameObject.Find("Upload");
                Leaderboard leaderboard = LeaderBoard.GetComponent<Leaderboard>();

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
                if(AccountManager.email == "jouanh5@hotmail.com")
                {
                    AdresseEmail = "1";
                }


                //Debug.Log(leaderboard.playerNamesList[0]);
                
                spoted = "0";
                bloodlust ="0";
                for (int j =0; j<leaderboard.playerNamesList.Count;j++)
                {
                    //Debug.Log(leaderboard.playerScoresList[j].ToString());
                    if(leaderboard.playerScoresList[j][0].ToString()!=AdresseEmail) 
                    {
                        //Debug.Log(leaderboard.playerScoresList[j][0].ToString()+"La valeur" +  AdresseEmail);
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString()=="2")
                        {

                            Debug.Log("Une personne voulant se battre détecté + C'est :" + leaderboard.playerScoresList[j][0].ToString());
                            if(leaderboard.playerScoresList[j][1].ToString()==AdresseEmail && Inqueue)
                            {
                                //Debug.Log("Elle Shouate se battre contre vous");
                                spoted = leaderboard.playerScoresList[j][0].ToString();
                                EnemyPower = leaderboard.playerScoresList[j][4].ToString()+leaderboard.playerScoresList[j][4].ToString()+leaderboard.playerScoresList[j][6].ToString();
                                bloodlust = "2";
                                OnlyOne = true;
                                DebugData.text = "Je vais me battre contre" + leaderboard.playerScoresList[j][0].ToString();

                                if (int.TryParse(leaderboard.playerScoresList[j][4].ToString() + leaderboard.playerScoresList[j][5].ToString() + leaderboard.playerScoresList[j][6].ToString() , out int PwerEnemy))
                                {
                                    EnemyPowerFloat = PwerEnemy;
                                }
                                IsFighting = true;
                                

                            }
                            if(OnlyOne == false)
                            {
                                spoted = leaderboard.playerScoresList[j][0].ToString();
                                bloodlust = "2";
                                DebugData.text = "Je veux me battre contre" + leaderboard.playerScoresList[j][0].ToString();
                                if (int.TryParse(leaderboard.playerScoresList[j][4].ToString() + leaderboard.playerScoresList[j][5].ToString() + leaderboard.playerScoresList[j][6].ToString() , out int PwerEnemy))
                                {
                                    EnemyPowerFloat = PwerEnemy;
                                }
                            }

                        }
                         
                    }
                    else
                    {
                        Debug.Log("J'en Suis la ");
                        rank = leaderboard.playerScoresList[j][2].ToString()+leaderboard.playerScoresList[j][3].ToString();
                        
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString() == "0")
                        {
                            Debug.Log("C'est bon ");
                            if(Inqueue)
                            {
                                bloodlust = "2";
                                spoted = "0";
                                DebugData.text = "Je ne suis pas en Queue";
                            }
                            else
                            {
                                bloodlust = "0";
                                spoted = "0";
                                DebugData.text = "Je ne suis pas en Queue";
                            }
                            


                        }
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString() == "5")
                        {
                            spoted = "0";
                            bloodlust = "0";
                            Inqueue = false;
                            DebugData.text = "Je me suis fait battre";
                        }
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString() == "6")
                        {
                            spoted = "0";
                            bloodlust = "0";
                            Inqueue = false;
                            DebugData.text = "J'ai gagné";
                        }
                        
                        
                    }
                }

                for (int j =0; j<leaderboard.playerNamesList.Count;j++)
                {
                    if(leaderboard.playerScoresList[j][0].ToString()!=AdresseEmail) 
                    {
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString()=="3" &&leaderboard.playerScoresList[j][1].ToString()==AdresseEmail)
                        {
                            Debug.Log("Un ennemi vous a battu C'est : "+ leaderboard.playerScoresList[j][0].ToString());
                            spoted = leaderboard.playerScoresList[j][1].ToString();
                            bloodlust = "6";
                            Inqueue = false;
                            Gain = -1;
                            //leaderboard.SubmitScoreRoutine();
                        }
                        if(leaderboard.playerScoresList[j][leaderboard.playerScoresList[j].Length-1].ToString()=="4" &&leaderboard.playerScoresList[j][1].ToString()==AdresseEmail)
                        {
                            Debug.Log("Vous avez gagné un ennemi C'est : "+ leaderboard.playerScoresList[j][0].ToString());
                            spoted = leaderboard.playerScoresList[j][1].ToString();
                            bloodlust = "5";
                            Inqueue = false;
                            Gain = 1;
                            //leaderboard.SubmitScoreRoutine();
                        }
                    }
                }


            }
        }
        
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



}

    

    

