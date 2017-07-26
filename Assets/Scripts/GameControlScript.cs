using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {

	public GameObject coin;
	public GameObject[] spring = new GameObject[6];
	public GameObject[] spring_bar = new GameObject[6];

	private int m_KeyDown;
	private float m_KeyDownTime;
	private KeyCode[] m_SpringKey = new KeyCode[6] {
		KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
		KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6
	};

	private float m_BarAngle;

	// Use this for initialization
	void Start () {
		m_KeyDown = -1;
		m_KeyDownTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!GameObject.FindGameObjectWithTag ("Coin")) {
				var obj = Instantiate (coin, transform.position, transform.rotation);
				obj.transform.parent = transform;
				obj.GetComponent<Rigidbody> ().AddForce (transform.up * -50);
			}
		}

		if (m_KeyDown < 0) {
			for (int key = 0; key < 6; key++) {
				if (Input.GetKeyDown (m_SpringKey [key])) {
					m_KeyDown = key;
					m_KeyDownTime = 0;

					m_BarAngle = ((m_KeyDown & 1) == 0) ? 110 : -70;
					float y_angle = ((m_KeyDown & 1) == 0) ? 0 : 180;
					spring_bar [m_KeyDown].transform.rotation = Quaternion.Euler(new Vector3 (0, y_angle, m_BarAngle));
					break;
				}
			}
		} else if (Input.GetKeyUp (m_SpringKey [m_KeyDown])) {
			float force;
			if (m_KeyDownTime > 1) {
				m_KeyDownTime = 1;
			}
			force = m_KeyDownTime * 1000 + 400;
			var script = spring [m_KeyDown].GetComponent<SpringForceScript> ();
			script.AddForceCoin (force);
			float z_angle = ((m_KeyDown & 1) == 0) ? 90 : -90;
			float y_angle = ((m_KeyDown & 1) == 0) ? 0 : 180;
			spring_bar [m_KeyDown].transform.rotation = Quaternion.Euler(new Vector3 (0, y_angle, z_angle));
			m_KeyDown = -1;
		} else if (Input.GetKey(m_SpringKey[m_KeyDown])) {
			m_KeyDownTime += Time.deltaTime;
			if (m_KeyDownTime <= 1) {
				m_BarAngle = ((m_KeyDown & 1) == 0) ? (110 + (m_KeyDownTime * 70)) : ((1 - m_KeyDownTime) * -70);
				float y_angle = ((m_KeyDown & 1) == 0) ? 0 : 180;
				spring_bar [m_KeyDown].transform.rotation = Quaternion.Euler(new Vector3 (0, y_angle, m_BarAngle));
			}
		}
	}
}
