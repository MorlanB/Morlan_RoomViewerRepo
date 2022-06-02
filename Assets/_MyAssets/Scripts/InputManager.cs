using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public GameObject spawnable;
    public UIManager uiManager;

    [HideInInspector] public bool inEditMode;
    [HideInInspector] public bool objHasSpawned = false;
    [HideInInspector] public bool inMoveMode;
    [HideInInspector] public bool inRotateMode;
    [HideInInspector] public GameObject obj;

    public GameObject selectedGO;

    void Update()
    {
        RaycastHit hit;

        #region Spawn and Move
        if (Input.touchCount > 0 && spawnable != null)
        {
            if (!IsPointerOverUIObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 pose = hit.point;

                    if (hit.transform.tag == "plane" && !objHasSpawned)
                    {
                        obj = Instantiate(spawnable, pose, spawnable.transform.rotation);
                        objHasSpawned = true;
                    }
                    else if (hit.transform.tag == "Furniture")
                    {
                        Debug.Log("Hit furniture");
                        selectedGO = hit.transform.gameObject;
                        inEditMode = true;
                        uiManager.showActsPanel = true;
                    }

                    if (inEditMode)
                    {
                        if (inMoveMode && hit.transform.tag == "plane")
                            selectedGO.transform.position = pose;
                    }
                }
            }
        }
        try
        {
            if (inEditMode)
                selectedGO.layer = LayerMask.NameToLayer("Ignore Raycast");
            else
                selectedGO.layer = LayerMask.NameToLayer("Default");
        } catch {}
        #endregion
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void DeleteSelectedObj()
    {
        Destroy(selectedGO);
        uiManager.showActsPanel = false;
        inEditMode = false;
    }

    public void HideEditMenu()
    {
        uiManager.showActsPanel = false;
        inEditMode = false;
        selectedGO.layer = LayerMask.NameToLayer("Default");
        selectedGO = null;
    }

    public void ShowRotArrows()
    {
        uiManager.showRotateArrows = inRotateMode;
    }
}