using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
   
    public List<GameObject> itemsInHand; 
    public Transform start;  
    public Transform HandDeck; 
    [Range(0,7)]
    public int amountToDraw;
    public Deck deck;
   
    public void FitCards()
    {
        var cardsInHand = itemsInHand.Count;
      
        for (int i = 0; i < cardsInHand; i++)
        {
           var curCard = itemsInHand[i];
         
            curCard.transform.SetParent(this.transform);
            curCard.SetActive(true);
           // Deck.deckList.Remove(curCard);

        }

        SaveHand();
    }
    void SaveHand()
    {
        int[] indexesInDeckList = new int[itemsInHand.Count];
        for (int i = 0; i < itemsInHand.Count; i++)
        {
            
            GameObject curGameObject = itemsInHand[i];
            Debug.Log(deck.deckList.IndexOf(curGameObject));
            indexesInDeckList[i] = deck.deckList.IndexOf(curGameObject);
        }
        SaveSystem.SaveCards(itemsInHand.Count, indexesInDeckList);
    }
    public void LoadHand()
    {
        if(SaveSystem.LoadHand() != null)
        {
            HandInformation handInformation = SaveSystem.LoadHand();
            for (int i = 0; i < handInformation.amountOfCards; i++)
            {
                itemsInHand.Add(deck.deckList[handInformation.CardIndexes[i]]);
            }
        }
       
        FitCards();
    }
    public void DrawCards()
    {
        int _amountToDraw = amountToDraw;
        if (deck.deckList.Count < _amountToDraw)
        {
            _amountToDraw = deck.deckList.Count;

        }
        Debug.Log("Deck Count" + deck.deckList.Count);
       
        for (int i = 0; i < _amountToDraw; i++)
        {
            int rand = Randomizer.ReturnRandomNum(deck.deckList.Count);
            bool alreadyExist = itemsInHand.Contains(deck.deckList[rand]);
            if (itemsInHand.Count >= 7)
            {
                RemoveCard();
                DrawCards();
                break;

            }
            if (alreadyExist)
            {
              
                _amountToDraw++;
                

            }
            else
            {
                itemsInHand.Add(deck.deckList[rand]);

            }




        }
       
        FitCards();
    }
    public void RemoveCard()
    {
        int _amountToDraw = amountToDraw;
        GameObject[] indexesToRemove = new GameObject[_amountToDraw];
        for (int i = 0; i < _amountToDraw; i++)
        {
            itemsInHand[i].SetActive(false);
            itemsInHand[i].transform.parent = deck.fatherCanvas.transform;





        }
        itemsInHand.RemoveRange(0, _amountToDraw);
    }
}
