using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyItems
{
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

    public Vector3 retrievedvector3;
}

[System.Serializable]
public class MyTreasure
{
    public List<MyItems> myItems = new List<MyItems>();
    public float goldCoins;
    public float chicken;
    public float Copper;
    public float Iron;
    public float sorcery;
    public float bread;
    public float Damage;
}

public class sauvegardeFonction : MonoBehaviour
{
    [HideInInspector]
    public float goldCoins;
    [HideInInspector]
    public int length;
    [HideInInspector]
    public int width;
    [HideInInspector]
    public int height;
    [HideInInspector]
    public float sliderlength;
    [HideInInspector]
    public float sliderwidth;
    [HideInInspector]
    public float sliderheight;
    [HideInInspector]
    public int aRendrehMoney;
    [HideInInspector]
    public int aRendrelMoney;
    [HideInInspector]
    public int aRendrewMoney;
    [HideInInspector]
    public int aRendrel;
    [HideInInspector]
    public int aRendrew;
    [HideInInspector]
    public int aRendreh;
    [HideInInspector]
    public float chicken;
    [HideInInspector]
    public Vector3 retrievedVector3;
    [HideInInspector]
    public bool unlock;
    [HideInInspector]
    public float bread;
    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public float Copper;
    [HideInInspector]
    public float Iron;
    [HideInInspector]
    public float sorcery;

    public MyTreasure myTreasure;
    public string Emailjson;
    private AccountManager AccountManager;



    void Start()
    {
        
    }

    public void LoadDataFromJson(int indexValue)
    {
        GameObject AccoutnManager = GameObject.Find("AccountManager");
        AccountManager AccountManager = AccoutnManager.GetComponent<AccountManager>(); 
        Emailjson = AccountManager.json;
        string filePath = Application.persistentDataPath + Emailjson;

        if (System.IO.File.Exists(filePath))
        {
            string jsonText = System.IO.File.ReadAllText(filePath);
            myTreasure = JsonUtility.FromJson<MyTreasure>(jsonText);

            if (myTreasure.myItems.Count > indexValue)
            {
                MyItems loadedItems = myTreasure.myItems[indexValue];

                length = loadedItems.length;
                width = loadedItems.width;
                height = loadedItems.height;
                retrievedVector3 = loadedItems.retrievedvector3;

                sliderheight = loadedItems.sliderheight;
                sliderlength = loadedItems.sliderlength;
                sliderwidth = loadedItems.sliderwidth;

                aRendrehMoney = loadedItems.aRendrehMoney;
                aRendrelMoney = loadedItems.aRendrelMoney;
                aRendrewMoney = loadedItems.aRendrewMoney;

                aRendreh = loadedItems.aRendreh;
                aRendrew = loadedItems.aRendrew;
                aRendrel = loadedItems.aRendrel;

                unlock = loadedItems.unlock;

                goldCoins = myTreasure.goldCoins;
                chicken = myTreasure.chicken;
                bread = myTreasure.bread;
                sorcery = myTreasure.sorcery;
                Iron = myTreasure.Iron;
                Copper = myTreasure.Copper;
                Damage = myTreasure.Damage;


                
            }
        }
        else
        {
            Debug.LogError("Fichier JSON non trouvé");
        }
    }

    public void SaveDataToJson(int indexValue)
    {
        GameObject AccoutnManager = GameObject.Find("AccountManager");
        AccountManager AccountManager = AccoutnManager.GetComponent<AccountManager>(); 

        Emailjson = AccountManager.json;
        string filePath = Application.persistentDataPath + Emailjson;

        // S'assurer que la liste a une taille suffisante
        while (myTreasure.myItems.Count <= indexValue)
        {
            myTreasure.myItems.Add(new MyItems());
        }

        MyItems itemsToSave = myTreasure.myItems[indexValue];

        // Assigner les valeurs des variables de classe à MyItems
        itemsToSave.length = length;
        itemsToSave.width = width;
        itemsToSave.height = height;
        itemsToSave.retrievedvector3 = retrievedVector3;
        itemsToSave.sliderheight = sliderheight;
        itemsToSave.sliderlength = sliderlength;
        itemsToSave.sliderwidth = sliderwidth;
        itemsToSave.aRendrehMoney = aRendrehMoney;
        itemsToSave.aRendrelMoney = aRendrelMoney;
        itemsToSave.aRendrewMoney = aRendrewMoney;
        itemsToSave.aRendreh = aRendreh;
        itemsToSave.aRendrew = aRendrew;
        itemsToSave.aRendrel = aRendrel;
        itemsToSave.unlock = unlock;

        // Assigner les valeurs des variables de classe à MyTreasure
        myTreasure.goldCoins = goldCoins;
        myTreasure.chicken = chicken;
        myTreasure.Iron = Iron;
        myTreasure.bread = bread;
        myTreasure.Copper = Copper;
        myTreasure.sorcery = sorcery;
        myTreasure.Damage = Damage;
        

        // Convertir l'objet MyTreasure en JSON et sauvegarder dans le fichier
        string inventoryData = JsonUtility.ToJson(myTreasure);
        System.IO.File.WriteAllText(filePath, inventoryData);
    }


    private void OnApplicationQuit()
    {
        Debug.Log("Done");
        // Load data from JSON to ensure you have the latest data in myTreasure
        LoadDataFromJson(0); // Adjust the index as needed

        // Set up final values for index 0
        if (myTreasure.myItems.Count > 0)
        {

            length = 3; 
            width = 2;   
            height = 3; 
            sliderlength = 2f; 
            sliderwidth = 2f;   
            sliderheight = 3f; 
            aRendrehMoney = 10;  
            aRendrelMoney = 10;  
            aRendrewMoney = 10; 
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;
            unlock = true;
            retrievedVector3 = new Vector3(-1f, 0f, 2f);
        }
        // Save the updated values to JSON
        SaveDataToJson(0); // Adjust the index as needed
        LoadDataFromJson(1);
        // Set up final values for index 1
        if (myTreasure.myItems.Count > 1)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(-10f, 0f, 2f);  
        }
        SaveDataToJson(1);
        LoadDataFromJson(2);
        
        if (myTreasure.myItems.Count > 2)
        {
            length = 8;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(5f, -1f, -8f);  
        }
        SaveDataToJson(2);
        LoadDataFromJson(3);
        
        if (myTreasure.myItems.Count > 3)
        {
            length = 8;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(-10f, 0f, 9f);  
        }
        SaveDataToJson(3);
        LoadDataFromJson(4);
        if (myTreasure.myItems.Count > 4)
        {
            length = 8;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(-17f, 0f, 8f);  
        }
        SaveDataToJson(4);
        LoadDataFromJson(5);
        if (myTreasure.myItems.Count > 5)
        {
            length = 2;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(30f, 0f, -10f);  
        }
        SaveDataToJson(5);
        LoadDataFromJson(6);
        if (myTreasure.myItems.Count > 6)
        {
            length = 3;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(25f, 0f, -15f);  
        }
        SaveDataToJson(6);
        LoadDataFromJson(7);
        if (myTreasure.myItems.Count > 7)
        {
            length = 3;  
            width = 2;   
            height = 2;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(10f, 0f, 5f);  
        }
        SaveDataToJson(7); 
        LoadDataFromJson(8);
        if (myTreasure.myItems.Count > 8)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(-10f, 0f, -20f);  
        }
        SaveDataToJson(8);
        LoadDataFromJson(9);
        if (myTreasure.myItems.Count > 9)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(-10f, 0f, -25f);  
        }
        SaveDataToJson(9);
        LoadDataFromJson(10);
        if (myTreasure.myItems.Count > 10)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(10f, 0f, -20f);  
        }
        SaveDataToJson(10);
        LoadDataFromJson(11);
        if (myTreasure.myItems.Count > 11)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(5f, 0f, -15f);  
        }
        SaveDataToJson(11);
        LoadDataFromJson(12);
        if (myTreasure.myItems.Count > 12)
        {
            length = 3;  
            width = 2;   
            height = 5;  
            sliderlength = 2f;  
            sliderwidth = 2f;   
            sliderheight = 2f;  
            aRendrehMoney = 10;  
            aRendrelMoney = 10; 
            aRendrewMoney = 10;  
            aRendreh = 0;  
            aRendrel = 0;  
            aRendrew = 0;  
            unlock = false;
            retrievedVector3 = new Vector3(0f, 0f, -20f);  
        }
        


        goldCoins = 0.0f;  
        chicken = 0.0f;
        bread = 0.0f;
        Copper = 0.0f;
        Damage = 0.0f;
        Iron = 0.0f;
        sorcery = 0.0f;

        SaveDataToJson(10);


        // Save the updated values to JSON
         // Adjust the index as needed
    }

    public string[] GetMyItemsArray()
    {
        List<string> itemsArray = new List<string>();

        foreach (MyItems item in myTreasure.myItems)
        {
            string itemJson = JsonUtility.ToJson(item);
            itemsArray.Add(itemJson);
        }

        return itemsArray.ToArray();
    }

}
