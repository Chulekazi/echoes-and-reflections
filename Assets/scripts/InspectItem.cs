
using UnityEngine;
using UnityEngine.EventSystems;
public class InspectItem : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;

    public void OnDrag(PointerEventData eventData)
    {
        float rotationAmount = eventData.delta.x * rotationSpeed;
        transform.Rotate(Vector3.forward, -rotationAmount);
    }

    private void OnDisable()
    {
        transform.localRotation = Quaternion.identity;
    }
}

