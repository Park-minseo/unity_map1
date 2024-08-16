/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 아이템 정보를 담는 클래스
[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public int quantity;

    public Item(string name, int id, int qty)
    {
        itemName = name;
        itemID = id;
        quantity = qty;
    }
}

// 아이템 박스, 여러 아이템을 관리하는 클래스
[System.Serializable]
public class ItemBox
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
    }
}

// 아이템을 관리하고 저장하는 매니저 클래스
public class ItemBoxManager : MonoBehaviour
{
    public ItemBox itemBox = new ItemBox();
    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/itembox.json";
        LoadItemBox(); // 게임 시작 시 기존 데이터를 불러옵니다.
    }

    public void SaveItemBox()
    {
        string json = JsonUtility.ToJson(itemBox, true);
        File.WriteAllText(filePath, json);
        Debug.Log("ItemBox saved to " + filePath);
    }

    public void LoadItemBox()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            itemBox = JsonUtility.FromJson<ItemBox>(json);
            Debug.Log("ItemBox loaded from " + filePath);
        }
        else
        {
            Debug.LogWarning("No saved ItemBox found at " + filePath);
        }
    }
}

// 아이템을 필드에서 주울 수 있게 하는 클래스
public class ItemCollector : MonoBehaviour
{
    public ItemBoxManager itemBoxManager;
    private ItemPickup nearbyItem;

    public void CollectItem()
    {
        if (nearbyItem != null)
        {
            // 아이템 획득
            Item newItem = new Item(nearbyItem.itemName, nearbyItem.itemID, nearbyItem.quantity);
            itemBoxManager.itemBox.AddItem(newItem);
            itemBoxManager.SaveItemBox();

            // 아이템 오브젝트를 제거합니다.
            Destroy(nearbyItem.gameObject);
            nearbyItem = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemPickup>())
        {
            nearbyItem = other.GetComponent<ItemPickup>();
            Debug.Log("Item is within range: " + nearbyItem.itemName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ItemPickup>())
        {
            if (nearbyItem == other.GetComponent<ItemPickup>())
            {
                nearbyItem = null;
                Debug.Log("Item is out of range");
            }
        }
    }
}

// 필드에 드롭된 아이템을 나타내는 클래스
public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public int quantity;
}
*/