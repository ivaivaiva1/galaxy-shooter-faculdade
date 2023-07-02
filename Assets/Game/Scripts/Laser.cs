using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2(0f, 10f) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("laserDestroy"))
		{
			Destroy (this.gameObject);
		}
	}
}
