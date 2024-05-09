using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections.Concurrent;

public class InventorySystem : MonoBehaviour
{
    //public HealthSystem HealthSystem;
    public InventoryScriptable playerInventory;
    public InventoryScriptable shopInventory;
    public Inventory PlayerInventoryManager;
    public Inventory ShopInventoryManager;


    public bool consumableInteracted;
    public bool throwableInteracted;
    public GameObject bomb;
    public GameObject slowBomb;
    public GameObject dagger;
    public GameObject iceDagger;
    public Item consumableEquipedItem;
    public Item throwableEquipedItem;
    public Item selectedItem;
    public Item shopSelectedItem;


    public bool consinter;
    public bool thinter;

    public delegate void myFunciton();
    void Awake()
    {
        shopSelectedItem = playerInventory.nullitem;
        selectedItem = playerInventory.nullitem;
    }
    private void Start()
    {
    }
    private void Update()
    {
        consumableInteracted = Input.GetKeyDown(KeyCode.C);
        throwableInteracted = Input.GetKeyDown(KeyCode.T);

        consumableEquipedItem = PlayerInventoryManager.GetConsumableEquipedItem();
        throwableEquipedItem = PlayerInventoryManager.GetThrowableEquipedItem();
        shopSelectedItem = ShopInventoryManager.GetSelectedItem();
        selectedItem = PlayerInventoryManager.GetSelectedItem();
        if (consumableEquipedItem != playerInventory.nullitem && !consumableEquipedItem.inDelay)
        {
            if (consumableInteracted) { 
                RemovePlayerItem(Consume(consumableEquipedItem), 0);
            }
        }
        if (throwableEquipedItem != playerInventory.nullitem && !throwableEquipedItem.inDelay)
        {
            if (throwableInteracted) { RemovePlayerItem(Throw(throwableEquipedItem), 1); }
        }
        consumableInteracted = false;
        throwableInteracted = false;
    }
    public void RemovePlayerItem(bool result, int type)
    {
        //0 consumable 1 throwable
        if (result)
        {
            if (type == 0)
            {
                playerInventory.RemoveItem(consumableEquipedItem);
                if (consumableEquipedItem.stack == 0) { PlayerInventoryManager.WhenRemoved(0); }
            }
            else
            {
                playerInventory.RemoveItem(throwableEquipedItem);
                if (throwableEquipedItem.stack == 0) { PlayerInventoryManager.WhenRemoved(1); }
            }
        }
    }
    public bool Consume(Item _equipedItem)
    {

        switch (_equipedItem.id)
        {
            case 1:
                return Apple(_equipedItem);
            case 2:
                return Broccoli(_equipedItem);
            case 3:
                return SpringWater(_equipedItem);
            case 4:
                return EnergyDrink(_equipedItem);
            case 5:
                return Spinach(_equipedItem);

            default: break;
        }
        return false;
    }
    public void PermanentConsume(Item _shopSelectedItem)
    {
        switch (_shopSelectedItem.id)
        {
            case 13:
                HpBoost(_shopSelectedItem);
                break;
            case 14:
                ManaBoost(_shopSelectedItem);
                break;
            case 15:
                AbilityPowerBoost(_shopSelectedItem);
                break;

            default: break;
        }
        playerInventory.RemoveItem(_shopSelectedItem);
    }
    public bool Throw(Item _equipedItem)
    {
        switch (_equipedItem.id)
        {
            case 6:
                return Bomb(_equipedItem);
            case 7:
                return SlowBomb(_equipedItem);
            case 8:
                return Dagger(_equipedItem);
            case 9:
                return IceDagger(_equipedItem);

            default: break;
        }
        return false;
    }
    public bool Apple(Item _equipedItem)
    {
        //Functions
        return true;
    }
    public bool Broccoli(Item _equipedItem)
    {
        //Functions
        return true;

    }
    public bool SpringWater(Item _equipedItem)
    {
        //Functions
        return true;
    }
    public bool EnergyDrink(Item _equipedItem)
    {
        //Functions
        return true;
    }
    public bool Spinach(Item _equipedItem)
    {
        //Functions
        return true;
    }

    public bool Bomb(Item _selectedItem)
    {
        //Functions
        return true;
    }
    public bool SlowBomb(Item _selectedItem)
    {
        //Functions
        return true;
    }
    public bool Dagger(Item _selectedItem)
    {
        //Functions
        return true;
    }
    public bool IceDagger(Item _selectedItem)
    {
        //Functions
        return true;
    }

    public void HpBoost(Item _selectedItem)
    {
        //Functions
    }
    public void ManaBoost(Item _selectedItem)
    {
        //Functions
    }
    public void AbilityPowerBoost(Item _selectedItem)
    {
        //Functions
    }
    public void Buy()
    {
        if (playerInventory.CanBuy(shopSelectedItem))
        {
            playerInventory.AddItem(shopSelectedItem);
            shopSelectedItem.shopStack--;
            if (shopSelectedItem.type == "permanent")
            {
                PermanentConsume(shopSelectedItem);
            }
            playerInventory.ArrangeItems();
        }
    }
  
}

