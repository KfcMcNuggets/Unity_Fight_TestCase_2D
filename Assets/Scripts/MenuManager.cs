using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private FindManager findManager;

    [SerializeField]
    private TextMeshProUGUI coinCount;

    [SerializeField]
    private TextMeshProUGUI playerName;

    private void Start()
    {
        coinCount.text = PlayerPrefs.GetInt(StaticData.goldPref).ToString();
        playerName.text = PlayerPrefs.GetString(StaticData.namePref);
        findManager = GetComponent<FindManager>();
        findManager.Init();
    }

    public void UpdateEnemy()
    {
        findManager.FindEnemy();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(StaticData.gameScene);
    }
}
