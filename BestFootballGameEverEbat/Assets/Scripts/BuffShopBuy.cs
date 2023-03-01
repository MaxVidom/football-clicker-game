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

    private int _count;

    public void FirstBoost()
    {
        if(_count == 0 || _count == 50)
        {
            _count = 0;

            backToMenu.OnClick();
            StartCoroutine("ForFirstBoost");
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
}
