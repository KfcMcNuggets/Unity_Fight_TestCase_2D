using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private FindManager findManager;

    private void Start()
    {
        findManager = GetComponent<FindManager>();
        UpdateEnemy();
    }

    public void UpdateEnemy()
    {
        findManager.FindEnemy();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
