using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isEquippable;

    public virtual void Use()
    {
        Debug.Log("Using or Equipping: " + itemName);

        // Trigger the popup window instantly when clicked from the inventory
        if (pop_up.Instance != null)
        {
            pop_up.Instance.ShowPopup(this);
        }
    }
}