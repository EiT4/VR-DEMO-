using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddChoices : MonoBehaviour {

	public TextAsset textFile;
	public GameObject buttonPrefab;

	public GameObject[] choiceObjects;

	void Start () {
		string[] lines = textFile.text.Split (new string[] { "\n" }, System.StringSplitOptions.None);

		choiceObjects = new GameObject[lines.Length];
		for(int i = 0; i < lines.Length; i++) {
			string line = lines [i];

			// If line starts with //, it means this is what the customer says in the video belonging to these answers
			if (line.StartsWith ("//") || string.IsNullOrEmpty(line)) continue;

            string[] components = line.Split(new string[] { ";" }, System.StringSplitOptions.None);
            string conversation = components[0];
            string id = components[1];
			int score = int.Parse(components [2]);
            
			GameObject button = Instantiate (buttonPrefab);
			choiceObjects [i] = button;

			button.transform.SetParent (transform, false);
			button.GetComponentInChildren<Text> ().text = conversation;
			button.GetComponentInChildren<Text> ().fontSize = 80;
            button.GetComponent<Button>().onClick.AddListener(delegate { this.ClickChoice(id, score); });
		}

        gameObject.SetActive(false);
	}

	public void ClickChoice(string choiceId, int points) {
		// Add score
		GameManager.Instance.AddScore(points);

		if (choiceId.Equals ("0")) {
			// End conversation in some way
			return;
		} else if (choiceId.Equals ("1")) {
			// Pause video, make person choose shoes.
			return;
		}

        GameManager.Instance.DebugWrite("Du valgte: " + choiceId);
        GameManager.Instance.SetActiveVideo(choiceId);
    }
}
