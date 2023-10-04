using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.LoadNext();
        }
    }
}

public static class SceneLoader
{
    public static void LoadNext()
    {
        SceneManager.LoadScene(StaticData.findScene);
    }
}
