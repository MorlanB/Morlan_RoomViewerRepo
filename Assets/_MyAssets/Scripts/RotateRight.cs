using UnityEngine;
using UnityEngine.EventSystems;

public class RotateRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public InputManager inputManager;
    public float speed = 3;

    private GameObject target;
    private bool rotatingRight;

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        rotatingRight = true;
}

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        rotatingRight = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            target = inputManager.selectedGO;
        }
        catch { }

        if (rotatingRight)
        {
            target.transform.Rotate(Vector3.up * speed,-1  );
        }
    }
}
