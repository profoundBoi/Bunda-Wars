using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int winKills = 5;

    private int player1Kills;
    private int player2Kills;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerScored(string playerTag)
    {
        if (playerTag == "Player1")
            player1Kills++;
        else if (playerTag == "Player2")
            player2Kills++;

        Debug.Log($"Score — P1: {player1Kills} | P2: {player2Kills}");

        CheckWin();
    }

    void CheckWin()
    {
        if (player1Kills >= winKills)
            EndGame("Player 1 Wins!");
        else if (player2Kills >= winKills)
            EndGame("Player 2 Wins!");
    }

    void EndGame(string winner)
    {
        Debug.Log(winner);
        Time.timeScale = 0f; // Freeze game
    }
}
