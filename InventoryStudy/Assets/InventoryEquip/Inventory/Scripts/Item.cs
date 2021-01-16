/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit,
        ArmorNone,
        Armor_1,
        Armor_2,
        HelmetNone,
        Helmet,
        SwordNone,
        Sword_1,
        Sword_2
    }

    public ItemType itemType;
    public int amount = 1;

    
    public Sprite GetSprite() {
        return GetSprite(itemType);
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.Sword:        return ItemAssets.Instance.s_Sword;
        case ItemType.HealthPotion: return ItemAssets.Instance.s_HealthPotion;
        case ItemType.ManaPotion:   return ItemAssets.Instance.s_ManaPotion;
        case ItemType.Coin:         return ItemAssets.Instance.s_Coin;
        case ItemType.Medkit:       return ItemAssets.Instance.s_Medkit;

        case ItemType.ArmorNone:    return ItemAssets.Instance.s_ArmorNone;
        case ItemType.Armor_1:      return ItemAssets.Instance.s_Armor_1;
        case ItemType.Armor_2:      return ItemAssets.Instance.s_Armor_2;
        case ItemType.HelmetNone:   return ItemAssets.Instance.s_HelmetNone;
        case ItemType.Helmet:       return ItemAssets.Instance.s_Helmet;
        case ItemType.Sword_1:      return ItemAssets.Instance.s_Sword_1;
        case ItemType.Sword_2:      return ItemAssets.Instance.s_Sword_2;
        }
    }

    public Color GetColor() {
        return GetColor(itemType);
    }

    public static Color GetColor(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.Sword:        return new Color(1, 1, 1);
        case ItemType.HealthPotion: return new Color(1, 0, 0);
        case ItemType.ManaPotion:   return new Color(0, 0, 1);
        case ItemType.Coin:         return new Color(1, 1, 0);
        case ItemType.Medkit:       return new Color(1, 0, 1);
        }
    }

    public bool IsStackable() {
        return IsStackable(itemType);
    }

    public static bool IsStackable(ItemType itemType) {
        return false;
        /*
        switch (itemType) {
        default:
        case ItemType.Coin:
        case ItemType.HealthPotion:
        case ItemType.ManaPotion:
            return true;
        case ItemType.Sword:
        case ItemType.Medkit:
            return false;
        }
        */
    }

    public int GetCost() {
        return GetCost(itemType);
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.ArmorNone:        return 0;
        case ItemType.Armor_1:          return 30;
        case ItemType.Armor_2:          return 100;
        case ItemType.HelmetNone:       return 0;
        case ItemType.Helmet:           return 90;
        case ItemType.HealthPotion:     return 30;
        case ItemType.Sword_1:          return 0;
        case ItemType.Sword_2:          return 150;
        }
    }

    public override string ToString() {
        return itemType.ToString();
    }

    public CharacterEquipment.EquipSlot GetEquipSlot() {
        switch (itemType) {
        default:
        case ItemType.ArmorNone:
        case ItemType.Armor_1:
        case ItemType.Armor_2:
            return CharacterEquipment.EquipSlot.Armor;
        case ItemType.HelmetNone:
        case ItemType.Helmet:
            return CharacterEquipment.EquipSlot.Helmet;
        case ItemType.SwordNone:
        case ItemType.Sword:
        case ItemType.Sword_1:
        case ItemType.Sword_2:
            return CharacterEquipment.EquipSlot.Weapon;
        }
    }

}
