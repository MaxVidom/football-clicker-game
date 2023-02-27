using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public GameObject UpdatePanel, BuffPanel, AutoClickPanel;

    public void OnClick()
    {
        UpdatePanel.SetActive(false);
        BuffPanel.SetActive(false);
        AutoClickPanel.SetActive(false);
    }
}
