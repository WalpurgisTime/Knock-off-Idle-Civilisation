
using UnityEngine;
using UnityEngine.UI;

public class ButtonInternet : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonAddTrueToBakery;
    public Button buttonAddTrueToArmoury;
    public Button buttonAddTrueToArmoury2;
    public Button buttonAddTrueToArmoury3;
    public Button buttonAddTrueToButchery;
    public Button buttonAddTrueToButchery2;
    public Button buttonAddTrueToButchery3;
    public Button buttonAddTrueToForge;
    public Button buttonAddTrueToForge2;
    public Button buttonAddTrueToCamp;
    public Button buttonAddTrueToCamp2;
    public Button buttonAddTrueToCamp3;
    public sauvegardeFonction sauvegardeFonction3;

    public Inventory inventory;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;
    public Text text11;
    public Text text12;

    
    public void OnClickAddTrueToBakery()
    {
        if (buttonAddTrueToBakery.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(1);
            float GoldValue = 100.0f;
            if(sauvegardeFonction3.chicken>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text1.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveChicken(GoldValue);

            }
            if(sauvegardeFonction3.chicken<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text1.text = "Il manque" + (sauvegardeFonction3.chicken-GoldValue).ToString();
            }
            else
            {
                text1.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(1);

        }
       
    }

    public void OnClickAddTrueToArmoury()
    {
        if (buttonAddTrueToArmoury.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(2);
            float GoldValue = 10000.0f;
            if(sauvegardeFonction3.goldCoins>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text2.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCoins(GoldValue);

            }
            if(sauvegardeFonction3.goldCoins<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text2.text = "Il manque" + (sauvegardeFonction3.goldCoins-GoldValue).ToString();
            }
            else
            {
                text2.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(2);

        }   
    }

    public void OnClickAddTrueToArmoury2()
    {
        if (buttonAddTrueToArmoury2.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(3);
            float GoldValue = 10.0f;
            if(sauvegardeFonction3.Iron>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text3.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveIron(GoldValue);

            }
            if(sauvegardeFonction3.Iron<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text3.text = "Il manque" + (sauvegardeFonction3.Iron-GoldValue).ToString();
            }
            else
            {
                text3.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(3);

        }   
    }

    public void OnClickAddTrueToArmoury3()
    {
        if (buttonAddTrueToArmoury3.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(4);
            float GoldValue = 1000.0f;
            if(sauvegardeFonction3.bread>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text4.text = "Acheté pour " + GoldValue.ToString();
                inventory.Removebread(GoldValue);

            }
            if(sauvegardeFonction3.bread<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text4.text = "Il manque" + (sauvegardeFonction3.bread-GoldValue).ToString();
            }
            else
            {
                text4.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(4);

        }   
    }

    public void OnClickAddTrueToButchery()
    {
        if (buttonAddTrueToButchery.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(5);
            float GoldValue = 1.0f;
            if(sauvegardeFonction3.Copper>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text5.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCopper(GoldValue);

            }
            if(sauvegardeFonction3.Copper<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text5.text = "Il manque" + (sauvegardeFonction3.Copper-GoldValue).ToString();
            }
            else
            {
                text5.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(5);

        }   
    }
    public void OnClickAddTrueToButchery2()
    {
        if (buttonAddTrueToButchery2.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(6);
            float GoldValue = 100000.0f;
            if(sauvegardeFonction3.goldCoins>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text6.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCoins(GoldValue);

            }
            if(sauvegardeFonction3.goldCoins<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text6.text = "Il manque" + (sauvegardeFonction3.goldCoins-GoldValue).ToString();
            }
            else
            {
                text6.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(6);

        }   
    }
    public void OnClickAddTrueToButchery3()
    {
        if (buttonAddTrueToButchery3.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(7);
            float GoldValue = 5.0f;
            if(sauvegardeFonction3.Iron>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text7.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveIron(GoldValue);

            }
            if(sauvegardeFonction3.Iron<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text7.text = "Il manque" + (sauvegardeFonction3.Iron-GoldValue).ToString();
            }
            else
            {
                text7.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(7);

        }   
    }

    public void OnClickAddTrueToForge()
    {
        if (buttonAddTrueToForge.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(8);
            float GoldValue = 2.0f;
            if(sauvegardeFonction3.Copper>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text8.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCopper(GoldValue);

            }
            if(sauvegardeFonction3.Copper<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text8.text = "Il manque" + (sauvegardeFonction3.Copper-GoldValue).ToString();
            }
            else
            {
                text8.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(8);

        }   
    }
    public void OnClickAddTrueToForge2()
    {
        if (buttonAddTrueToForge2.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(9);
            float GoldValue = 100000.0f;
            if(sauvegardeFonction3.goldCoins>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text9.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCoins(GoldValue);

            }
            if(sauvegardeFonction3.goldCoins<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text9.text = "Il manque" + (sauvegardeFonction3.goldCoins-GoldValue).ToString();
            }
            else
            {
                text9.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(9);

        }   
    }

    public void OnClickAddTrueToCamp()
    {
        if (buttonAddTrueToForge2.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(10);
            float GoldValue = 10.0f;
            if(sauvegardeFonction3.bread>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text10.text = "Acheté pour " + GoldValue.ToString();
                inventory.Removebread(GoldValue);

            }
            if(sauvegardeFonction3.bread<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text10.text = "Il manque" + (sauvegardeFonction3.bread-GoldValue).ToString();
            }
            else
            {
                text10.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(10);

        }   
    }
    public void OnClickAddTrueToCamp2()
    {
        if (buttonAddTrueToForge2.IsInteractable())
        {
            sauvegardeFonction3.LoadDataFromJson(11);
            float GoldValue = 100.0f;
            if(sauvegardeFonction3.chicken>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text11.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveChicken(GoldValue);

            }
            if(sauvegardeFonction3.chicken<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text11.text = "Il manque" + (sauvegardeFonction3.chicken-GoldValue).ToString();
            }
            else
            {
                text11.text = "Acheté pour " + GoldValue.ToString();
            }
            sauvegardeFonction3.SaveDataToJson(11);

        }   
    }
    public void OnClickAddTrueToCamp3()
    {
        if (buttonAddTrueToForge2.IsInteractable())
        {  
            sauvegardeFonction3.LoadDataFromJson(12);
            float GoldValue = 1000000.0f;
            if(sauvegardeFonction3.goldCoins>=GoldValue && sauvegardeFonction3.unlock ==false)
            {
                sauvegardeFonction3.unlock =true;
                text12.text = "Acheté pour " + GoldValue.ToString();
                inventory.RemoveCoins(GoldValue);
                

            }
            if(sauvegardeFonction3.goldCoins<GoldValue && sauvegardeFonction3.unlock ==false)
            {
                text12.text = "Il manque" + (sauvegardeFonction3.goldCoins-GoldValue).ToString();
            }
            else
            {
                text12.text = "Acheté pour 1000000 gold";
            }
            
            sauvegardeFonction3.SaveDataToJson(12);

        }   
    }
}
