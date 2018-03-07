using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPopulator : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GameObject itemContainerPrefab;
    [SerializeField] private Transform container;

	// Use this for initialization
	void Start () {
        string[] array = textAsset.text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        foreach (string line in array)
        {
            string[] components = line.Split(new string[] { ";" }, System.StringSplitOptions.None);
            GameObject itemContainer = Instantiate(itemContainerPrefab, container);


            bool isSale = components[2].Trim() == "1";
            bool isCorrect = components[3].Trim() == "1";

            itemContainer.GetComponent<ItemContainer>().Initialize(components[0], components[1], isSale, isCorrect);

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
