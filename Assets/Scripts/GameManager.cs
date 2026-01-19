using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int killsToWin = 5;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterKill(GameObject killer)
    {
        PlayerKills kills = killer.GetComponent<PlayerKills>();
        if (!kills) return;

        kills.AddKill();

        if (kills.kills >= killsToWin)
            WinScreen.Instance.Show($"{killer.tag} WINS!");
    }
}
