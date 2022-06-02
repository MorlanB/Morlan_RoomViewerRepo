using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject spawnable;
    public InputManager IManager;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectSpawnable);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.localScale = Vector3.one * 1.3f;
            btn.enabled = true;
        }

        else
        {
            transform.localScale = Vector3.one;
            btn.enabled = false;
        }
    }

    void SelectSpawnable()
    {
        IManager.GetComponent<InputManager>().spawnable = spawnable;
        IManager.GetComponent<InputManager>().objHasSpawned = false;
    }
}
