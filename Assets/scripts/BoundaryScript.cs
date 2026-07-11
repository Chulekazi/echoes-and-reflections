using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BoundaryScript : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/ 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/ 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.y * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.x * -1 - objectHeight);
        transform.position = viewPos;
    }
}
