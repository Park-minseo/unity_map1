using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public int itemID;          // 아이템 번호
    public string itemName;     // 아이템 이름
    public string description;  // 아이템 설명
    public int quantity;        // 아이템 수량

    public Item(int id, string name, string desc, int qty)
    {
        itemID = id;
        itemName = name;
        description = desc;
        quantity = qty;
    }
}

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory;  // List로 관리하는 인벤토리
    public int inventoryCapacity = 40;  // 초기 인벤토리 크기
    public int weaponLevel = 1;    // 무기의 초기 레벨

    void Start()
    {
        // 초기 인벤토리 공간을 설정
        inventory = new List<Item>(inventoryCapacity);
    }

    public void LevelUpWeapon()
    {
        weaponLevel++;
        ExpandInventory();
    }

    private void ExpandInventory()
    {
        inventoryCapacity = weaponLevel * 40; // 무기 레벨에 따라 인벤토리 크기 증가
        Debug.Log("Inventory expanded. New capacity: " + inventoryCapacity);
    }

    
    public bool AddItem(Item item)
    {
        // 이미 인벤토리에 존재하는 아이템인지 확인
        int index = inventory.FindIndex(i => i.itemID == item.itemID);

        if (index >= 0)
        {
            Item existingItem = inventory[index];
            existingItem.quantity += item.quantity;
            inventory[index] = existingItem;
            Debug.Log("Added quantity to existing item: " + item.itemName + " (Total: " + existingItem.quantity + ")");
            return true;
        }
        else
        {
            if (inventory.Count < inventoryCapacity)
            {
                inventory.Add(item);
                Debug.Log("Added new item: " + item.itemName);
                return true;
            }
            else
            {
                Debug.LogWarning("Inventory is full! Cannot add item: " + item.itemName);
                return false;
            }
        }
    }

    //제대로 들어갔는지 확일할 메소드
    public void PrintInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log("Item " + i + ": " + inventory[i].itemName + " (x" + inventory[i].quantity + ") - " + inventory[i].description);
        }
    }
}
