using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    private Color transparentColor;
    private Image image;
    private TextMeshProUGUI loadingText;

    private Sequence showScreen;
    private Sequence hideScreen;

    void Start()
    {
        image = GetComponent<Image>();
        loadingText = GetComponentInChildren<TextMeshProUGUI>();
        transparentColor = Color.black;
        transparentColor.a = 0;
        InitAnims();
    }

    private void InitAnims()
    {
        showScreen = DOTween.Sequence();
        showScreen
            .Append(image.DOColor(Color.black, StaticData.AnimLength))
            .Join(loadingText.DOColor(Color.white, StaticData.AnimLength));

        hideScreen = DOTween.Sequence();
        hideScreen
            .Append(image.DOColor(transparentColor, StaticData.AnimLength))
            .Join(loadingText.DOColor(transparentColor, StaticData.AnimLength));
    }

    public void ShowScreen()
    {
        showScreen.Restart();
    }

    public void HideScreen()
    {
        hideScreen.Restart();
    }
}
