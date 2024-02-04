using UnityEngine;
using UnityEngine.UI;

public class ManyButtons : MonoBehaviour
{
    public Button boutonQuit;
    public Button boutonLength;
    public GameObject ui;

    public BuildManager buildManager;
    public ArrayContainer arrayContainer;

    public string[] targetTag;

    [HideInInspector]
    public float xValue = 0.0f;
    [HideInInspector]
    public float zValue = 0.0f;

    public Slider sliderHeight;
    public Slider sliderWidth;
    public Slider sliderLength;

    public Text textHeightMoney;
    public Text textWidthMoney;
    public Text textLengthMoney;

    private int aRendreL =0;
    private int aRendreW =0;
    private int aRendreH =0;

    public int aRendreLMoney = 10;
    public int aRendreWMoney = 10;
    public int aRendreHMoney = 10;

    public Text textHeight;
    public Text textWidth;
    public Text textLength;

    public string stringClassName;
    public int ValueClass;

    public LayerMask myLayerMask;
    private float MoneySecret;

    public Text RessourceValueW;
    public Text RessourceValueL;
    public Text RessourceValueH;

   
    public House house;
    public Inventory inventory;

    public sauvegardeFonction sauvegardeFonction3;

    void Start()
    {
        ui.SetActive(false);
        
        // Initialisation du vecteur

        inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            Inventory.PuissanceChiffrePair[] puissanceChiffrePairs = inventory.puissanceChiffrePairs;
        }
        MoneySecret = inventory.MoneyBoulangerieir;
        sauvegardeFonction3.LoadDataFromJson(ValueClass);
                   
        string formattedARendreLMoney = (sauvegardeFonction3.aRendrelMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendrel].chiffre)).ToString("N0");
        textLengthMoney.text = $"Achat: {formattedARendreLMoney} de {inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendrel].puissance}";
        string formattedARendreWMoney = (sauvegardeFonction3.aRendrewMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendrew].chiffre)).ToString("N0");
        textWidthMoney.text = $"Achat: {formattedARendreWMoney} de {inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendrew].puissance}";
        string formattedARendreHMoney = (sauvegardeFonction3.aRendrehMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendreh].chiffre)).ToString("N0");
        textHeightMoney.text = $"Achat: {formattedARendreHMoney} de {inventory.puissanceChiffrePairs[sauvegardeFonction3.aRendreh].puissance}";

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, -myLayerMask))
            {
                if (CheckTargetTag(hit.collider.gameObject,"boulangerie"))
                {
                    ui.SetActive(true);
                    stringClassName="boulangerie";
                    ValueClass=0;

                }
                if (CheckTargetTag(hit.collider.gameObject,"armurerie"))
                {
                    ui.SetActive(true);

                    stringClassName="armurerie";
                    ValueClass=1;

                }
            }
        }
        
        
    }

    private bool CheckTargetTag(GameObject obj,string desiredTag)
    {
       return obj.CompareTag(desiredTag);
    }

    public void OnHeightSliderChanged()
    {
        arrayContainer.DestroyHouse(ValueClass);
        sauvegardeFonction3.LoadDataFromJson(ValueClass);
        sliderHeight.maxValue = sauvegardeFonction3.sliderheight;
        sauvegardeFonction3.height = Mathf.FloorToInt(sliderHeight.value);
        

        RessourceValueH.text = "Bread : X"+sliderHeight.value.ToString();
        textHeight.text = $"Height: {sauvegardeFonction3.height - 1f:F2}";

        

        sauvegardeFonction3.retrievedVector3.y = -1f;
        arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,stringClassName);
        sauvegardeFonction3.SaveDataToJson(ValueClass);
    }

    public void OnWidthSliderChanged()
    {
        arrayContainer.DestroyHouse(ValueClass);
        sauvegardeFonction3.LoadDataFromJson(ValueClass);
        sliderWidth.maxValue = sauvegardeFonction3.sliderwidth;
        sauvegardeFonction3.width = Mathf.FloorToInt(sliderWidth.value);
        
        RessourceValueW.text = "Gold : X"+sliderWidth.value.ToString();
        textWidth.text = $"Width: {sauvegardeFonction3.width:F2}";
        
        arrayContainer.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,stringClassName);
        sauvegardeFonction3.SaveDataToJson(ValueClass);
    }

    public void OnLengthSliderChanged()
    {
        arrayContainer.DestroyHouse(ValueClass);
        sauvegardeFonction3.LoadDataFromJson(ValueClass);
        sliderLength.maxValue = sauvegardeFonction3.sliderlength;
        sauvegardeFonction3.length = Mathf.FloorToInt(sliderLength.value);
        
        RessourceValueL.text = "Sorcery : X"+sliderLength.value.ToString();
        textLength.text = $"Length: {sauvegardeFonction3.length:F2}";

        
        sauvegardeFonction3.retrievedVector3.y = -1f;
        arrayContainer.BuildHouse(sauvegardeFonction3.length,sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,stringClassName);
        sauvegardeFonction3.SaveDataToJson(ValueClass);
        
    }

   
    public void OnClickLength()
    {
        if (boutonLength != null && boutonLength.IsInteractable() && inventory != null && inventory.puissanceChiffrePairs != null)
        {
            sauvegardeFonction3.LoadDataFromJson(ValueClass);
            aRendreLMoney=sauvegardeFonction3.aRendrelMoney;

            if(inventory.coinsCountTrue >= aRendreLMoney)
            {

                sliderLength.maxValue = sauvegardeFonction3.sliderlength;
                sliderLength.maxValue +=1f;
                sauvegardeFonction3.sliderlength= sliderLength.maxValue;
                inventory.coinsCountTrue-=aRendreLMoney;
                aRendreLMoney=aRendreLMoney*15;
                inventory.sorcery += sliderLength.value;
                
                

                if (GetPowerOf10(aRendreLMoney) > inventory.puissanceChiffrePairs[aRendreL + 1].chiffre)
                {
                    aRendreL++;
                    
                }

                string formattedARendreLMoney = (aRendreLMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[aRendreL].chiffre)).ToString("N0");
                textLengthMoney.text = $"Achat: {formattedARendreLMoney} de {inventory.puissanceChiffrePairs[aRendreL].puissance}";

                sauvegardeFonction3.aRendrelMoney=aRendreLMoney;
                sauvegardeFonction3.aRendrel=aRendreL;

                sauvegardeFonction3.SaveDataToJson(ValueClass);
            }
        }
    }

    public void OnClickWidth()
    {
        if (boutonLength != null && boutonLength.IsInteractable() && inventory != null && inventory.puissanceChiffrePairs != null)
        {
            
            sauvegardeFonction3.LoadDataFromJson(ValueClass);
            aRendreWMoney = sauvegardeFonction3.aRendrewMoney;

            if(inventory.coinsCountTrue >= aRendreWMoney)
            {
    


                

                sliderWidth.maxValue = sauvegardeFonction3.sliderwidth;
                sliderWidth.maxValue +=1f;
                sauvegardeFonction3.sliderwidth= sliderWidth.maxValue;
                
                inventory.coinsCountTrue-=aRendreWMoney;
                aRendreWMoney=aRendreWMoney*15;
                inventory.MoneyBoulangerieir += sliderWidth.value*MoneySecret;
                

                if (GetPowerOf10(aRendreWMoney) > inventory.puissanceChiffrePairs[aRendreW + 1].chiffre)
                {
                    aRendreW++;
                    
                }

                string formattedARendreWMoney = (aRendreWMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[aRendreW].chiffre)).ToString("N0");
                textWidthMoney.text = $"Achat: {formattedARendreWMoney} de {inventory.puissanceChiffrePairs[aRendreW].puissance}";

                sauvegardeFonction3.aRendrewMoney=aRendreWMoney;
                sauvegardeFonction3.aRendrew=aRendreW;

                sauvegardeFonction3.SaveDataToJson(ValueClass);
            }
        }
    }

    public void OnClickHeight()
    {
        if (boutonLength != null && boutonLength.IsInteractable() && inventory != null && inventory.puissanceChiffrePairs != null)
        {
            sauvegardeFonction3.LoadDataFromJson(ValueClass);
            aRendreHMoney=sauvegardeFonction3.aRendrehMoney;

            if(inventory.coinsCountTrue >= aRendreHMoney)
            {
  

                sliderHeight.maxValue=sauvegardeFonction3.sliderheight;
                sliderHeight.maxValue +=1f;
                sauvegardeFonction3.sliderheight=sliderHeight.maxValue;

                
                inventory.coinsCountTrue-=aRendreHMoney;
                aRendreHMoney=aRendreHMoney*15;
                inventory.bread += sliderHeight.value;
                
                
                if (GetPowerOf10(aRendreHMoney) > inventory.puissanceChiffrePairs[aRendreH + 1].chiffre)
                {
                    aRendreH++;
                    
                }

                string formattedARendreHMoney = (aRendreHMoney / Mathf.Pow(10, inventory.puissanceChiffrePairs[aRendreH].chiffre)).ToString("N0");
                textHeightMoney.text = $"Achat: {formattedARendreHMoney} de {inventory.puissanceChiffrePairs[aRendreH].puissance}";
                sauvegardeFonction3.aRendrehMoney = aRendreHMoney;
                sauvegardeFonction3.aRendreh=aRendreH;

                sauvegardeFonction3.SaveDataToJson(ValueClass);
                
                
                
            }
        }
    }
    // Correction : la fonction GetPowerOf10 doit retourner un int
    int GetPowerOf10(int number)
    {
        if (number == 0)
        {
            return 0; // Si le nombre est 0, la puissance de 10 est 0.
        }

        int power = 0;
        while (Mathf.Abs(number) >= 1)
        {
            number /= 10;
            power++;
        }

        return power;
    }

    public void OnClickQuit()
    {
        if (boutonQuit.IsInteractable())
        {
            ui.SetActive(false);
        }
    }


}   

