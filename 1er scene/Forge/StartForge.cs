using UnityEngine;
using UnityEngine.UI;

public class StartForge : MonoBehaviour
{
    public Button boutonQuit;
    public Button boutonLength;
    public GameObject ui;

    public ArrayForge arrayForge;

    public string[] targetTag;

    [HideInInspector]
    public float xValue = 0.0f;
    [HideInInspector]
    public float zValue = 0.0f;

    public Slider sliderHeight;

    public Text textHeightMoney;
    public Text RessourceValue;

    private int aRendreH =0;

    public int aRendreHMoney = 10;

    public Text textHeight;

    public string stringClassName;
    public int ValueClass;

    public LayerMask myLayerMask;

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

        sauvegardeFonction3.LoadDataFromJson(ValueClass);
                   
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
                if (CheckTargetTag(hit.collider.gameObject,"Forge1"))
                {
                    ui.SetActive(true);
                    stringClassName="Forge1";
                    ValueClass=8;

                }
                if (CheckTargetTag(hit.collider.gameObject,"Forge2"))
                {
                    ui.SetActive(true);

                    stringClassName="Forge2";
                    ValueClass=9;

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
        sauvegardeFonction3.LoadDataFromJson(ValueClass);
        arrayForge.DestroyHouse(ValueClass);
        
        sliderHeight.maxValue = sauvegardeFonction3.sliderheight;
        sauvegardeFonction3.height = Mathf.FloorToInt(sliderHeight.value);
        
        RessourceValue.text = "Copper : X"+sliderHeight.value.ToString();
        textHeight.text = $"Height: {sauvegardeFonction3.height - 1f:F2}";

        

        sauvegardeFonction3.retrievedVector3.y = -1f;
        arrayForge.BuildHouse(sauvegardeFonction3.length, sauvegardeFonction3.height, sauvegardeFonction3.width, sauvegardeFonction3.retrievedVector3,stringClassName);
        sauvegardeFonction3.SaveDataToJson(ValueClass);
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

                inventory.Copper += sliderHeight.value;
                inventory.coinsCountTrue-=aRendreHMoney;
                aRendreHMoney=aRendreHMoney*35;
                
                
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

