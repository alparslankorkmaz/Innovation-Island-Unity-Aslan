using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public void LoadScene(string sceneName)
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(sceneName);
    }
}