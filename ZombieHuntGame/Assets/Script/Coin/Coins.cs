using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Coins
{
    public int coinreader;

    [JsonConstructor]

    public Coins(int _coinCount)   
    {
        coinreader = _coinCount;
    }
}
