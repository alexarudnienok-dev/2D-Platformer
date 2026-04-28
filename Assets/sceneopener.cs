using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneopener : MonoBehaviour
{
    public string sceneName;
    public void OpenScene()
    {
       SceneManager.LoadScene(sceneName);
    }
}
