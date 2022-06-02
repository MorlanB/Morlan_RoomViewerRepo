using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject spawnable;
    private static Selector instance;
    public static Selector Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Selector>();

            return instance;
        }
    }

}
