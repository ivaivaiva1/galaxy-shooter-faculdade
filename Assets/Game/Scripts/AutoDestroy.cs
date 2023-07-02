using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public float timetoDestroy;

    void Start()
    {
        Destroy(gameObject, timetoDestroy);
    }

}
