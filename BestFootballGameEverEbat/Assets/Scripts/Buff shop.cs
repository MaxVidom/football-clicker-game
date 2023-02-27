using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffshop : MonoBehaviour
{
    public GameObject BuffPanel;

    public void OnClick()
    {
        BuffPanel.SetActive(true);
    }
}
