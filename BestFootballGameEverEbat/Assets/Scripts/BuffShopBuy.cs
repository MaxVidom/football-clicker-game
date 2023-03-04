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
    public AutoClickBuy AutoClickBuy;

    private int _count;
    private bool _firstActivator = true;
    private bool _secondActivator = true;
    private bool _thirdActivator = true;
    private bool _fourthActivator = true;

    public void FirstBoost()
    {
        if(_firstActivator)
        {
            _count = 0;
            _firstActivator = false;

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

    public void FourthBoost()
    {
        if(_fourthActivator)
        {
            backToMenu.OnClick();

            _secondActivator = false;
            AutoClickBuy.FourthBuffKoef = 2;

            StartCoroutine("ForFourthBoost");
        }
    }

    private IEnumerator ForFirstBoost()
    {
        yield return new WaitForSeconds(0.2f);

        controller.OnClick();

        if(++_count < 50)
        {
            _firstActivator = true;

            StartCoroutine("ForFirstBoost");
        }
    }

    private IEnumerator ForThirdBoost()
    {
        yield return new WaitForSeconds(180);

        controller.ThirdBuffKoef = 1;
        _thirdActivator = true;
    }

    private IEnumerator ForFourthBoost()
    {
        yield return new WaitForSeconds(15);

        AutoClickBuy.FourthBuffKoef = 1;
        _fourthActivator = true;
    }
}
