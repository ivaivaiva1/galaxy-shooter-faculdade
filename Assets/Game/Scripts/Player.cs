using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public int playerState;

    public float playerStatePosition;

    public Ease animEase;

    private bool doingTwen;

    public GameObject Shield;

    public bool isShield;

    private Renderer shieldRD;

    public bool isKillable = true;

    public GameObject coinTXT;

    public GameObject coin5TXT;


    public Transform playerCanvas;

    public GameObject MenuControllerOBJ;




    void Start()
    {
        MenuController.isRecord = false;
        shieldRD = Shield.GetComponent<SpriteRenderer>();
        isShield = true;
        playerState = 0;
        doingTwen = false;
    }


    void Update()
    {
        PlayerJumps();
    }


    private void PlayerJumps()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerState == 0 && doingTwen == false)
            {
                doingTwen = true;
                playerState = 1;
                transform.DOMove(new Vector2(1.2f, transform.position.y), GameController.playerSpeedStatic)
                .SetEase(animEase)
                .OnComplete(() =>
                {
                    doingTwen = false;
                });
            }
            else if (playerState == 1 && doingTwen == false)
            {
                doingTwen = true;
                playerState = 0;
                transform.DOMove(new Vector2(-1.2f, transform.position.y), GameController.playerSpeedStatic)
                .SetEase(animEase)
                .OnComplete(() =>
                {
                    doingTwen = false;
                });
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (isShield == true)
            {
                Destroy(other.gameObject);
                shieldRD.enabled = false;
                isShield = false;
                isKillable = false;
                StartCoroutine("doShield");
                StartCoroutine("doKillable");
            }
            else if (isShield == false && isKillable == true)
            {
                if (MenuController.isHard == true)
                {
                    if (PlayerPrefs.GetFloat("BestHard") < GameController.ScoreValue)
                    {
                        PlayerPrefs.SetFloat("BestHard", GameController.ScoreValue);
                        MenuController.isRecord = true;
                    }
                }
                else if (MenuController.isHard == false)
                {
                    if (PlayerPrefs.GetFloat("BestEasy") < GameController.ScoreValue)
                    {
                        PlayerPrefs.SetFloat("BestEasy", GameController.ScoreValue);
                        MenuController.isRecord = true;
                    }
                }
                PlayerPrefs.SetInt("HaveCoins", (PlayerPrefs.GetInt("HaveCoins") + GameController.runCoins));
                MenuControllerOBJ.GetComponent<MenuController>().EndGameMenu();
                GameController.isGame = false;
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }


        if (other.CompareTag("Coin"))
        {
            Instantiate(coinTXT, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity, playerCanvas);
            GameController.runCoins += 1;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin5"))
        {
            Instantiate(coin5TXT, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity, playerCanvas);
            GameController.runCoins += 5;
            Destroy(other.gameObject);
        }
    }


    IEnumerator doKillable()
    {
        yield return new WaitForSeconds(0.5f);
        isKillable = true;
    }


    IEnumerator doShield()
    {
        yield return new WaitForSeconds(GameController.shieldSpeed);
        shieldRD.enabled = true;
        isShield = true;
    }
}

