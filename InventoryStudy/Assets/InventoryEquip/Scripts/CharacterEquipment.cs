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

public class CharacterEquipment : MonoBehaviour {

    public event EventHandler OnEquipmentChanged;

    public enum EquipSlot {
        Helmet,
        Armor,
        Weapon
    }

    private Player player;

    private Item weaponItem;
    private Item helmetItem;
    private Item armorItem;

    private void Awake() {
        player = GetComponent<Player>();
    }

    public Item GetWeaponItem() {
        return weaponItem;
    }

    public Item GetHelmetItem() {
        return helmetItem;
    }

    public Item GetArmorItem() {
        return armorItem;
    }

    private void SetWeaponItem(Item weaponItem) {
        this.weaponItem = weaponItem;
        player.SetEquipment(weaponItem.itemType);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SetHelmetItem(Item helmetItem) {
        this.helmetItem = helmetItem;
        player.SetEquipment(helmetItem.itemType);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SetArmorItem(Item armorItem) {
        this.armorItem = armorItem;
        player.SetEquipment(armorItem.itemType);
        OnEquipmentChanged?.Invoke(this, EventArgs.Empty);
    }

    public void TryEquipItem(EquipSlot equipSlot, Item item) {
        if (equipSlot == item.GetEquipSlot()) {
            // Item matches this EquipSlot
            switch (equipSlot) {
            default:
            case EquipSlot.Armor:   SetArmorItem(item);     break;
            case EquipSlot.Helmet:  SetHelmetItem(item);    break;
            case EquipSlot.Weapon:  SetWeaponItem(item);    break;
            }
        }
    }

}
