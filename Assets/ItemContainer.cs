using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour {
    [SerializeField] private Text description;
    [SerializeField] private Image image;
    [SerializeField] private Toggle toggle;

	public bool IsCorrect { get; private set; } 
    
    public void Initialize(string imagePath, string description, bool isSale, bool isCorrect)   
    {
		this.IsCorrect = isCorrect;
        int lineEndIndex = description.IndexOf('@');
        string parsedDescription = "<b>" + description.Substring(0, lineEndIndex) + "</b>" + description.Substring(lineEndIndex);
        this.description.text = parsedDescription.Replace('@', '\n');
        Sprite sprite = (Sprite)Resources.Load("Images/" + imagePath, typeof(Sprite));
        this.image.sprite = sprite;

        if (isSale) GetComponent<Image>().color = Color.green;
    }

    public void ToggleSelect(){
        toggle.isOn = !toggle.isOn;
    }
}
