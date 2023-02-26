using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObj : MonoBehaviour
{
    private bool move;
    private Vector2 randomVector;

    public void startMotion (int scoreIncrease)
    {
        transform.localPosition = Vector2.zero;
        GetComponent<Text>().text = "+" + scoreIncrease;
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        move = true;
        GetComponent<Animation>().Play();
    }
    
    void Update()
    {
        if (!move) return;
        transform.Translate(randomVector * Time.deltaTime);
    }

    public void StopMotion()
    {
        move = false;
    }
}
