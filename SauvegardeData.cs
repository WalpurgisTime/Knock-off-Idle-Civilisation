using System.Collections.Generic;
using UnityEngine;

public class SauvegardeData : MonoBehaviour
{
    public Treasure treasure = new Treasure();

    void Start()
    {
        // Ajouter deux éléments vides à la liste lors de la création de l'objet Treasure
        treasure.items.Add(new Items());
        treasure.items.Add(new Items());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(treasure);
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);

        Debug.Log("Taille de la liste après sauvegarde : " + treasure.items.Count);
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        if (System.IO.File.Exists(filePath))
        {
            string jsonText = System.IO.File.ReadAllText(filePath);
            treasure = JsonUtility.FromJson<Treasure>(jsonText);
        }
        else
        {
            Debug.Log("Fichier JSON non trouvé");
        }
    }
}

[System.Serializable]
public class Treasure
{
    public float goldCoins;
    public float chicken;
    public List<Items> items = new List<Items>();
}

[System.Serializable]
public class Items
{
    public int length;
    public int width;
    public int height;
    public Vector3 retrievedvector3;

    public float sliderheight;
    public int aRendrehMoney;
    public int aRendreh;

    public float sliderlength;
    public int aRendrelMoney;
    public int aRendrel;

    public float sliderwidth;
    public int aRendrewMoney;
    public int aRendrew;
}
