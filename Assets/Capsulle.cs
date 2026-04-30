using UnityEngine;
using UnityEngine.SceneManagement;

public class Capsulle : MonoBehaviour
{
    public string sceneName;
    public void OpenScene()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Scene");
        SceneManager.LoadScene(sceneName);
    }
}
