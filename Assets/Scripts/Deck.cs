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
    [SerializeField]
    private Canvas fatherCanvas;
    // Start is called before the first frame update
    void Start()
    {
        cardAmount = cardDataList.Count;
        for (int i = 0; i < cardAmount; i++)
        {
            Instantiate(cardPrefab, fatherCanvas.transform);
            var dataSetter = cardPrefab.GetComponent<SetDataOnCard>();
            dataSetter.GetCard(cardDataList[i]);
            dataSetter.Init();
            cardPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
