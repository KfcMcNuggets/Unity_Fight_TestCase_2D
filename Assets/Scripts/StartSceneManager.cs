using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField]
    private LoadingScreen loadingScreen;

    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private Button playButton;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Application.targetFrameRate = 300;
    }

    private void Start()
    {
        LoadName();
    }

    private void Update()
    {
        playButton.interactable = !string.IsNullOrEmpty(inputField.text);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetString(StaticData.namePref, inputField.text);
        PlayerPrefs.Save();
        loadingScreen.ShowScreen();
        SceneManager.LoadSceneAsync(StaticData.findScene);
    }

    private void LoadName()
    {
        if (PlayerPrefs.HasKey(StaticData.namePref))
        {
            inputField.text = PlayerPrefs.GetString(StaticData.namePref);
        }
    }
}
