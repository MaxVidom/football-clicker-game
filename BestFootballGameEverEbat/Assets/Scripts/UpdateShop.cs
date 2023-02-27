using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShop : MonoBehaviour
{
    public GameObject UpdatePanel;

    public void OnClick()
    {
        UpdatePanel.SetActive(true);
    }
}
