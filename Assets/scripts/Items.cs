using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
  public string itemName;
    [TextArea(3, 5)] public string itemDescription;
    public Sprite itemIcon;
    public Sprite visual2DPrefab; 
}

