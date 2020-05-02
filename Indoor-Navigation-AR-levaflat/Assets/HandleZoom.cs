using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleZoom : MonoBehaviour
{
    public float sensitivity;

    Vector2 f0start;

    Vector2 f1start;
    private bool drag = false;
    // масштабируем

    // экранные координаты начальной точки касания
    private Vector3 initialTouchPosition;
    // мировые координаты камеры при инициировании
    // перемещения/масштабирования
    private Vector3 initialCameraPosition;
    void Update()

    {

        if (Input.touchCount == 0)

        {

            f0start = Vector2.zero;

            f1start = Vector2.zero;

        }
        if (Input.touchCount == 2) Zoom();
        if (Input.touchCount == 1) Swap();

    }

    void Swap()
    {
        Touch touch0 = Input.GetTouch(0);
        if (!drag)
        {
            initialTouchPosition = touch0.position;
            initialCameraPosition = transform.position;

            drag = true;
        }
        else
        {
            Vector2 delta = touch0.position;
            delta.x -= initialTouchPosition.x;
            delta.y -= initialTouchPosition.y;
            drag = false;
            Vector3 newPos = initialCameraPosition;
            newPos.x -= delta.x;
            newPos.z -= delta.y;
            transform.position =  Vector3.MoveTowards(transform.position, newPos, 10f * Time.deltaTime * Mathf.Sign(Vector2.Distance(new Vector2(initialTouchPosition.x, initialTouchPosition.y), delta)));
        }
    }
    void Zoom()

    {

        if (f0start == Vector2.zero && f1start == Vector2.zero)

        {

            f0start = Input.GetTouch(0).position;

            f1start = Input.GetTouch(1).position;

        }

        Vector2 f0position = Input.GetTouch(0).position;

        Vector2 f1position = Input.GetTouch(1).position;

        float dir = Mathf.Sign(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position));
        var target = transform.position + transform.forward;
        transform.position = Vector3.MoveTowards(transform.position, target, dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position));
    }
}
