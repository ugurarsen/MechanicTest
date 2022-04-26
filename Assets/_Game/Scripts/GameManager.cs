public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false;

    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;

        canStart = false;

        //TODO SEND ANALYTICS EVENT

        UIManager.S.OnGameStarted();
        TouchHandler.S.OnGameStarted();
        PlayerController.S.OnGameStarted();
        isRunning = true;
    }

    public static void OnLevelCompleted()
    {
        isRunning = false;
        canStart = false;
        UIManager.S.OnSuccess();
    }

    public static void ReloadScene(bool isSuccess)
    {
        //TODO SEND ANALYTICS EVENT

        if (isSuccess)
        {
            // Save to player prefs
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}