using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinUI : MonoBehaviour
{

    public Ease animEase;

    public float distanceTween;

    public float timeTween;


    void Start()
    {
        transform.position = new Vector2(transform.position.x, -2.5f);
        var txtComponent = GetComponent<TextMeshProUGUI>();
        transform.DOMove(new Vector3(transform.position.x, (transform.position.y + distanceTween)), timeTween)
		.SetEase(animEase)
        .OnComplete(() => {
        this.gameObject.SetActive(false);
        });
        var txtColor = txtComponent.color;
        DOTween.ToAlpha(()=> txtColor, x=> txtColor = x, 0, timeTween)
        .SetEase(Ease.Linear)  
        .OnUpdate(() => {
            txtComponent.color = txtColor;
        });
    }
}
