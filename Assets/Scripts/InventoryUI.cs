using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Button itemButtonPrefab;
    public Transform buttonParent;

    public GameObject inventoryPanel;
    
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void RefreshUI()
    {
        foreach (Transform child in buttonParent)
        {
            if (child.gameObject != itemButtonPrefab.gameObject && child.GetComponent<Button>() != null)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Item item in inventory.items)
        {
            Button newButton = Instantiate(itemButtonPrefab, buttonParent);
            newButton.gameObject.SetActive(true);

            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = item.itemName;
        }
    }
}
