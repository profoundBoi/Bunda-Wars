using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    void Start()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        if (input.playerIndex == 0)
        {
            SetupPlayer("Player1", "Player1Spawn");
        }
        else if (input.playerIndex == 1)
        {
            SetupPlayer("Player2", "Player2Spawn");
        }
    }

    void SetupPlayer(string playerTag, string spawnTag)
    {
        gameObject.tag = playerTag;

        GameObject spawn = GameObject.FindGameObjectWithTag(spawnTag);
        if (!spawn) return;

        CharacterController cc = GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        transform.position = spawn.transform.position;
        transform.rotation = spawn.transform.rotation;

        if (cc != null)
            cc.enabled = true;
    }
}
