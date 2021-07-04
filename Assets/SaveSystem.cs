using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveCards(int amountOfCards,int[] CardIndexes)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Hand.ndv";
        FileStream fileStream = new FileStream(path,FileMode.Create);

        HandInformation hand = new HandInformation(amountOfCards, CardIndexes);
        binaryFormatter.Serialize(fileStream, hand);
        fileStream.Close();
    }
    public static HandInformation LoadHand()
    {
        string path = Application.persistentDataPath + "/Hand.ndv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            HandInformation hand =  formatter.Deserialize(fileStream) as HandInformation;
            fileStream.Close();
            return hand;

        }
        else
        {
            Debug.Log("No Save File");
            return null;
        }
       /* HandInformation hand = new HandInformation(amountOfCards, CardIndexes);
        return hand;*/
    }
}
