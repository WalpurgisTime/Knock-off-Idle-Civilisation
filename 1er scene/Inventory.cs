using UnityEngine;
using UnityEngine.UI; // Added using directive for UI
using System; // Added using directive for SerializableAttribute
using System.Collections;

public class Inventory : MonoBehaviour
{
    public float coinsCount;
    public float coinsCountTrue=0f;

    public static Inventory instance;
    public Text coinsCountText;
    public Text puissanceArgentText;

    private float countdown = 1f;
    private float timeBetweenMoney = 0.1f;
    public int puissanceNumberGold = 0;
    public float MoneyBoulangerieir = 100f;
    public float MoneyBoulangerieirTrue;

    public PuissanceChiffrePair[] puissanceChiffrePairs;

    public sauvegardeFonction sauvegardeFonction3;

    public Text chickenText;
    public Text breadText;
    public Text DamageText;
    public Text sorceryText;
    public Text IronText;
    public Text CopperText;


    public float chicken =1.0f;
    public float Copper=1.0f;
    public float sorcery=1.0f;
    public float Iron=1.0f;
    public float damage=0.1f;
    public float bread=1.0f;

    
    public bool chickenBool=true;
    public bool CopperBool=true;
    public bool sorceryBool=true;
    public bool IronBool=true;
    public bool damageBool=true;
    public bool breadBool=true;



    [Serializable]
    public class PuissanceChiffrePair
    {
        public string puissance;
        public int chiffre;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this; 
    }

    void Start()
    {
        chickenBool = true;
        breadBool=true;
        damageBool=true;
        CopperBool=true;
        IronBool = true;
        sorceryBool = true;


        sauvegardeFonction3.LoadDataFromJson(0);
        chickenText.text = sauvegardeFonction3.chicken.ToString();
        sorceryText.text = sauvegardeFonction3.sorcery.ToString();
        CopperText.text = sauvegardeFonction3.Copper.ToString();
        IronText.text = sauvegardeFonction3.Iron.ToString();
        breadText.text = sauvegardeFonction3.bread.ToString();
        DamageText.text = sauvegardeFonction3.Damage.ToString();
        coinsCount+=sauvegardeFonction3.goldCoins;
        coinsCountTrue+=sauvegardeFonction3.goldCoins;
        
    
    }

    private void Update()
    {   
        
        if(chickenBool==true)
        {
            chickenBool = false;
            StartCoroutine(AddChickenWithDelay(chicken, 5f));

                        
        }
        if(breadBool)
        {
            breadBool = false;
            StartCoroutine(AddbreadWithDelay(bread, 10f));           
        }
        if(IronBool)
        {
            IronBool = false;
            StartCoroutine(AddIronWithDelay(Iron, 20f));          
        }
        if(damageBool)
        {
            damageBool = false;
            StartCoroutine(AddDamageWithDelay(damage, 400f));            
        }
        if(CopperBool)
        {
            CopperBool = false;
            StartCoroutine(AddCopperWithDelay(Copper, 100f));         
        }

        if(sorceryBool)
        {
            sorceryBool = false;
            StartCoroutine(AddsorceryWithDelay(sorcery, 200f));           
        }
        if (countdown <= 0f)
        {
            
            float Argent = MoneyBoulangerieir / 10f;
            AddCoins(Argent);
            

            countdown = timeBetweenMoney;
            return;
        }
        countdown -= Time.deltaTime;

        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.goldCoins=coinsCountTrue;
        chickenText.text = sauvegardeFonction3.chicken.ToString();
        breadText.text = sauvegardeFonction3.bread.ToString();
        IronText.text = sauvegardeFonction3.Iron.ToString();
        CopperText.text = sauvegardeFonction3.Copper.ToString();
        sorceryText.text = sauvegardeFonction3.sorcery.ToString();
        DamageText.text = sauvegardeFonction3.Damage.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        PuissanceArgent(coinsCountTrue);


    }

    public void PuissanceArgent(float valeur)
    {
        string notationScientifiqueV1 = valeur.ToString("0.0e+0", System.Globalization.CultureInfo.InvariantCulture);
        char dernierCaractere = notationScientifiqueV1[notationScientifiqueV1.Length - 1];
        string chaineCaractere = dernierCaractere.ToString();
        float resultat = float.Parse(chaineCaractere);

        int nombreEntier = Convert.ToInt32(resultat);
        float reste = resultat % 3f;
        int quotient = nombreEntier / 3;

        
        
        puissanceArgentText.text = puissanceChiffrePairs[quotient].puissance;
        
        

        if(reste==0f)
        {
            string notationScientifique = valeur.ToString("0.0e+0", System.Globalization.CultureInfo.InvariantCulture);
            string quatrePremiersCaracteres = notationScientifique.Substring(0,3);
            coinsCountText.text=quatrePremiersCaracteres;
        }
        if(reste==1f)
        {
            string notationScientifique = valeur.ToString("00.0e+0", System.Globalization.CultureInfo.InvariantCulture);
            string quatrePremiersCaracteres = notationScientifique.Substring(0,4);
            coinsCountText.text=quatrePremiersCaracteres;
        }
        if(reste==2f)
        {
            string notationScientifique = valeur.ToString("000.0e+0", System.Globalization.CultureInfo.InvariantCulture);
            string quatrePremiersCaracteres = notationScientifique.Substring(0,5);
            coinsCountText.text=quatrePremiersCaracteres;
            
        }
        
        
        
    }

    public void AddCoins(float count)
    {
        coinsCountTrue += MoneyBoulangerieirTrue;
    }

    public void AddChicken(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.chicken += count;
        
        chickenText.text = sauvegardeFonction3.chicken.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        chickenBool=true;
    }

    private IEnumerator AddChickenWithDelay(float count, float delay)
    {
 
        yield return new WaitForSeconds(delay);
       
        AddChicken(count);
    }

    public void Addbread(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.bread += count;
        breadText.text = sauvegardeFonction3.bread.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        breadBool=true;
    }

    private IEnumerator AddbreadWithDelay(float count, float delay)
    {
        yield return new WaitForSeconds(delay);
        Addbread(count);
    }

    public void AddIron(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Iron += count;
        IronText.text = sauvegardeFonction3.Iron.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        IronBool=true;
    }

    
    private IEnumerator AddIronWithDelay(float count, float delay)
    {
        yield return new WaitForSeconds(delay);
        AddIron(count);
    }

    public void Addsorcery(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.sorcery += count;
        sorceryText.text = sauvegardeFonction3.sorcery.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        sorceryBool=true;
    }

        
    private IEnumerator AddsorceryWithDelay(float count, float delay)
    {
        yield return new WaitForSeconds(delay);
        Addsorcery(count);
    }

    public void AddDamage(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Damage += count;
        DamageText.text = sauvegardeFonction3.Damage.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        damageBool=true;
    }

            
    private IEnumerator AddDamageWithDelay(float count, float delay)
    {
        yield return new WaitForSeconds(delay);
        AddDamage(count);
    }


    public void AddCopper(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Copper += count;
        CopperText.text = sauvegardeFonction3.Copper.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
        CopperBool=true;
    }

            
    private IEnumerator AddCopperWithDelay(float count, float delay)
    {
        yield return new WaitForSeconds(delay);
        AddCopper(count);
    }



    public void RemoveCoins(float count)
    {
        coinsCountTrue -= count;
    }


    public void RemoveChicken(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.chicken -= count;
        chickenText.text = sauvegardeFonction3.chicken.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void Removebread(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.bread -= count;
        breadText.text = sauvegardeFonction3.bread.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void RemoveIron(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Iron -= count;
        IronText.text = sauvegardeFonction3.Iron.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void Removesorcery(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.sorcery -= count;
        sorceryText.text = sauvegardeFonction3.sorcery.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void RemoveDamage(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Damage -= count;
        DamageText.text = sauvegardeFonction3.Damage.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

    public void RemoveCopper(float count)
    {
        sauvegardeFonction3.LoadDataFromJson(0);
        sauvegardeFonction3.Copper -= count;
        CopperText.text = sauvegardeFonction3.Copper.ToString();
        sauvegardeFonction3.SaveDataToJson(0);
    }

}
