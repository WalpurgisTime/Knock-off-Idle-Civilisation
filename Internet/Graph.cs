using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Graph : MonoBehaviour
{
    public Sprite circleSprite;
    private RectTransform graphContainer;
    private List<int> valueList = new List<int> {5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33};
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;
    public Toggle toggle6;

    public bool IsActivated;

    public Text Gain;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;
    public Slider slider6;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;


    private float sliderValue1;
    private float sliderValue2;
    private float sliderValue3;
    private float sliderValue4;
    private float sliderValue5;
    private float sliderValue6;

    public Button bouton1;
    public Button bouton2;
    public Button bouton3;
    public Button bouton4;
    public Button bouton5;
    public Button bouton6;

    private string previousButton;

    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        ShowGraph(valueList);
        StartCoroutine(UpdateGraphWithDelay());
    }



    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private IEnumerator UpdateGraphWithDelay()
    {
        while (true)
        {
            ClearGraph();
            valueList.RemoveAt(0);

            if(valueList[13]>80)
            {
                int newRandomRange = Random.Range(0, 15);
                if(newRandomRange <12)
                {
                    int newValue= Random.Range(80, 101);
                    valueList.Add(newValue);
                }
                if(newRandomRange >=12)
                {
                    int newValue= Random.Range(0, 51);
                    valueList.Add(newValue);
                }
            }
            if(valueList[13]>40 && valueList[13]<=60)
            {
                int newRandomRange = Random.Range(0, 5);
                if(newRandomRange <3)
                {
                    int newValue= Random.Range(40, 101);
                    valueList.Add(newValue);
                }
                if(newRandomRange >=3)
                {
                    int newValue= Random.Range(0, 41);
                    valueList.Add(newValue);
                }
            }
            if(valueList[13]>60 && valueList[13]<81)
            {
                int newRandomRange = Random.Range(0, 9);
                if(newRandomRange <5)
                {
                    int newValue= Random.Range(0, 20);
                    valueList.Add(newValue);
                }
                if(newRandomRange >=5)
                {
                    int newValue= Random.Range(20, 71);
                    valueList.Add(newValue);
                }
            }
            if(valueList[13]>=0 && valueList[13]<41)
            {
                int newRandomRange = Random.Range(0, 12);
                if(newRandomRange <7)
                {
                    int newValue= Random.Range(30, 89);
                    valueList.Add(newValue);
                }
                if(newRandomRange >=7)
                {
                    int newValue= Random.Range(0, 15);
                    valueList.Add(newValue);
                }
            }

            ShowGraph(valueList);

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 40f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1,.5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA,dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0,0,UtilsClass.GetAngleFromVectorFloat(dir));
    }

    private void ClearGraph()
    {
        foreach (Transform child in graphContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }



    public void OnToggle1Changed()
    {
        if (toggle1.isOn)
        {
            toggle2.interactable = false;
            toggle3.interactable = false;
            toggle4.interactable = false;
            toggle5.interactable = false;
            toggle6.interactable = false;
            IsActivated=true;
            previousButton = "1";
            
        }
        else
        {
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
            toggle6.interactable = true;
            IsActivated=false;
        }
    }

    public void OnToggle2Changed()
    {
        if (toggle2.isOn)
        {
            toggle1.interactable = false;
            toggle3.interactable = false;
            toggle4.interactable = false;
            toggle5.interactable = false;
            toggle6.interactable = false;
            IsActivated=true;
            previousButton = "2";
        }
        else
        {
            toggle1.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
            toggle6.interactable = true;
            IsActivated=false;
        }
    }

     public void Ontoggle3Changed()
    {
        if (toggle3.isOn)
        {
            toggle2.interactable = false;
            toggle1.interactable = false;
            toggle4.interactable = false;
            toggle5.interactable = false;
            toggle6.interactable = false;
            IsActivated=true;
            previousButton = "3";
        }
        else
        {
            toggle2.interactable = true;
            toggle1.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
            toggle6.interactable = true;
            IsActivated=false;
        }
    }

     public void Ontoggle4Changed()
    {
        if (toggle4.isOn)
        {
            toggle2.interactable = false;
            toggle3.interactable = false;
            toggle1.interactable = false;
            toggle5.interactable = false;
            toggle6.interactable = false;
            IsActivated=true;
            previousButton = "4";
        }
        else
        {
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle1.interactable = true;
            toggle5.interactable = true;
            toggle6.interactable = true;
            IsActivated=false;
        }
    }

     public void OnToggle5Changed()
    {
        if (toggle5.isOn)
        {
            toggle2.interactable = false;
            toggle3.interactable = false;
            toggle4.interactable = false;
            toggle1.interactable = false;
            toggle6.interactable = false;
            IsActivated=true;
            previousButton = "5";
        }
        else
        {
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle1.interactable = true;
            toggle6.interactable = true;
            IsActivated=false;
            
        }
    }

     public void OnToggle6Changed()
    {
        if (toggle6.isOn)
        {
            toggle2.interactable = false;
            toggle3.interactable = false;
            toggle4.interactable = false;
            toggle5.interactable = false;
            toggle1.interactable = false;
            IsActivated=true;
            previousButton = "6";
        }
        else
        {
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
            toggle1.interactable = true;
            IsActivated=false;
        }
    }

    public void OnSlider1ValueChanged()
    {
        sliderValue1 = slider1.value;
        text1.text = sliderValue1.ToString();
    }
    public void OnSlider2ValueChanged()
    {
        sliderValue2 = slider2.value;
        text2.text = sliderValue2.ToString();
    }
    public void OnSlider3ValueChanged()
    {
        sliderValue3 = slider3.value;
        text3.text = sliderValue3.ToString();
    }
    public void OnSlider4ValueChanged()
    {
        sliderValue4 = slider4.value;
        text4.text = sliderValue4.ToString();
    }
    public void OnSlider5ValueChanged()
    {
        sliderValue5 = slider5.value;
        text5.text = sliderValue5.ToString();
    }
    public void OnSlider6ValueChanged()
    {
        sliderValue6 = slider6.value;
        text6.text = sliderValue6.ToString();
    }


    public void OnClickChickenButton()
    {
        if (bouton1.IsInteractable())
        {
            if(IsActivated == true && previousButton == "1")
            {
                Invoke("FutureValueChicken",3f);
            }
        }
    }

    public void OnClickbreadButton()
    {
        if (bouton2.IsInteractable())
        {
            if(IsActivated == true && previousButton == "2")
            {
                Invoke("FutureValuebread",3f);
            }
        }
    }
    public void OnClicksorceryButton()
    {
        if (bouton3.IsInteractable())
        {
            if(IsActivated == true && previousButton == "3")
            {
                Invoke("FutureValuesorcery",3f);
            }
        }
    }
    public void OnClickDamageButton()
    {
        if (bouton4.IsInteractable())
        {
            if(IsActivated == true && previousButton == "4")
            {
                Invoke("FutureValueDamage",3f);
            }
        }
    }
    public void OnClickIronButton()
    {
        if (bouton5.IsInteractable())
        {
            if(IsActivated == true && previousButton == "5")
            {
                Invoke("FutureValueIron",3f);
            }
        }
    }
    public void OnClickCopperButton()
    {
        if (bouton6.IsInteractable())
        {
            if(IsActivated == true && previousButton == "6")
            {
                Invoke("FutureValueCopper",3f);
            }
        }
    }


    private void FutureValueChicken()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        //Debug.Log(Mathf.Abs(sliderValue1-valueList[13]));
        if(Mathf.Abs(sliderValue1-valueList[13])<10.0f)
        {
            sauvegardeFonction3.chicken = sauvegardeFonction3.chicken*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue1-valueList[13])<20.0f && Mathf.Abs(sliderValue1-valueList[13])>=10.0f)
        {
            sauvegardeFonction3.chicken = sauvegardeFonction3.chicken*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue1-valueList[13])>30)
        {
            sauvegardeFonction3.chicken = sauvegardeFonction3.chicken*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
            
        }
        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }

    private void FutureValuebread()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(Mathf.Abs(sliderValue2-valueList[13])<10)
        {
            sauvegardeFonction3.bread = sauvegardeFonction3.bread*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue2-valueList[13])<20 && Mathf.Abs(sliderValue2-valueList[13])>=10)
        {
            sauvegardeFonction3.bread = sauvegardeFonction3.bread*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue2-valueList[13])>30)
        {
            sauvegardeFonction3.bread = sauvegardeFonction3.bread*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
        }

        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }

    private void FutureValuesorcery()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(Mathf.Abs(sliderValue3-valueList[13])<10)
        {
            sauvegardeFonction3.sorcery = sauvegardeFonction3.sorcery*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue3-valueList[13])<20 && Mathf.Abs(sliderValue3-valueList[13])>=10)
        {
            sauvegardeFonction3.sorcery = sauvegardeFonction3.sorcery*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue3-valueList[13])>30)
        {
            sauvegardeFonction3.sorcery = sauvegardeFonction3.sorcery*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
        }

        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }


    private void FutureValueDamage()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(Mathf.Abs(sliderValue4-valueList[13])<10)
        {
            sauvegardeFonction3.Damage = sauvegardeFonction3.Damage*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue4-valueList[13])<20 && Mathf.Abs(sliderValue4-valueList[13])>=10)
        {
            sauvegardeFonction3.Damage = sauvegardeFonction3.Damage*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue4-valueList[13])>30)
        {
            sauvegardeFonction3.Damage = sauvegardeFonction3.Damage*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
        }

        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }

    private void FutureValueIron()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(Mathf.Abs(sliderValue5-valueList[13])<10)
        {
            sauvegardeFonction3.Iron = sauvegardeFonction3.Iron*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue5-valueList[13])<20 && Mathf.Abs(sliderValue5-valueList[13])>=10)
        {
            sauvegardeFonction3.Iron = sauvegardeFonction3.Iron*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue5-valueList[13])>30)
        {
            sauvegardeFonction3.Iron = sauvegardeFonction3.Iron*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
        }

        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }


    private void FutureValueCopper()
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        if(Mathf.Abs(sliderValue6-valueList[13])<10)
        {
            sauvegardeFonction3.Copper = sauvegardeFonction3.Copper*4.0f;
            Gain.text = " X4 Big mother trucker";
        }
        if(Mathf.Abs(sliderValue6-valueList[13])<20 && Mathf.Abs(sliderValue6-valueList[13])>=10)
        {
            sauvegardeFonction3.Copper = sauvegardeFonction3.Copper*1.5f;
            Gain.text = " X 1.5";
        }
        if(Mathf.Abs(sliderValue6-valueList[13])>30)
        {
            sauvegardeFonction3.Copper = sauvegardeFonction3.Copper*0.75f;
            Gain.text = " X 0.75 + L + RATIO + UR BALD";
        }

        Invoke("NormalWay",1f);
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void NormalWay()
    {
        Gain.text = "";
    }

}

