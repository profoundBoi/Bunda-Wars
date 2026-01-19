using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance;
    public TextMeshProUGUI winText;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        winText.text = message;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
