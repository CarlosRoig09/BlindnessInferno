using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomMethods 
{
    public static int ReturnARandomObject(RandomSO[] SO, float dropNothingChane)
    {
        float minRange = 0;
        var random = Random.Range(minRange, SO.Length * 10 + dropNothingChane);
        for (var i = 0; i < SO.Length; i++)
        {
            Debug.Log(random);
            if (random >= minRange && random <= SO[i].RateAperance / SO.Length * (i + 1))
            {
                return i;
            }
            else
                minRange = SO[i].RateAperance / SO.Length;
        }
        return -1;
    }
}
