using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverUI;

    [HideInInspector]
    public bool gameOver = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }
}
