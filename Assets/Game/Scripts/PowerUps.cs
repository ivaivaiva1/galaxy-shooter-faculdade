using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	[SerializeField]
	private float _fallSpeed;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector2(0f, _fallSpeed) * Time.deltaTime);
	}
}
