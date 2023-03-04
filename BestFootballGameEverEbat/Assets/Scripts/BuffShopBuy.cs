using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffShopBuy : MonoBehaviour
{
    public GameController controller;
    public BackToMenu backToMenu;
    public GameObject[] Buttons = new GameObject[4];
    public UpdateShopBuy UpdateShopBuy;

    private int _count;
    private bool _thirdActivator = true;

    public void FirstBoost()
    {
        if(_count == 0 || _count == 50)
        {
            _count = 0;

            backToMenu.OnClick();
            StartCoroutine("ForFirstBoost");
        }
    }

    public void ThirdBoost()
    {
        if(_thirdActivator)
        {
            backToMenu.OnClick();

            _thirdActivator = false;
            controller.ThirdBuffKoef = 2;

            StartCoroutine("ForThirdBoost");
        }
    }

    private IEnumerator ForFirstBoost()
    {
        yield return new WaitForSeconds(0.2f);
        controller.OnClick();

        if(++_count < 50)
        {
            StartCoroutine("ForFirstBoost");
        }
    }

    private IEnumerator ForThirdBoost()
    {
        yield return new WaitForSeconds(180);

        controller.ThirdBuffKoef = 1;
        _thirdActivator = true;
    }
}
