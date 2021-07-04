using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SetDataOnCard : MonoBehaviour {
	[HideInInspector]
	public Card cardData;

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI descriptionText;
	public Image artworkImage;
	public TextMeshProUGUI manaText;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI healthText;

	// Use this for initialization
	public void Init () {
		
			Debug.Log("Card Initilized");
			nameText.text = cardData.name;
			descriptionText.text = cardData.description;
			artworkImage.sprite = cardData.artwork;
			manaText.text += cardData.manaCost.ToString();
			damageText.text += cardData.attack.ToString();
			healthText.text += cardData.health.ToString();
		
	
	}
	
	public void SetCard(Card CardData)
    {
		cardData = CardData;
    }
}