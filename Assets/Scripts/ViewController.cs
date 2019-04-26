using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ViewController : MonoBehaviour
{
    public TextMeshProUGUI moneyInfo, craftingInfo, eatablesInfo;
    private void OnEnable(){

        string moneyData = Inventory.GetInfo<Money>();
        this.moneyInfo.text =  moneyData == string.Empty ?  "No Data": moneyData;    

        string craftingData = Inventory.GetInfo<Crafting>();
        this.craftingInfo.text =  craftingData == string.Empty ?  "No Data": craftingData;    

        string eatablesData = Inventory.GetInfo<Eatables>();
        this.eatablesInfo.text =  eatablesData == string.Empty ?  "No Data": eatablesData;    

    }
    
    

    
}
