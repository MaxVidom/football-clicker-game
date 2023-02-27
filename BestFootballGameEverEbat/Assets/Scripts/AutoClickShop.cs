using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    public GameObject AutoClickPanel;

    public void OnClick()
    {
        AutoClickPanel.SetActive(true);
    }
}
