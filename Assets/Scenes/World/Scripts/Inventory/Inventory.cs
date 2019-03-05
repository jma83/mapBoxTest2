﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton <Inventory> {

    private List<Item> items = new List<Item>();
    private List<Equipment> equipment = new List<Equipment>();
    private Equipment e_selected;
    private int space = 26;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public delegate void OnEquipChanged();
    public OnEquipChanged onEquipChangedCallback;
    public bool modified = false;


    public bool AddItem(Item item)
    {
        if (space > items.Count)
        {

            items.Add(item); 
            modified = true;

            if (onItemChangedCallback != null)
            {
                Debug.Log("Inventory = onItemChangedCallback");
                onItemChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            Debug.Log("Your inventory is full!");
        }
        return false;
    }
    public bool AddEquipment(Equipment equip)
    {
        if (space > equipment.Count)
        {
            equipment.Add(equip);
            modified = true;

            if (onEquipChangedCallback != null)
            {
                Debug.Log("Inventory = onEquipChangedCallback");
                onEquipChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            Debug.Log("Your inventory is full!");
        }
        return false;
    }

    public bool SelectEquipment(Equipment equip)
    {
        if (equip != null)
        {
            modified = true;

            if (equip == e_selected) { e_selected = null;  return false; }

            e_selected = equip;

            if (e_selected == null)
            {
                Debug.Log("assign equipment 1st: " + equipment[0].name);
            }
            else
            {
                int index = equipment.IndexOf(equip);
                Equipment eq = equipment[index];
                equipment[index] = equipment[0];
                equipment[0] = eq;

                Debug.Log("equipment 1st: " + equipment[0].name);
            }


            if (onEquipChangedCallback != null)
            {
                Debug.Log("Inventory = onEquipChangedCallback");
                onEquipChangedCallback.Invoke();
            }

            return true;
        }

        Debug.Log("equip is null");

        return false;
    }

    public bool SelectEquipmentID(int equip_id)
    {
        if (equip_id >= 0)
        {
            modified = true;

            if (equip_id == e_selected.GetID()) { e_selected = null; return false; }

            for (int j = 0; j < equipment.Count; j++)
            {
                if (equipment[j].GetID() == equip_id)
                {
                    e_selected = equipment[j];
                    break;
                }
            }

            if (e_selected == null)
            {
                Debug.Log("assign equipment 1st: " + equipment[0].name);
            }
            else
            {
                int index = equipment.IndexOf(e_selected);
                Equipment eq = equipment[index];
                equipment[index] = equipment[0];
                equipment[0] = eq;

                Debug.Log("equipment 1st: " + equipment[0].name);
            }


            if (onEquipChangedCallback != null)
            {
                Debug.Log("Inventory = onEquipChangedCallback");
                onEquipChangedCallback.Invoke();
            }

            return true;
        }

        Debug.Log("equip is null");

        return false;
    }

    public void RemoveItem(Item item)
    {
        modified = true;
        items.Remove(item);
    }

    public void RemoveEquip(Equipment eq)
    {
        modified = true;
        equipment.Remove(eq);
    }

    public Equipment GetCurrentEquipment()
    {
        return e_selected;
    }

    public int GetCurrentEquipmentID()
    {
        if (e_selected != null)
            return e_selected.GetID();
        else
            return -1;
    }

    public void SetItems(List<Item> i)
    {
        items = i;
    }

    public void SetItem(Item i, int pos)
    {
        if (i != null && pos >= 0 && pos < items.Count)
            items[pos] = i;
        else
            AddItem(i);
    }

    public void SetEquip(Equipment e, int pos)
    {
        if (e != null && pos >= 0 && pos < equipment.Count)
            equipment[pos] = e;
        else
            AddEquipment(e);
    }

    public void SetEquipments(List<Equipment> e)
    {
        equipment = e;
    }

    public void SetSpace(int s)
    {
        space = s;
    }

    public List<Item> getItems()
    {
        return items;
    }

    public List<Equipment> getEquipments()
    {
        return equipment;
    }
}
