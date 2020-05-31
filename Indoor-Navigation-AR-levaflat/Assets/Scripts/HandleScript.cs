using UnityEngine;

using UnityEngine.EventSystems;

public class HandleScript : MonoBehaviour

{
    public Camera map;
    // здесь будет ссылка на компонент Transform зеленой панели.


    private readonly float speed = 1f;
    private bool move = false;
    private Vector3 target;
    private Vector2 startPos;



    private void Update()
    {

        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = Camera.main.ScreenToWorldPoint(touch.position);
                    break;

                case TouchPhase.Moved:
                    var dir = Camera.main.ScreenToWorldPoint(touch.position);
                    dir.x -= startPos.x;
                    dir.z -= startPos.y;
                    dir.y = 0;
                    var pos = map.transform.position + dir;
                    map.transform.position = Vector3.Lerp(map.transform.position, pos, Time.deltaTime * speed);
                    break;
            }
        }

    }


}