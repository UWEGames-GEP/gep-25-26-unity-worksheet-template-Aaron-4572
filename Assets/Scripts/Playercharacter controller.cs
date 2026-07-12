using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerCharacterController : ThirdPersonController
{
    public void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            FindAnyObjectByType<Gamemanager>().TogglePause();        
        }
    }

    public void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            GetComponent<Inventory>().RemoveItem();       
        }
            
    }

    public void OnInventory(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            FindAnyObjectByType<InventoryUI>().ToggleInventory();
        }
    }
}
