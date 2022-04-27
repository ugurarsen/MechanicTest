using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool canStart = true, isRunning = false;

    public static void OnStartGame()
    {
        
        if (isRunning || !canStart) return;
        canStart = false;

        UIManager.S.OnGameStarted();
        TouchHandler.S.OnGameStarted();
        PlayerController.S.OnGameStarted();
        isRunning = true;
    }
    
    public static void OnCompleted()
    {
        isRunning = false;
        canStart = true;
        UIManager.S.OnSuccess();
    }
    

    public static void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}