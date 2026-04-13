using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * -GameController.enemySpeedStatic * Time.deltaTime, Space.World);
    }

}
