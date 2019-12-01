using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveData : MonoBehaviour {

    void SaveCoins(int coinsCount)
    {
        Coins coin = new Coins(coinsCount);
        string json = JsonConvert.SerializeObject(coin);
        string path = Path.Combine(Application.dataPath, "JSON/Collectable.json");
        if(File.Exists(path))
        {
            File.WriteAllText(path, json);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        SaveCoins(Collectable.count);
    }

    public void OnApplicationQuit()
    {
        SaveCoins(Collectable.count);
    }

}
