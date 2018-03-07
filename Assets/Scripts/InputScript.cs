using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {

	public Transform cameraParent;
	public GameObject objectHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (cameraParent.position, Camera.main.transform.forward, Color.green);

		if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
			if (objectHit != null) {
				TalkScript talk = objectHit.GetComponent<TalkScript> ();
				if (talk != null) {
					talk.Talk ();
				}
				
			} else {
				Vector3 moveVector = transform.position + Camera.main.transform.forward * 2 * Time.deltaTime;
				transform.position = new Vector3 (moveVector.x, transform.position.y, moveVector.z);
			}
		}
	}

	void FixedUpdate() {
		RaycastHit hit;

		if (Physics.Raycast (cameraParent.position, Camera.main.transform.forward, out hit, 2f)) {
			objectHit = hit.transform.gameObject;
		} else {
			objectHit = null;
		}
	}
}
