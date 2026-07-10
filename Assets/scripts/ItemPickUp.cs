using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items items; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            InventoryManager.Instance.OpenInspectionWindow(items);

          
            Destroy(gameObject);
        }
    }
}