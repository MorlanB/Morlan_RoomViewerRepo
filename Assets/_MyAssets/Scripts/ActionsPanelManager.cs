using UnityEngine;
using UnityEngine.UI;

public class ActionsPanelManager : MonoBehaviour
{
    public Button modeToggle;
    public Button delete;
    public Button goBack;
    public Sprite moveSprite;
    public Sprite rotateSprite;
    public GameObject rotateArrows;


    [SerializeField] private InputManager inputManager;

    private bool isInMoveMode = true;
    private bool isInRotMode = false;

    // Start is called before the first frame update
    void Start()
    {
        modeToggle.onClick.AddListener(ToggleMode);
        delete.onClick.AddListener(SelectDelete);
        goBack.onClick.AddListener(HideEditMenu);

        modeToggle.GetComponent<Image>().sprite = moveSprite;
        modeToggle.GetComponent<Image>().sprite = rotateSprite;

        inputManager.inMoveMode = isInMoveMode;
        modeToggle.GetComponent<Image>().sprite = rotateSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleMode()
    {
        isInMoveMode = !isInMoveMode;
        isInRotMode = !isInRotMode;

        inputManager.inMoveMode = isInMoveMode;
        inputManager.inRotateMode = isInRotMode;

        inputManager.ShowRotArrows();

        if(isInMoveMode)
            modeToggle.GetComponent<Image>().sprite = rotateSprite;
        else 
            modeToggle.GetComponent<Image>().sprite = moveSprite;
    }

    void SelectDelete()
    {
        inputManager.DeleteSelectedObj();
    }

    void HideEditMenu()
    {
        inputManager.HideEditMenu();
    }
}