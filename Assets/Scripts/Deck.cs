using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private List<Card> cardDataList;
    private int cardAmount;
   
    public Canvas fatherCanvas;

    public Hand playerHand;

    public List<GameObject> deckList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cardAmount = cardDataList.Count;
        for (int i = 0; i < cardAmount; i++)
        {
            GameObject curCard = Instantiate(cardPrefab, fatherCanvas.transform);
            SetDataOnCard dataSetter = curCard.GetComponent<SetDataOnCard>();
            dataSetter.SetCard(cardDataList[i]);
            dataSetter.Init();
            
            deckList.Add(curCard);
            cardPrefab.SetActive(false);
        }
        playerHand.LoadHand();
    }

    
}
