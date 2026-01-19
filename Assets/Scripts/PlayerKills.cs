using TMPro;
using UnityEngine;

public class PlayerKills : MonoBehaviour
{
    public int kills;
    public TextMeshProUGUI killText;

    void Start()
    {
        UpdateUI();
    }

    public void AddKill()
    {
        kills++;
        UpdateUI();
    }

    void UpdateUI()
    {
        killText.text = $"Kills: {kills}";
    }
}
