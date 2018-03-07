using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddChoices : MonoBehaviour {

	public TextAsset textFile;
	public GameObject buttonPrefab;

	// Use this for initialization
	void Start () {
		string[] lines = textFile.text.Split (new string[] { "\n" }, System.StringSplitOptions.None);

		foreach (string line in lines) {
			if (line.Length == 0)
				break;

			GameObject button = Instantiate (buttonPrefab);

			button.transform.SetParent (transform, false);
			button.GetComponentInChildren<Text> ().text = line;
			button.GetComponentInChildren<Text> ().fontSize = 80;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
