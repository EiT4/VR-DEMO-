using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum Stat {
	ShoeDrop, // int
	ShoePronation, // inner/outer/none
	Price, // low/medium/high
	BackCushioning,
}

[Serializable]
public class ItemStat {
	[SerializeField] Stat stat;
	[SerializeField] int value;
}

[Serializable]
public class Item {
	[SerializeField] Texture image;
	[SerializeField] string name;
	//[SerializeField] ItemStat[] stats;
	[SerializeField] bool onSale;

	public Item(Texture image, string name, bool onSale) {
		this.image = image;
		this.name = name;
		//this.stats = stats;
		this.onSale = onSale;
	}
}

/*[Serializable]
public class Shoe: Item {
	[SerializeField] float drop;
	[SerializeField] float backCushioning;
}*/