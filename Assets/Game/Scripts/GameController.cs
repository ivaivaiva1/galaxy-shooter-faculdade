using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private Renderer _renderGalaxy;
    public GameObject GalaxyObject;

    public float galaxySpeed;
    public float inscreaseRate;
    public float increaseScore;
    public static float ScoreValue;

    public static float playerSpeedStatic;

    public static int runCoins;




    //Balancing
    public static float enemySpeedStatic;

    public float enemySpeed;

    public static bool isGame;

    public float playerSpeed;

    public float percentBalancing;

    public float finalPlayerSpeed;

    public float initialPlayerSpeed;

    public float finalEnemy;

    public float initialEnemy;

    public static float shieldSpeed;

    public float finalShield;

    public float initialShield;

    public float finalScore;

    public float initialCoin5Chance;

    public float finalCoin5Chance;

    public float coin5Chance;

    public float initialspawnTime;

    public float finalspawnTime;

    public float spawnTime;

    public float initialGalaxySpeed;

    public float finalGalaxySpeed;


    [SerializeField]
    private TextMeshProUGUI scoreText;

    //Spawn Enemy Variables
    public Transform[] spawnLocations;
    public GameObject enemyOBJ;
    public GameObject coinOBJ;
    public GameObject coin5OBJ;
    private int whereSpawn;


    // Start is called before the first frame update
    void Start()
    {
        SetDifficult();
        runCoins = 0;
        isGame = true;
        ScoreValue = 0f;
        _renderGalaxy = GalaxyObject.GetComponent<Renderer>();
        StartCoroutine("StartGame");
    }

    private void SetDifficult()
    {
        if(MenuController.isHard == true)
        {
           finalScore = 1100f;
           finalPlayerSpeed = 0.15f;
           initialPlayerSpeed = 0.4f;
           finalEnemy = 15f;
           initialEnemy = 7.5f;
           finalShield = 3f;
           initialShield = 8f;
           finalspawnTime = 0.45f;
           initialspawnTime = 0.45f;
        } else if(MenuController.isHard == false)
        {
           finalScore = 6000f;
           finalPlayerSpeed = 0.15f;
           initialPlayerSpeed = 0.6f;
           finalEnemy = 15f;
           initialEnemy = 5f;
           finalShield = 3f;
           initialShield = 5f;
           finalspawnTime = 0.45f;
           initialspawnTime = 0.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameSpeed();
        enemySpeedStatic = enemySpeed;
        playerSpeedStatic = playerSpeed;
        //1100 is max score
        percentBalancing = ScoreValue / finalScore;
        playerSpeed = Mathf.Lerp(initialPlayerSpeed, finalPlayerSpeed, percentBalancing);
        enemySpeed = Mathf.Lerp(initialEnemy, finalEnemy, percentBalancing);
        shieldSpeed = Mathf.Lerp(initialShield, finalShield, percentBalancing);
        coin5Chance = Mathf.Lerp(initialCoin5Chance, finalCoin5Chance, percentBalancing);
        spawnTime = Mathf.Lerp(initialspawnTime, finalspawnTime, percentBalancing);
        galaxySpeed = Mathf.Lerp(initialGalaxySpeed, finalGalaxySpeed, percentBalancing);
        //spawnCoin = Random.Range(0f, 1f);
        //whereSpawn = Random.Range(0,2);
    }

    private void GameSpeed()
    {
        if (isGame == true)
        {
            if (increaseScore <= 15f)
            {
                increaseScore = increaseScore + inscreaseRate * Time.deltaTime;
            }
            ScoreValue = ScoreValue + increaseScore * Time.deltaTime;
            scoreText.text = ScoreValue.ToString("#");
        }
        if(ScoreValue < finalScore)
        {
           _renderGalaxy.material.SetVector("_Scroll", new Vector4(0f, galaxySpeed, 0f, 0.01f));
        }
    }

    IEnumerator StartGame()
    {
        while (isGame == true)
        {
            yield return new WaitForSeconds(spawnTime + Random.Range(spawnTime / 8, spawnTime / 3));
            float spawnCoin = Random.Range(0f, 1f);
            if (spawnCoin <= 0.1f)
            {
                float spawnCoin5 = Random.Range(0f, 1f);
                if (spawnCoin5 <= coin5Chance)
                {
                    Instantiate(coin5OBJ, spawnLocations[Random.Range(0, 2)].position, Quaternion.identity);
                }
                else
                    Instantiate(coinOBJ, spawnLocations[Random.Range(0, 2)].position, Quaternion.identity);
            }
            else
                Instantiate(enemyOBJ, spawnLocations[Random.Range(0, 2)].position, Quaternion.identity);
        }
    }

}
