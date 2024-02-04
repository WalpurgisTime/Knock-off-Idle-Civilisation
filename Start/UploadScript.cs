using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using System;
using UnityEngine.Networking;


public class UploadManager : MonoBehaviour
{
    public InputField userInputField;
    public Text displayText; // Référence au composant de texte
    private sauvegardeFonction sauvegardeFonction;

    [Serializable]
    public class YourContainer
    {
        public List<YourClass> items;
        public float goldCoins;
        public float chicken;
        public float Copper;
        public float Iron;
        public float sorcery;
        public float bread;
        public float Damage;

    
    }

    [Serializable]
    public class YourClass
    {
        // Déclarez les propriétés qui correspondent à votre structure JSON
        public int length;
        public int width;
        public int height;

        public bool unlock;

        public float sliderlength;
        public float sliderwidth;
        public float sliderheight;

        public int aRendrehMoney;
        public int aRendrelMoney;
        public int aRendrewMoney;

        public int aRendrel;
        public int aRendrew;
        public int aRendreh;

        public Vector3 retrievedVector3;
        // Ajoutez d'autres propriétés selon votre structure JSON
    }

    public void OnClickSaveButton()
    {
        GetPlayerFileData();
        

        sauvegardeFonction = FindObjectOfType<sauvegardeFonction>();
        string initialContent = "chien";
        YourContainer container = JsonUtility.FromJson<YourContainer>("{\"items\":" + initialContent + "}");

        sauvegardeFonction.LoadDataFromJson(0); // Adjust the index as needed

        // Set up final values for index 0
        if (sauvegardeFonction.myTreasure.myItems.Count > 0)
        {

            sauvegardeFonction.length = container.items[0].length; 
            sauvegardeFonction.width = container.items[0].width;   
            sauvegardeFonction.height = container.items[0].height; 
            sauvegardeFonction.sliderlength = container.items[0].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[0].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[0].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[0].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[0].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[0].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[0].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[0].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[0].aRendrew;
            sauvegardeFonction.unlock = container.items[0].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[0].retrievedVector3;
        }
        // Save the updated values to JSON
        sauvegardeFonction.SaveDataToJson(0); // Adjust the index as needed
        sauvegardeFonction.LoadDataFromJson(1);
        // Set up final values for index 1
        if (sauvegardeFonction.myTreasure.myItems.Count > 1)
        {
            sauvegardeFonction.length = container.items[1].length; 
            sauvegardeFonction.width = container.items[1].width;   
            sauvegardeFonction.height = container.items[1].height; 
            sauvegardeFonction.sliderlength = container.items[1].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[1].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[1].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[1].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[1].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[1].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[1].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[1].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[1].aRendrew;
            sauvegardeFonction.unlock = container.items[1].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[1].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(1);
        sauvegardeFonction.LoadDataFromJson(2);
        
        if (sauvegardeFonction.myTreasure.myItems.Count > 2)
        {
            sauvegardeFonction.length = container.items[2].length; 
            sauvegardeFonction.width = container.items[2].width;   
            sauvegardeFonction.height = container.items[2].height; 
            sauvegardeFonction.sliderlength = container.items[2].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[2].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[2].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[2].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[2].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[2].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[2].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[2].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[2].aRendrew;
            sauvegardeFonction.unlock = container.items[2].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[2].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(2);
        sauvegardeFonction.LoadDataFromJson(3);
        
        if (sauvegardeFonction.myTreasure.myItems.Count > 3)
        {
            sauvegardeFonction.length = container.items[3].length; 
            sauvegardeFonction.width = container.items[3].width;   
            sauvegardeFonction.height = container.items[3].height; 
            sauvegardeFonction.sliderlength = container.items[3].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[3].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[3].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[3].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[3].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[3].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[3].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[3].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[3].aRendrew;
            sauvegardeFonction.unlock = container.items[3].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[3].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(3);
        sauvegardeFonction.LoadDataFromJson(4);
        if (sauvegardeFonction.myTreasure.myItems.Count > 4)
        {
            sauvegardeFonction.length = container.items[4].length; 
            sauvegardeFonction.width = container.items[4].width;   
            sauvegardeFonction.height = container.items[4].height; 
            sauvegardeFonction.sliderlength = container.items[4].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[4].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[4].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[4].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[4].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[4].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[4].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[4].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[4].aRendrew;
            sauvegardeFonction.unlock = container.items[4].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[4].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(4);
        sauvegardeFonction.LoadDataFromJson(5);
        if (sauvegardeFonction.myTreasure.myItems.Count > 5)
        {
            sauvegardeFonction.length = container.items[5].length; 
            sauvegardeFonction.width = container.items[5].width;   
            sauvegardeFonction.height = container.items[5].height; 
            sauvegardeFonction.sliderlength = container.items[5].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[5].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[5].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[5].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[5].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[5].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[5].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[5].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[5].aRendrew;
            sauvegardeFonction.unlock = container.items[5].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[5].retrievedVector3;
        }
        
        sauvegardeFonction.SaveDataToJson(5);
        sauvegardeFonction.LoadDataFromJson(6);
        if (sauvegardeFonction.myTreasure.myItems.Count > 6)
        {
            sauvegardeFonction.length = container.items[6].length; 
            sauvegardeFonction.width = container.items[6].width;   
            sauvegardeFonction.height = container.items[6].height; 
            sauvegardeFonction.sliderlength = container.items[6].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[6].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[6].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[6].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[6].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[6].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[6].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[6].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[6].aRendrew;
            sauvegardeFonction.unlock = container.items[6].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[6].retrievedVector3;
        }
        

        sauvegardeFonction.SaveDataToJson(6);
        sauvegardeFonction.LoadDataFromJson(7);
        if (sauvegardeFonction.myTreasure.myItems.Count > 7)
        {
            sauvegardeFonction.length = container.items[7].length; 
            sauvegardeFonction.width = container.items[7].width;   
            sauvegardeFonction.height = container.items[7].height; 
            sauvegardeFonction.sliderlength = container.items[7].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[7].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[7].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[7].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[7].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[7].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[7].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[7].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[7].aRendrew;
            sauvegardeFonction.unlock = container.items[7].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[7].retrievedVector3;
        }
        
        sauvegardeFonction.SaveDataToJson(7); 
        sauvegardeFonction.LoadDataFromJson(8);
        if (sauvegardeFonction.myTreasure.myItems.Count > 8)
        {
            sauvegardeFonction.length = container.items[8].length; 
            sauvegardeFonction.width = container.items[8].width;   
            sauvegardeFonction.height = container.items[8].height; 
            sauvegardeFonction.sliderlength = container.items[8].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[8].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[8].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[8].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[8].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[8].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[8].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[8].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[8].aRendrew;
            sauvegardeFonction.unlock = container.items[8].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[8].retrievedVector3;
        
        }
        sauvegardeFonction.SaveDataToJson(8);
        sauvegardeFonction.LoadDataFromJson(9);
        if (sauvegardeFonction.myTreasure.myItems.Count > 9)
        {
            sauvegardeFonction.length = container.items[9].length; 
            sauvegardeFonction.width = container.items[9].width;   
            sauvegardeFonction.height = container.items[9].height; 
            sauvegardeFonction.sliderlength = container.items[9].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[9].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[9].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[9].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[9].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[9].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[9].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[9].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[9].aRendrew;
            sauvegardeFonction.unlock = container.items[9].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[9].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(9);
        sauvegardeFonction.LoadDataFromJson(10);
        if (sauvegardeFonction.myTreasure.myItems.Count > 10)
        {
            sauvegardeFonction.length = container.items[10].length; 
            sauvegardeFonction.width = container.items[10].width;   
            sauvegardeFonction.height = container.items[10].height; 
            sauvegardeFonction.sliderlength = container.items[10].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[10].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[10].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[10].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[10].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[10].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[10].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[10].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[10].aRendrew;
            sauvegardeFonction.unlock = container.items[10].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[10].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(10);
        sauvegardeFonction.LoadDataFromJson(11);
        if (sauvegardeFonction.myTreasure.myItems.Count > 11)
        {
            sauvegardeFonction.length = container.items[11].length; 
            sauvegardeFonction.width = container.items[11].width;   
            sauvegardeFonction.height = container.items[11].height; 
            sauvegardeFonction.sliderlength = container.items[11].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[11].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[11].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[11].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[11].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[11].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[11].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[11].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[11].aRendrew;
            sauvegardeFonction.unlock = container.items[11].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[11].retrievedVector3;
        }
        sauvegardeFonction.SaveDataToJson(11);
        sauvegardeFonction.LoadDataFromJson(12);
        if (sauvegardeFonction.myTreasure.myItems.Count > 12)
        {
            sauvegardeFonction.length = container.items[12].length; 
            sauvegardeFonction.width = container.items[12].width;   
            sauvegardeFonction.height = container.items[12].height; 
            sauvegardeFonction.sliderlength = container.items[12].sliderheight; 
            sauvegardeFonction.sliderwidth = container.items[12].sliderwidth;   
            sauvegardeFonction.sliderheight = container.items[12].sliderheight; 
            sauvegardeFonction.aRendrehMoney = container.items[12].aRendrehMoney;  
            sauvegardeFonction.aRendrelMoney = container.items[12].aRendrelMoney;  
            sauvegardeFonction.aRendrewMoney = container.items[12].aRendrewMoney; 
            sauvegardeFonction.aRendreh = container.items[12].aRendreh;  
            sauvegardeFonction.aRendrel = container.items[12].aRendrel;  
            sauvegardeFonction.aRendrew = container.items[12].aRendrew;
            sauvegardeFonction.unlock = container.items[12].unlock;
            sauvegardeFonction.retrievedVector3 = container.items[12].retrievedVector3;
        }
        


        sauvegardeFonction.goldCoins =  container.goldCoins;  
        sauvegardeFonction.chicken = container.chicken;
        sauvegardeFonction.bread = container.bread;
        sauvegardeFonction.Copper = container.Copper;
        sauvegardeFonction.Damage = container.Damage;
        sauvegardeFonction.Iron = container.Iron;
        sauvegardeFonction.sorcery = container.sorcery;

        sauvegardeFonction.SaveDataToJson(10);

        int fileID = PlayerPrefs.GetInt("PlayerSaveDataFileID");
        if (fileID > 0)
        {
            // Appel à la fonction de suppression
            //DeleteFile(fileID);
        }
        // Récupération du texte de l'Input Field
        string userText = userInputField.text;
        int ratio = 1000;

        // Enregistrement du texte dans le fichier
        //WriteToFile("save.txt", userText);

        // Upload du fichier vers le serveur
        //UploadFile("save.txt", userText);

        // Lecture du contenu du fichier initial
        //string initialContent = ReadFile("save.txt");

        // Affichage du contenu dans le composant de texte
        //displayText.text = "Contenu du fichier initial : " + initialContent;
    }
    void Start()
    {
        // Assurez-vous que l'Input Field est assigné dans l'éditeur Unity
        if (userInputField == null)
        {
            Debug.LogError("Veuillez assigner l'Input Field dans l'éditeur Unity.");
            return;
        }

        // Assurez-vous que le composant de texte est assigné dans l'éditeur Unity
        if (displayText == null)
        {
            Debug.LogError("Veuillez assigner le composant de texte dans l'éditeur Unity.");
            return;
        }
    }

    public void DeleteFile(int fileID)
    {
        // Utilisation du SDK LootLocker pour supprimer le fichier côté serveur
        LootLockerSDKManager.DeletePlayerFile(fileID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Le fichier a été supprimé avec succès.");
            }
            else
            {
                Debug.LogError("Échec de la suppression du fichier : " + response.errorData.message);
            }
        });
    }


    
    public void UploadFile(string fileName, string userName)
    {
        // Chemin du fichier
        
        string filePath = Application.persistentDataPath + "/" + fileName;

        // Lecture du contenu du fichier
        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

        // Paramètres pour l'upload
        string filePurpose = userName;
        
        bool isPublic = false;

        // Utilisation du SDK LootLocker pour l'upload du fichier
        LootLockerSDKManager.UploadPlayerFile(fileBytes, filePurpose, fileName, isPublic, (response) =>
        {
            // Enregistrement de l'ID du fichier dans PlayerPrefs
            PlayerPrefs.SetInt("PlayerSaveDataFileID", response.id);
        });
    }

    void GetPlayerFileData()
    {
        int fileID = PlayerPrefs.GetInt("playerSaveFileID");
        LootLockerSDKManager.GetPlayerFile(fileID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Retrieved URL");
                StartCoroutine(Download(response.url, (fileContent) =>
                {
                    Debug.Log("File is downloaded");
                    // Do something with the content
                    Debug.Log(fileContent);
                }));
        
            }
        });
    }

    IEnumerator Download(string url, System.Action<string> fileContent)
    {
        UnityWebRequest www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        { 
            fileContent(www.downloadHandler.text);
        }
    }


    public void WriteToFile(string fileName, string content)
    {
        sauvegardeFonction = FindObjectOfType<sauvegardeFonction>();
        // Chemin du fichier
        string filePath = Application.persistentDataPath + "/" + fileName;
        content ="";
        foreach (var element in sauvegardeFonction.GetMyItemsArray())
        {
            
            content += element.ToString();
        }
        Debug.Log(content);
    

        // Écriture du contenu dans le fichier
        System.IO.File.WriteAllText(filePath, content);
    }
}
