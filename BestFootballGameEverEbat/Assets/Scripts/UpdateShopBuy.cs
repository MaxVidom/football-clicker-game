using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateShopBuy : MonoBehaviour
{
    public GameController GameController;
    public TMP_Text[] TextCost = new TMP_Text[2];
    public int TotalBonus = 1;
    public int SecondBuffKoef = 1;

    private double[] _upgradeCosts = new double[2] { 10, 15 };
    private int[] _upgradeBonuses = new int[2] { 1, 0 };
    private int _koef;

    private void Start()
    {
        TotalBonus = _upgradeBonuses[0] + _upgradeBonuses[1];
    }

    private void Update()
    {
        ChangeCostText();
    }

    private void ChangeCostText()
    {
        for (int i = 0; i < TextCost.Length; i++)
        {
            TextCost[i].text = _upgradeCosts[i].ToString("00.00") + " $";
        }
    }

    public void FirstUpgrade()
    {
        _koef = 1;
        BuyUpgrade(0);
    }

    public void SecondUpgrade()
    {
        _koef = 5;
        BuyUpgrade(1);
    }

    private void BuyUpgrade(int i)
    {
        if (GameController.Score >= _upgradeCosts[i])
        {
            GameController.Score -= (int)_upgradeCosts[i];
            _upgradeCosts[i] *= 1.2;
            _upgradeBonuses[i] += _koef;

            TotalBonus = 0;
            for (int j = 0; j < _upgradeBonuses.Length; j++)
            {
                TotalBonus += _upgradeBonuses[j];
            }
        }
    }
}
