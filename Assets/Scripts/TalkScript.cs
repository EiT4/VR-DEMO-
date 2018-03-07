using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour {

	int currentIndex = -1;
	string[] texts = new string[2];

	public GameObject speechBubble;
	public TextMesh textObject;

	// Use this for initialization
	void Start () {
		speechBubble.SetActive (false);
		speechBubble.transform.localScale = new Vector3 (0f, 0f, 0f);

		texts [0] = "Hei og velkommen!\nMitt navn er Dennis!";
		texts [1] = "Jeg er ansvarlig for\nsykkelavdelingen";
	}

	public void Talk() {
		StartCoroutine (Enlarge ());
		speechBubble.SetActive (true);

		if ((currentIndex + 1) < texts.Length) {
			currentIndex += 1;
			textObject.text = texts [currentIndex];
		}
	}

	IEnumerator Enlarge() {
		while (true) {
			speechBubble.transform.localScale = Vector3.Lerp (speechBubble.transform.localScale, new Vector3 (1, 1, 1), Time.deltaTime);
			yield return new WaitForFixedUpdate ();
		}
	}
}
