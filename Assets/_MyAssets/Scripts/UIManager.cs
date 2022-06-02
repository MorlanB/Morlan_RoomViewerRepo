using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private PointerEventData pData;
    private EventSystem eSystem;

    public GameObject actionsPanel;
    public GameObject arrowsPanel;

    public Transform selectionPoint;
    [HideInInspector] public bool showActsPanel;
    [HideInInspector] public bool showRotateArrows;

    public static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eSystem);

        pData.position = selectionPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (showActsPanel)
        {
            actionsPanel.SetActive(true);

            if (showRotateArrows)
                arrowsPanel.SetActive(true);
            else
                arrowsPanel.SetActive(false);
        }
        else
        {
            actionsPanel.SetActive(false);
            arrowsPanel.SetActive(false);
        }
    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        if (results != null)
        {
            raycaster.Raycast(pData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == button)
                    return true;
            }
        }
        return false;
    }
}
