using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerDead = false;

    public static void ResetGameState() => isPlayerDead = false;
}