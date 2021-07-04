using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SetDataOnCard : MonoBehaviour {
	public Card cardData;
	[SerializeField]
	private TextMeshProUGUI nameText;
	[SerializeField]
	private TextMeshProUGUI descriptionText;
	[SerializeField]
	private Image artworkImage;
	[SerializeField]
	private TextMeshProUGUI manaText;
	[SerializeField]
	private TextMeshProUGUI damageText;
	[SerializeField]
	private TextMeshProUGUI healthText;

	// Use this for initialization
	public void Init () {
		
		nameText.text = cardData.name;
		descriptionText.text = cardData.description;
		artworkImage.sprite = cardData.artwork;
		manaText.text += cardData.manaCost.ToString();
		damageText.text += cardData.attack.ToString();
		healthText.text += cardData.health.ToString();
	}
	
	public void GetCard(Card CardData)
    {
		cardData = CardData;
    }
}