using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{


   
    public Toggle MoneyToggle, CraftToggle, EatableToggle;
    public Dropdown Items;

    public string CurrentSelectedItem {get{return Items.options[Items.value].text;}}
    void Awake(){
        
        MoneyToggle.onValueChanged.AddListener(ToggleChanged);
        CraftToggle.onValueChanged.AddListener(ToggleChanged);
        EatableToggle.onValueChanged.AddListener(ToggleChanged);
    }

    public void SetDropDown(){
        Toggle onToggle = MoneyToggle.group.ActiveToggles().ToList<Toggle>()[0];
        Items.ClearOptions();

        switch(onToggle.name){
            case "Money":
                Items.AddOptions(Inventory.moneyType);
                
            break;
            case "CraftingItems":
                Items.AddOptions(Inventory.craftsType);
            break;
            case "Eatables":
                Items.AddOptions(Inventory.eatablesType);
            break;
        }
    }

    void ToggleChanged(bool check){
        if(!check) return;
        this.SetDropDown();
        
    }

    
}

