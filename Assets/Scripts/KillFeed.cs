using TMPro;
using UnityEngine;

public class KillFeed : MonoBehaviour
{
    public static KillFeed Instance;
    public TextMeshProUGUI text;

    void Awake()
    {
        Instance = this;
        text.text = "";
    }

    public void Show(string message)
    {
        text.text = message;
        CancelInvoke();
        Invoke(nameof(Clear), 2f);
    }

    void Clear()
    {
        text.text = "";
    }
}
