using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YourNamespace; 

public class InfoTarget : MonoBehaviour
{
    private bool isOpened = false;
    public Button InfoButton;
    public Text textInfo;

    public Text name1;
    public Text Health1;
    public Text Radius1;
    public Text target1;
    public Text bullet1;
    public Text damage1;

    public Text name2;
    public Text Health2;
    public Text Radius2;
    public Text target2;
    public Text bullet2;
    public Text damage2;

    public Text name3;
    public Text Health3;
    public Text Radius3;
    public Text target3;
    public Text bullet3;
    public Text damage3;

    public Text name4;
    public Text Health4;
    public Text Radius4;
    public Text target4;
    public Text bullet4;
    public Text damage4;

    public Text name5;
    public Text Health5;
    public Text Radius5;
    public Text target5;
    public Text bullet5;
    public Text damage5;

    public Text name6;
    public Text Health6;
    public Text Radius6;
    public Text target6;
    public Text bullet6;
    public Text damage6;

    public Text name7;
    public Text Health7;
    public Text Radius7;
    public Text target7;
    public Text bullet7;
    public Text damage7;

    public Text name8;
    public Text Health8;
    public Text Radius8;
    public Text target8;
    public Text bullet8;
    public Text damage8;

    public Text name9;
    public Text Health9;
    public Text Radius9;
    public Text target9;
    public Text bullet9;
    public Text damage9;

    public Text name10;
    public Text Health10;
    public Text Radius10;
    public Text target10;
    public Text bullet10;
    public Text damage10;

    public Text name11;
    public Text Health11;
    public Text Radius11;
    public Text target11;
    public Text bullet11;
    public Text damage11;

    public Text name12;
    public Text Health12;
    public Text Radius12;
    public Text target12;
    public Text bullet12;
    public Text damage12;

    public Text name13;
    public Text Health13;
    public Text Radius13;
    public Text target13;
    public Text bullet13;
    public Text damage13;

    public Text name14;
    public Text Health14;
    public Text Radius14;
    public Text target14;
    public Text bullet14;
    public Text damage14;

    public Text name15;
    public Text Health15;
    public Text Radius15;
    public Text target15;
    public Text bullet15;
    public Text damage15;

    public Text name16;
    public Text Health16;
    public Text Radius16;
    public Text target16;
    public Text bullet16;
    public Text damage16;

    public Text Ename1;
    public Text EHealth1;
    public Text ERadius1;
    public Text Etarget1;
    public Text Ebullet1;
    public Text Edamage1;

    public Text Ename2;
    public Text EHealth2;
    public Text ERadius2;
    public Text Etarget2;
    public Text Ebullet2;
    public Text Edamage2;

    public Text Ename3;
    public Text EHealth3;
    public Text ERadius3;
    public Text Etarget3;
    public Text Ebullet3;
    public Text Edamage3;
    
    public Text Ename4;
    public Text EHealth4;
    public Text ERadius4;
    public Text Etarget4;
    public Text Ebullet4;
    public Text Edamage4;

    public Text Ename5;
    public Text EHealth5;
    public Text ERadius5;
    public Text Etarget5;
    public Text Ebullet5;
    public Text Edamage5;

    public Text Ename6;
    public Text EHealth6;
    public Text ERadius6;
    public Text Etarget6;
    public Text Ebullet6;
    public Text Edamage6;

    public Text Ename7;
    public Text EHealth7;
    public Text ERadius7;
    public Text Etarget7;
    public Text Ebullet7;
    public Text Edamage7;
    
    public Text Ename8;
    public Text EHealth8;
    public Text ERadius8;
    public Text Etarget8;
    public Text Ebullet8;
    public Text Edamage8;

    public Text Ename9;
    public Text EHealth9;
    public Text ERadius9;
    public Text Etarget9;
    public Text Ebullet9;
    public Text Edamage9;

    public Text Ename10;
    public Text EHealth10;
    public Text ERadius10;
    public Text Etarget10;
    public Text Ebullet10;
    public Text Edamage10;

    public Text Ename11;
    public Text EHealth11;
    public Text ERadius11;
    public Text Etarget11;
    public Text Ebullet11;
    public Text Edamage11;
    
    public Text Ename12;
    public Text EHealth12;
    public Text ERadius12;
    public Text Etarget12;
    public Text Ebullet12;
    public Text Edamage12;

    public Text Ename13;
    public Text EHealth13;
    public Text ERadius13;
    public Text Etarget13;
    public Text Ebullet13;
    public Text Edamage13;

    public Text Ename14;
    public Text EHealth14;
    public Text ERadius14;
    public Text Etarget14;
    public Text Ebullet14;
    public Text Edamage14;

    public Text Ename15;
    public Text EHealth15;
    public Text ERadius15;
    public Text Etarget15;
    public Text Ebullet15;
    public Text Edamage15;
    
    public Text Ename16;
    public Text EHealth16;
    public Text ERadius16;
    public Text Etarget16;
    public Text Ebullet16;
    public Text Edamage16;

    public int Index= 0 ;
    public int EnnemyIndex = 0;

    public GameObject canvas1;
    public GameObject canvas2;

    public ScrollRect verticalScrollRect1;
    public ScrollRect verticalScrollRect2;

    private bool Opposite;

    void Start()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpened)
        {
            Recherche();
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                float scrollAmount = verticalInput * 1f * Time.deltaTime;
                
                // Ajustez la position du contenu des deux Scroll Rect
                verticalScrollRect1.verticalNormalizedPosition += scrollAmount;
                verticalScrollRect2.verticalNormalizedPosition += scrollAmount;
            }
        }


        
    }

    public void OnClickInfo()
    {
        if(InfoButton.IsInteractable())
        {
            isOpened = true;
            if(Opposite == true)
            {
                canvas1.SetActive(Opposite);
                canvas2.SetActive(Opposite);
                Opposite=false;
            }
            else
            {   
                canvas1.SetActive(Opposite);
                canvas2.SetActive(Opposite);
                Opposite = true;
            }
            
        }

    }

    void Recherche()
    {
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allGameObjects)
        {
            // Vérifier si le GameObject a un script nommé "WarriorInfo" attaché
            WarriorInfo warriorInfoScript = go.GetComponent<WarriorInfo>();

            if (warriorInfoScript != null && go.name != "GameManagerBattle")
            {
                // Le script "WarriorInfo" est attaché à ce GameObject, vous pouvez faire quelque chose avec ici
            
                
                if(go.name.Contains("Ally"))
                {
                    Index ++;
                }
                if(go.name.Contains("Enemy"))
                {
                    EnnemyIndex ++;
                }

                if(Index ==1 && (go.name.Contains("Ally")))
                {
                    Debug.Log("Ca marche");
                    name1.text = "Name : " + go.name;
                    Health1.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius1.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target1.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet1.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage1.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==2 && (go.name.Contains("Ally")))
                {
                    name2.text = "Name : " + go.name;
                    Health2.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius2.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target2.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet2.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage2.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==3 && (go.name.Contains("Ally")))
                {
                    name3.text = "Name : " + go.name;
                    Health3.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius3.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target3.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet3.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage3.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                
                if(Index ==4 && (go.name.Contains("Ally")))
                {
                    name4.text = "Name : " + go.name;
                    Health4.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius4.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target4.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet4.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage4.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==5 && (go.name.Contains("Ally")))
                {
                    name5.text = "Name : " + go.name;
                    Health5.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius5.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target5.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet5.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage5.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==6 && (go.name.Contains("Ally")))
                {
                    name6.text = "Name : " + go.name;
                    Health6.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius6.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target6.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet6.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage6.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                
                if(Index ==7 && (go.name.Contains("Ally")))
                {
                    name7.text = "Name : " + go.name;
                    Health7.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius7.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target7.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet7.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage7.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==8 && (go.name.Contains("Ally")))
                {
                    name8.text = "Name : " + go.name;
                    Health8.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius8.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target8.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet8.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage8.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(Index ==9 && (go.name.Contains("Ally")))
                {
                    name9.text = "Name : " + go.name;
                    Health9.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius9.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target9.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet9.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage9.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                
                if(Index ==10 && (go.name.Contains("Ally")))
                {
                    name10.text = "Name : " + go.name;
                    Health10.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius10.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target10.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet10.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage10.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(Index ==11 && (go.name.Contains("Ally")))
                {
                    name11.text = "Name : " + go.name;
                    Health11.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius11.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target11.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet11.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage11.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                if(Index ==12 && (go.name.Contains("Ally")))
                {
                    name12.text = "Name : " + go.name;
                    Health12.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius12.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target12.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet12.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage12.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                if(Index ==13 && (go.name.Contains("Ally")))
                {
                    name13.text = "Name : " + go.name;
                    Health13.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius13.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target13.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet13.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage13.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                if(Index ==14 && (go.name.Contains("Ally")))
                {
                    name14.text = "Name : " + go.name;
                    Health14.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius14.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target14.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet14.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage14.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                if(Index ==15 && (go.name.Contains("Ally")))
                {
                    name15.text = "Name : " + go.name;
                    Health15.text ="Health :"+ warriorInfoScript.health.ToString();  
                    Radius15.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    target15.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    bullet15.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    damage15.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }







                if(EnnemyIndex ==1 && (go.name.Contains("Enemy")))
                {
                    Ename1.text = "Name : " + go.name;
                    EHealth1.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius1.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget1.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet1.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage1.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }

                if(EnnemyIndex ==2 && (go.name.Contains("Enemy")))
                {
                    Ename2.text = "Name : " + go.name;
                    EHealth2.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius2.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget2.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet2.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage2.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                if(EnnemyIndex ==3 && (go.name.Contains("Enemy")))
                {
                    Ename3.text = "Name : " + go.name;
                    EHealth3.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius3.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget3.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet3.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage3.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==4 && (go.name.Contains("Enemy")))
                {
                    Ename4.text = "Name : " + go.name;
                    EHealth4.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius4.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget4.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet4.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage4.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }           
                if(EnnemyIndex ==5 && (go.name.Contains("Enemy")))
                {
                    Ename5.text = "Name : " + go.name;
                    EHealth5.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius5.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget5.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet5.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage5.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==5 && (go.name.Contains("Enemy")))
                {
                    Ename6.text = "Name : " + go.name;
                    EHealth6.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius6.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget6.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet6.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage6.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }                      
                if(EnnemyIndex ==7 && (go.name.Contains("Enemy")))
                {
                    Ename7.text = "Name : " + go.name;
                    EHealth7.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius7.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget7.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet7.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage7.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==8 && (go.name.Contains("Enemy")))
                {
                    Ename8.text = "Name : " + go.name;
                    EHealth8.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius8.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget8.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet8.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage8.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }           
                if(EnnemyIndex ==9 && (go.name.Contains("Enemy")))
                {
                    Ename9.text = "Name : " + go.name;
                    EHealth9.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius9.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget9.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet9.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage9.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==10 && (go.name.Contains("Enemy")))
                {
                    Ename10.text = "Name : " + go.name;
                    EHealth10.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius10.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget10.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet10.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage10.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }           
                if(EnnemyIndex ==11 && (go.name.Contains("Enemy")))
                {
                    Ename11.text = "Name : " + go.name;
                    EHealth11.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius11.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget11.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet11.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage11.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==12 && (go.name.Contains("Enemy")))
                {
                    Ename12.text = "Name : " + go.name;
                    EHealth12.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius12.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget12.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet12.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage12.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }           
                if(EnnemyIndex ==13 && (go.name.Contains("Enemy")))
                {
                    Ename13.text = "Name : " + go.name;
                    EHealth13.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius13.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget13.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet13.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage13.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }
                
                if(EnnemyIndex ==14 && (go.name.Contains("Enemy")))
                {
                    Ename14.text = "Name : " + go.name;
                    EHealth14.text ="Health :"+ warriorInfoScript.health.ToString();  
                    ERadius14.text = "Radius : " +warriorInfoScript.sphereRadius.ToString();
                    Etarget14.text = "Targer : " +warriorInfoScript.allyWarrior.ToString();  
                    Ebullet14.text = "Bullet : " + warriorInfoScript.bullet.ToString();
                    Edamage14.text = "Damage : " +warriorInfoScript.damage.ToString();  
                }           
                

            }

            


        }
    }
}
