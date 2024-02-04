using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using System;
using System.Collections;

public class Internet : MonoBehaviour
{
    public string apiUrl = "https://blockchain.info/ticker";
    public Text bitcoinPriceText;
    public float updateInterval = 1.0f;
    private float bitcoinPrice = 0.0f;

    void Start()
    {
        StartCoroutine(UpdateBitcoinPrice());
    }

    void Update()
    {
        if (Time.time >= updateInterval)
        {
            StartCoroutine(UpdateBitcoinPrice());
        }
    }

    IEnumerator UpdateBitcoinPrice()
    {
        UnityWebRequest www = UnityWebRequest.Get(apiUrl);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string data = www.downloadHandler.text;

            JSONNode json = JSON.Parse(data);
            bitcoinPrice = json["USD"]["last"].AsFloat;

            string formattedBitcoinPrice = String.Format("{0:F2}", bitcoinPrice);
            bitcoinPriceText.text = "Bitcoin Price: $" + formattedBitcoinPrice;
        }
        else
        {
            Debug.LogError("Error fetching data: " + www.error);
        }
    }

    public float GetBitcoinPrice()
    {
        return bitcoinPrice;
    }
}
