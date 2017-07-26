using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCheckScript : MonoBehaviour {

	public bool success;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Coin")) {
			if (success) {
				print ("Congraturations!");
			} else {
				print ("OMG...");
			}
			Destroy (other.gameObject);
		}
	}
}
