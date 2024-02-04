using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;



[System.Serializable]
public class StringImagePair
{
    public string stringValue;
    public Sprite imageValue;
}
public class EventGame : MonoBehaviour
{

    public StringImagePair[] stringImageArray;


    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public Button button14;
    public Button button15;

    public Text eventStarted;
    public sauvegardeFonction sauvegardeFonction3;



    [System.Serializable]
    public class Donnees
    {
        public bool isActive;
        public string Date;
    }

    void Start()
    {
        string url = "https://raw.githubusercontent.com/Serachan64/JeuVideal_api/main/JeuVideal.json";
        
    }

    void Update()
    {
        
        string url = "https://raw.githubusercontent.com/Serachan64/JeuVideal_api/main/JeuVideal.json";

        System.DateTime dateActuelle = System.DateTime.Now;

            // Formatage de la date pour inclure l'heure et les secondes
        string dateString2 = dateActuelle.ToString("yyyy-MM-dd HH:mm:ss");

            // Affichage de la date dans la console Unity
        //Debug.Log("Date et heure actuelles : " + dateString2);

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        while (!www.isDone)
        {
            // Attendre la fin de la requête
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            // Lecture du contenu du fichier JSON
            string jsonText = www.downloadHandler.text;
            Donnees donnees = JsonUtility.FromJson<Donnees>(jsonText);

            string dateString1 = donnees.Date;
            // Utilisation du contenu du fichier JSON (par exemple, l'afficher dans la console)
            //Debug.Log("Contenu du fichier JSON : " + donnees.isActive);
            DateTime date1 = DateTime.ParseExact(dateString1, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(dateString2, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan difference = date1 - date2;

            // Afficher la différence en jours, heures, minutes, et secondes
            if (donnees.isActive == true)
            {
                button1.interactable = true;
                button2.interactable = true;
                button3.interactable = true;
                button4.interactable = true;
                button5.interactable = true;


                eventStarted.text = "Event finsished in  : " + difference.Days.ToString() + " jours, " +
                    difference.Hours.ToString() + " heures, " +
                    difference.Minutes.ToString() + " minutes, " +
                    difference.Seconds.ToString() + " secondes.";
            }
            else
            {
                button1.interactable = false;
                button2.interactable = false;
                button3.interactable = false;
                button4.interactable = false;
                button5.interactable = false;
            }
            
        }

        www.Dispose();


        
    }
    

    public void OnClickButton1()
    {
        if(button1.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button1.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton2()
    {
        if(button2.IsInteractable())
        {
            // Utilisation de l'API System.DateTime pour obtenir la date actuelle
            

            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button2.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton3()
    {
        if(button3.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button3.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton4()
    {
        if(button4.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button4.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton5()
    {
        if(button5.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button5.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton6()
    {
        if(button6.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button6.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton7()
    {
        if(button7.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button7.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton8()
    {
        if(button8.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button8.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton9()
    {
        if(button9.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button9.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }

    public void OnClickButton10()
    {
        if(button10.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button10.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton11()
    {
        if(button11.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button11.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton12()
    {
        if(button12.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button12.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton13()
    {
        if(button13.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button13.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton14()
    {
        if(button14.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button14.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }
    public void OnClickButton15()
    {
        if(button15.IsInteractable())
        {
            int randomValue = UnityEngine.Random.Range(0,2);
            int Index = 0;
            if(randomValue==0)
            {
                Index = stringImageArray.Length-1;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, stringImageArray.Length);
                Index = randomIndex;
                AddValue(Index);
            }
            
            Image buttonImage = button15.GetComponent<Image>();
            buttonImage.sprite =  stringImageArray[Index].imageValue;
        }

    }

    private void AddValue(int value)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(stringImageArray[value].stringValue == "Copper")
        {
            sauvegardeFonction3.Copper += sauvegardeFonction3.Copper*0.5f;
        }
        if(stringImageArray[value].stringValue == "Iron")
        {
            sauvegardeFonction3.Iron += sauvegardeFonction3.Iron*0.5f;
        }
        if(stringImageArray[value].stringValue == "Mana")
        {
            sauvegardeFonction3.sorcery += sauvegardeFonction3.sorcery*0.5f;
        }
        if(stringImageArray[value].stringValue == "Chicken")
        {
            sauvegardeFonction3.chicken += sauvegardeFonction3.chicken*0.5f;
        }
        if(stringImageArray[value].stringValue == "Bread")
        {
            sauvegardeFonction3.bread += sauvegardeFonction3.bread*0.5f;
        }
        sauvegardeFonction3.SaveDataToJson(0);
    }
    
}
