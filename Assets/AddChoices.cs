using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddChoices : MonoBehaviour {

	public TextAsset textFile;
	public GameObject buttonPrefab;

	// Use this for initialization
	void Start () {
        Debug.Log(textFile.text);
		string[] lines = textFile.text.Split (new string[] { "\n" }, System.StringSplitOptions.None);

		foreach (string line in lines) {
            string[] components = line.Split(new string[] { ";" }, System.StringSplitOptions.None);
            string conversation = components[0];
            string id = components[1];
            
			GameObject button = Instantiate (buttonPrefab);

			button.transform.SetParent (transform, false);
			button.GetComponentInChildren<Text> ().text = conversation;
			button.GetComponentInChildren<Text> ().fontSize = 80;
            button.GetComponent<Button>().onClick.AddListener(delegate { this.ClickChoice(id); });
		}

        gameObject.SetActive(false);
	}

    public void ClickChoice(string choiceId) {
        if(choiceId.Equals("0"))
        {
            return;
        }

        GameManager.Instance.Debug("Du valgte: " + choiceId);
        GameManager.Instance.SetActiveVideo(choiceId);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
