using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text GoText;
    public GameObject Ball;
    public GameObject clickTextPrefab;
    public GameObject ClickPanel;
    public UpdateShopBuy UpdateShopBuy;
    public int Score;
    public int ThirdBuffKoef = 1;

    private Animator _ballAnimator;
    private ClickObj[] clickTextPool = new ClickObj[15];
    private int clickNum;
    private bool _isClick = false;
    private int _bonus;

    private void Start()
    {
        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(clickTextPrefab, ClickPanel.transform).GetComponent<ClickObj>();
        }

        _ballAnimator = Ball.GetComponent<Animator>();
    }

    private void Update()
    {
        scoreText.text = Score + "$";

        _bonus = UpdateShopBuy.TotalBonus;

        GoText.gameObject.SetActive(!_isClick);
    }

    public void OnClick()
    {
        StartAnimationForBall();
        AddParticles();

        Score += _bonus * ThirdBuffKoef;
        _isClick = true;

        StopCoroutine("TimerText");
        StartCoroutine("TimerText");
    }

    private void AddParticles()
    {
        clickTextPool[clickNum].startMotion(_bonus * ThirdBuffKoef);
        clickNum = clickNum == clickTextPool.Length - 1 ? 0 : clickNum + 1;
    }

    private void StartAnimationForBall()
    {
        _ballAnimator.Play("ScaleBall");
    }

    private IEnumerator TimerText()
    {
        yield return new WaitForSeconds(3);

        _isClick = false;
    }
}
