using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    bool gameHasEnded = false;
    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
