using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Gamemanager gameManager;
    public Transform worldItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<Gamemanager>();

        worldItems = GameObject.Find("WorldItems").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem("Test item");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem("Test item");
        }
        */
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        FindAnyObjectByType<InventoryUI>().RefreshUI();
    }
    public void RemoveItem(Item item) 
    {
        items.Remove(item);
    }

    public void RemoveItem()
    {
        if (gameManager.currentstate == Gamestate.Gameplay && items.Count > 0)
        {
            Item itemToDrop = items[0];

            Vector3 dropPosition = transform.position + transform.forward + new Vector3(0, .5f, 0);
            Quaternion dropRotation = transform.rotation;

            GameObject newItem = Instantiate(itemToDrop.gameObject, dropPosition, dropRotation, worldItems);

            newItem.SetActive(true);

            items.RemoveAt(0);

            FindAnyObjectByType<InventoryUI>().RefreshUI();

            Destroy(itemToDrop.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item item = hit.gameObject.GetComponent<Item>();

        if (item != null)
        {
            AddItem(item);
            
            item.gameObject.SetActive(false);
        }
    }

    
}
