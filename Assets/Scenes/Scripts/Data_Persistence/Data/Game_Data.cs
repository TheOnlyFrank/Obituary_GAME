using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game_Data
{
    public long lastUpdated;
    public int deathCount;
    public Vector3 playerPosition;
    public Serializable_Dictionary<string, bool> coinsCollected;
    public Attributes_Data playerAttributesData;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public Game_Data() 
    {
        this.deathCount = 0;
        playerPosition = Vector3.zero;
        coinsCollected = new Serializable_Dictionary<string, bool>();
        playerAttributesData = new Attributes_Data();
    }

    public int GetPercentageComplete() 
    {
        // figure out how many coins we've collected
        int totalCollected = 0;
        foreach (bool collected in coinsCollected.Values) 
        {
            if (collected) 
            {
                totalCollected++;
            }
        }

        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (coinsCollected.Count != 0) 
        {
            percentageCompleted = (totalCollected * 100 / coinsCollected.Count);
        }
        return percentageCompleted;
    }
}
