using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUITest : MonoBehaviour
{
    //public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (!IsPointerOverUIObject())
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Didn't hit UI");

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //target.position = hit.point;
                }
            }
        }
        else if (IsPointerOverUIObject())
        {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Hit UI");

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //target.position = hit.point;
                }
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}