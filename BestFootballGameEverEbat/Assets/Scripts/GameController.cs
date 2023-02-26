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

    private Animator _ballAnimator;
    private bool _isClick = false;
    private int _score;
    private int bonus = 1;

    private void Start()
    {
        _ballAnimator = Ball.GetComponent<Animator>();
    }

    private void Update()
    {
        scoreText.text = _score + "$";
        
        GoText.gameObject.SetActive(!_isClick);
    }

    public void OnClick()
    {
        StartAnimationForBall();

        _score = _score + bonus;
        _isClick = true;

        StopCoroutine("TimerText");
        StartCoroutine("TimerText");
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
