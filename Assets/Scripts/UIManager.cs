using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(gameObject);

    }
}
