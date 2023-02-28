using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class AutoClickBuy : MonoBehaviour
{
    public GameController GameController;

    private double[] _shopCosts = new double[3] { 10, 15, 20 };
    private double[] _autoBonuses = new double[3] { 0, 0, 0 };
    private int[] _numberOfWorkers = new int[3] { 0, 0, 0 };
    public TMP_Text[] TextCost = new TMP_Text[3];

    private void Update()
    {
        ChangeCostText();
    }

    private void ChangeCostText()
    {
        for (int i = 0; i < TextCost.Length; i++)
        {
            TextCost[i].text = _shopCosts[i].ToString("00.00") + " $";
        }
    }

    public void FirstWorker()
    {
        BuyWorker(0);

        if (_numberOfWorkers[0] == 1)
        {
            StartCoroutine(BonusPerSeccond());
            _autoBonuses[0] += 1;
        }
    }

    public void SecondWorker()
    {
        BuyWorker(1);

        if (_numberOfWorkers[1] == 1)
        {
            _autoBonuses[1] += 2;
        }
    }

    public void ThirdWorker()
    {
        BuyWorker(2);

        if (_numberOfWorkers[2] == 1)
        {
            _autoBonuses[2] += 3;
        }
    }

    private void BuyWorker(int i)
    {
        if (GameController.Score >= _shopCosts[i])
        {
            GameController.Score -= (int)_shopCosts[i];
            _shopCosts[i] *= 1.25f;
            _autoBonuses[i] *= 1.15f;
            _numberOfWorkers[i]++;
        }
    }

    private IEnumerator BonusPerSeccond()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            for (int i = 0; i < _autoBonuses.Length; i++)
            {
                GameController.Score += (int)_autoBonuses[i];
            }
        }
    }
}
