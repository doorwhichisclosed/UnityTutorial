﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;
    public InventorySlot[] inventorySlotArray;

    public Inventory(Action<Item> useItemAction, int inventorySlotCount) {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++) {
            inventorySlotArray[i] = new InventorySlot(i);
        }

        AddItem(new Item { itemType = Item.ItemType.Sword_1 });
        AddItem(new Item { itemType = Item.ItemType.Helmet });
        AddItem(new Item { itemType = Item.ItemType.Sword_2 });
        AddItem(new Item { itemType = Item.ItemType.Armor_1 });
        AddItem(new Item { itemType = Item.ItemType.Armor_2 });
    }

    public InventorySlot GetEmptyInventorySlot() {
        foreach (InventorySlot inventorySlot in inventorySlotArray) {
            if (inventorySlot.IsEmpty()) {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find an empty InventorySlot!");
        return null;
    }

    public InventorySlot GetInventorySlotWithItem(Item item) {
        foreach (InventorySlot inventorySlot in inventorySlotArray) {
            if (inventorySlot.GetItem() == item) {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find Item " + item + " in a InventorySlot!");
        return null;
    }

    public void AddItem(Item item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
                GetEmptyInventorySlot().SetItem(item);
            }
        } else {
            itemList.Add(item);
            GetEmptyInventorySlot().SetItem(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItemAmount(Item.ItemType itemType, int amount) {
        RemoveItem(new Item { itemType = itemType, amount = amount });
    }

    public void RemoveItem(Item item) {
        if (item.IsStackable()) {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                GetInventorySlotWithItem(itemInInventory).RemoveItem();
                itemList.Remove(itemInInventory);
            }
        } else {
            GetInventorySlotWithItem(item).RemoveItem();
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public void AddItem(Item item, InventorySlot inventorySlot) {
        RemoveItem(item);

        itemList.Add(item);
        inventorySlot.SetItem(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item) {
        useItemAction(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

    public InventorySlot[] GetInventorySlotArray() {
        return inventorySlotArray;
    }


    /*
     * Represents a single Inventory Slot
     * */
    public class InventorySlot {

        private int index;
        private Item item;

        public InventorySlot(int index) {
            this.index = index;
        }

        public Item GetItem() {
            return item;
        }

        public void SetItem(Item item) {
            this.item = item;
        }

        public void RemoveItem() {
            item = null;
        }

        public bool IsEmpty() {
            return item == null;
        }

    }

}
