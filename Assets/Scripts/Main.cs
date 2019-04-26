using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory{
    public static List<string> moneyType = new List<string>() { "Gold", "Silver"};
    public static List<string> craftsType = new List<string>() { "Wood", "Ores", "Fur", "Dye" };
    public static List<string> eatablesType = new List<string>() { "Food", "Candy", "Drink" };

    public static string GetInfo<T>(){
        return GameObject.FindObjectOfType<Main>().GetInfo<T>();
    }

}
public abstract class Pouch

{
    protected Pouch pouch;
    protected Dictionary<string, int> itemList;
    public Pouch SetSuccessor(Pouch mainPouch)
    {
        this.pouch = mainPouch;
        return mainPouch;
    }

    public string GetInfo(){
        string toReturn = "";
        
        foreach(string key in this.itemList.Keys.ToList()){
            toReturn += "  "+ key + ": " + this.itemList[key];
        }

        return toReturn;
    }
    public abstract void AddToPouch(string purchase);
}

/// <summary>

/// The 'ConcreteHandler' class

/// </summary>

class Eatables : Pouch
{
    public Eatables(){
        this.itemList = new Dictionary<string, int>();
    }
    public override void AddToPouch(string purchase)
    {
        if(Inventory.eatablesType.Contains(purchase)){
            
            if(this.itemList.Keys.ToList<string>().Contains(purchase))
                this.itemList[purchase]++;
            else
                this.itemList[purchase] = 1;
        }else{

            this.pouch.AddToPouch(purchase);
        }
    }
}

class Crafting : Pouch
{
    public Crafting(){
        this.itemList = new Dictionary<string, int>();
    }

    public override void AddToPouch(string purchase)
    {
        if(Inventory.craftsType.Contains(purchase)){
            
            if(this.itemList.Keys.ToList<string>().Contains(purchase))
                this.itemList[purchase]++;
            else
                this.itemList[purchase] = 1;
        }else{
            this.pouch.AddToPouch(purchase);
        }
    }
    
}

class Money : Pouch

{

    public Money(){
        this.itemList = new Dictionary<string, int>();
    }
    public override void AddToPouch(string purchase)
    {
        if(Inventory.moneyType.Contains(purchase)){
            
            if(this.itemList.Keys.ToList<string>().Contains(purchase))
                this.itemList[purchase]++;
            else
                this.itemList[purchase] = 1;
        }else{
            
            this.pouch.AddToPouch(purchase);
        }
    }


   
}





public class Main : MonoBehaviour
{
   public Button addItemToInventory;
   UIController uiController;
   Money money;
   Crafting crafting;
   Eatables eatables;
   void Awake(){

       this.uiController = Camera.main.GetComponent<UIController>();
       
       addItemToInventory.onClick.AddListener(()=>{

            string itemToAdd = this.uiController.CurrentSelectedItem;
            this.money.AddToPouch(itemToAdd);
        });

        //Setting up Chain of Responsibility....
         this.money = new Money();
         this.crafting = new Crafting();
         this.eatables = new Eatables();
       
         money.SetSuccessor(crafting).SetSuccessor(eatables);




    }

    public string GetInfo<T>(){
        switch(typeof(T).ToString()){
            case "Money":
                return this.money.GetInfo();
            
            case "Crafting":
                return this.crafting.GetInfo();
            
            case "Eatables":
                return this.eatables.GetInfo();
        }

        return string.Empty;
    }
}
