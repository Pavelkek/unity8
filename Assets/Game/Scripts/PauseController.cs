using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : GameOver
{
    [SerializeField]
    private GameObject mainCameraObject;
    [SerializeField]
    private GameObject gameOverCameraObject;
    [SerializeField]
    private GameObject pauseCameraObject;
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Continue()
    {
        mainCameraObject.SetActive(true);
        gameOverCameraObject.SetActive(false);
        pauseCameraObject.SetActive(false);
        mainCameraObject.GetComponent<Camera>().depth = 1;
        gameOverCameraObject.GetComponent<Camera>().depth = 0;
        pauseCameraObject.GetComponent<Camera>().depth = 0;
    }
}
