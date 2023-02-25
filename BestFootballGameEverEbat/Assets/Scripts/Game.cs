using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    public Text scoreText, bonusText, clickText;
    public int score;
    private int bonus = 1, p;
    public GameObject clickTextPrefab, clickPanel;
    private ClickObj[] clickTextPool = new ClickObj[15];
    private int clickNum;
    private int k1, k2, k3;
    [Header("Shop")]
    public int WorkersCount;
    public int[] shopCosts;
    public int[] ShopBonuses;
    public Text[] shopText;
    public GameObject shopPan1, shopPan2, shopPan3;


    void Start()
    {
        StartCoroutine(BonusPerSec());
        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(clickTextPrefab, clickPanel.transform).GetComponent<ClickObj>();

        }
    }


    private void Update()
    {
        scoreText.text = score + "$";
    }


    public void shopPan1_HideAndShow()
    {
        shopPan1.SetActive(!shopPan1.activeSelf);
    }
    public void shopPan2_HideAndShow()
    {
        shopPan2.SetActive(!shopPan2.activeSelf);
    }
    public void shopPan3_HideAndShow()
    {
        shopPan3.SetActive(!shopPan3.activeSelf);
    }

    public void shopAddBonus1(int index)
    {
        if (score >= shopCosts[0])
        {
            k1++;
            shopCosts[0] = shopCosts[0] * 23 / 20;
            shopText[0].text = shopCosts[0] + "$" + "\n" + "Ур." + k1;
            bonus += ShopBonuses[0];
            score -= shopCosts[0];
            clickText.text = "Мужская сила = " + bonus + "Н";
        }
        else
        {
            shopText[0].text = "No money";
        }
        if (k1 == 20)
        {
            bonus += ShopBonuses[0]*20;
            ShopBonuses[0] *= 2;
        }
    }
    public void shopAddBonu2(int index)
    {
        if (score >= shopCosts[2])
        {
            k2++;
            shopCosts[2] = shopCosts[2] * 22 / 20;
            shopText[2].text = shopCosts[2] + "$" + "\n" + "Ур." + k2;
            bonus += ShopBonuses[2];
            score -= shopCosts[2];
            clickText.text = "Мужская сила = " + bonus + "Н";
        }
        else
        {
            shopText[2].text = "No money";
        }
        if (k2 == 20)
        {
            bonus += ShopBonuses[2] * 20;
            ShopBonuses[2] *= 2;
        }
    }


    IEnumerator BonusPerSec()
    {
        while (true)
        {
            score += WorkersCount;
            yield return new WaitForSeconds(1);
        }
    }


    public void NewWorker(int index)
    {
        if (score >= shopCosts[1])
        {
            WorkersCount+= ShopBonuses[1];
            score -= shopCosts[1];
            shopCosts[1] *= 1;
            shopText[1].text = "Купити улучшалку" + shopCosts[1] + "$";
            k3++;
        }
        else
        {
            shopText[1].text = "No money";
        }
        
        if (k3==20)
        {
            WorkersCount *= 2;
            ShopBonuses[1] *= 2;
        }
    }



    public void OnClick()
    {
        clickTextPool[clickNum].startMotion(bonus);
        clickNum = clickNum == clickTextPool.Length - 1 ? 0 : clickNum + 1;
        score = score + bonus;
    }
}