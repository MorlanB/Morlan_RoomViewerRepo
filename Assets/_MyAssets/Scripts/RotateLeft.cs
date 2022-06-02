using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public InputManager inputManager;
    public float speed = 3;

    private GameObject target;
    private bool rotatingLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        rotatingLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        rotatingLeft = false;
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
        catch{}

        if (rotatingLeft)
        {
            target.transform.Rotate(Vector3.up * speed);
        }
    }
}
