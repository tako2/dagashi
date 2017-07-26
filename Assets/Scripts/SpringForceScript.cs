using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForceScript : MonoBehaviour {

	private Rigidbody m_CoinRB;

	// Use this for initialization
	void Start () {
		m_CoinRB = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	private void DrawHelperAtCenter(
//		Vector3 direction, Color color, float scale)
//	{
//		Gizmos.color = color;
//		Vector3 destination = transform.position + direction * scale;
//		Gizmos.DrawLine(transform.position, destination);
//	}

//	void OnDrawGizmos()
//	{
//		DrawHelperAtCenter (transform.right, Color.red, 2f);
//	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Coin")) {
			//print ("Enter Coin");
			m_CoinRB = other.attachedRigidbody;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.attachedRigidbody == m_CoinRB) {
			//print ("Exit Coin");
			m_CoinRB = null;
		}
	}
	public void AddForceCoin(float force)
	{
		if (m_CoinRB != null) {
			print ("force " + force.ToString());
			//m_CoinRB.AddForce(transform.right * force, ForceMode.Impulse);
			force /= 50;
			m_CoinRB.AddForceAtPosition(transform.right * force, transform.position, ForceMode.Impulse);
		}
	}
}
