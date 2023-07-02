using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour
{

    public static bool isHard;

    public float scoreTime;

    public GameObject ScoreTXT;

    public GameObject ScoreModel;

    public GameObject BestScore;

    public GameObject Coins;

    public GameObject playBTN;

    public GameObject menuBTN;

    public GameObject menuPauseBTN;

    public GameObject pauseBTN;

    public GameObject GameLogo;

    public Ease animEase;

    public GameObject newRecordOBJ;

    public Color recordColorBase;

    public TextMeshProUGUI newRecordTXT;

    public TextMeshProUGUI CoinsTXT;

    public TextMeshProUGUI bestScore;

    public TextMeshProUGUI bestHardTXT;

    public TextMeshProUGUI bestEasyTXT;

    public TextMeshProUGUI menuCoinsTXT;

    public GameObject countGo;

    public TextMeshProUGUI countGoTXT;

    public static bool isRecord;

    void Start()
    {
        if (bestHardTXT != null)
        {
            bestHardTXT.text = ("Best Score: ") + PlayerPrefs.GetFloat("BestHard").ToString("#");
            bestEasyTXT.text = ("Best Score: ") + PlayerPrefs.GetFloat("BestEasy").ToString("#");
            menuCoinsTXT.text = ("Coins ") + PlayerPrefs.GetInt("HaveCoins").ToString();
        }
    }

    public void EndGameMenu()
    {
        CoinsTXT.text = ("Coins: ") + GameController.runCoins.ToString();
        if (isHard == true)
        {
            bestScore.text = ("Best Score: ") + PlayerPrefs.GetFloat("BestHard").ToString("#");
        }
        else if (isHard == false)
        {
            bestScore.text = ("Best Score: ") + PlayerPrefs.GetFloat("BestEasy").ToString("#");
        }
        StartCoroutine("doMenus");
    }

    public void PlayGameHard()
    {
        isHard = true;
        SceneManager.LoadScene("Game");
    }

    public void PlayGameEasy()
    {
        isHard = false;
        SceneManager.LoadScene("Game");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CallMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }


    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            menuPauseBTN.SetActive(false);
            StartCoroutine("Despause");
        }
        else
        if (Time.timeScale == 1)
        {
            menuPauseBTN.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator Despause()
    {
        // countGo.SetActive(true);
        // countGoTXT.text = ("3");
        // print("3");
        // yield return new WaitForSecondsRealtime(1f);
        // countGoTXT.text = ("2");
        // print("2");
        // yield return new WaitForSecondsRealtime(1f);
        // countGoTXT.text = ("1");
        // print("1");
        // yield return new WaitForSecondsRealtime(1f);
        // countGoTXT.text = ("GO!");
        // print("GO!");
        // yield return new WaitForSecondsRealtime(1f);
        // countGo.SetActive(false);
        // Time.timeScale = 1;
        // print("Play");
        countGo.SetActive(true);
        countGoTXT.text = ("READY?");
        yield return new WaitForSecondsRealtime(1f);
        countGoTXT.text = ("GO!");
        yield return new WaitForSecondsRealtime(1f);
        countGo.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator doMenus()
    {
        pauseBTN.SetActive(false);
        ScoreTXT.transform.DOMove(new Vector3(ScoreModel.transform.position.x, ScoreModel.transform.position.y), scoreTime)
        .SetEase(animEase);
        ScoreTXT.transform.DOScale(1.74f, scoreTime)
        .SetEase(animEase);
        yield return new WaitForSeconds(0.8f);
        if (isRecord == true)
        {
            newRecordOBJ.SetActive(true);
            recordColorBase = newRecordTXT.color;
            Sequence mySequenceColor = DOTween.Sequence();
            mySequenceColor
            .Append(newRecordTXT.DOColor(Color.white, 0.15f)
                .SetEase(Ease.Linear))
            .Append(newRecordTXT.DOColor(recordColorBase, 0.3f)
               .SetEase(Ease.Linear))
            .SetDelay(0.1f)
            .SetLoops(-1);
            Sequence mySequence = DOTween.Sequence();
            mySequence
                .Append(newRecordTXT.transform.DOScale(1f, 0.6f)
                  .SetEase(Ease.Linear))
                .Append(newRecordTXT.transform.DOScale(0.8f, 0.6f)
                 .SetEase(Ease.Linear))
                .SetLoops(-1);
        }
        yield return new WaitForSeconds(1.5f);
        BestScore.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Coins.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        playBTN.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        menuBTN.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        GameLogo.SetActive(true);
    }
}
