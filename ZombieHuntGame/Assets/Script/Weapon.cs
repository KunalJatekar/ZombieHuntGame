using System;
using Newtonsoft.Json;

public class Weapon
{
    public string weaponController;

    [JsonConstructor]   //this is main line for contructer
    public Weapon(string _weaponName)   //Contructor
    {
        weaponController = _weaponName; 
    }
}


