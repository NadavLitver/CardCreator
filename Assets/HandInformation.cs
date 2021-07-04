using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandInformation
{
    public int amountOfCards;
    public int[] CardIndexes;
    public HandInformation(int _amountOfCards, int[] _CardIndexes)
    {
        amountOfCards = _amountOfCards;
        CardIndexes = _CardIndexes;
    }
}
