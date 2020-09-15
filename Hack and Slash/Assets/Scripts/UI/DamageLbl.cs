using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLbl : MonoBehaviour
{
    public Unit unit;
    public Canvas Canvas;

    void Start()
    {
        Canvas = ActionManager.Manager.Canvas;
        Destroy(gameObject, 0.2f);
        gameObject.transform.SetParent(Canvas.transform);
    }

    void Update()
    {
        // Offset position above object bbox (in world space)
        float offsetPosY = unit.transform.position.y + 3.2f;

        // Final position of marker above GO in world space
        Vector3 offsetPos = new Vector3(unit.transform.position.x, offsetPosY, unit.transform.position.z);

        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        var canvasRect = Canvas.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        // Set
        gameObject.transform.localPosition = canvasPos;
    }

    public void MoveUp()
    {
        this.transform.position = new Vector2(transform.position.x, transform.position.y + 10);
    }
}
