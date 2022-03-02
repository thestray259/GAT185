using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;

    List<Item> inventory = new List<Item>(); 
    public Item activeItem { get; set; }

    void Start()
    {
        inventory.AddRange(items); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) StartItem(null);
        if (Input.GetKeyDown(KeyCode.Alpha2)) StartItem(inventory[0]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) StartItem(inventory[1]);

        activeItem?.UpdateItem();
    }

    void StartItem(Item item)
    {
        activeItem?.Deactivate();

        activeItem = item;
        activeItem?.Activate(); 
    }

    public void Fire()
    {
        if (activeItem.TryGetComponent<Weapon>(out Weapon weapon))
        {
            weapon.Fire();
        }
    }
}
