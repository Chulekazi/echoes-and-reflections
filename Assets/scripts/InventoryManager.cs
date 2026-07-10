using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Inventory Data")]
    public List<Items> items = new List<Items>();

    [Header("Inspection UI Panel")]
    public GameObject inspectPanel;
    public TextMeshProUGUI inspectNameText;
    public TextMeshProUGUI inspectDescriptionText;
    public Image inspectImage;

    private Items pendingItem; 

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        inspectPanel.SetActive(false); 
    }

    public void OpenInspectionWindow(Items item)
    {
        pendingItem = item;

        inspectNameText.text = item.itemName;
        inspectDescriptionText.text = item.itemDescription;
        inspectImage.sprite = item.itemIcon;

        inspectPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

   
    public void ClaimItem()
    {
        if (pendingItem != null)
        {
            items.Add(pendingItem);
            Debug.Log($"{pendingItem.itemName} added to inventory!");
        }

        CloseInspectionWindow();
    }

    public void CloseInspectionWindow()
    {
        pendingItem = null;
        inspectPanel.SetActive(false);
        Time.timeScale = 3f; 
    }

}
