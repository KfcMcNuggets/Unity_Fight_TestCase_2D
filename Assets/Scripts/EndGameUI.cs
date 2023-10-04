using UnityEngine;
using TMPro;
using DG.Tweening;

public class EndGameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinsCount;

    private RectTransform rt;
    private Sequence showEndAnim,
        closeSceneAnim;
    private int coinsEarned;
    private Vector2 hidePos;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        hidePos = rt.anchoredPosition;
        InitAnim();
    }

    private void InitAnim()
    {
        showEndAnim = DOTween.Sequence();

        showEndAnim
            .AppendCallback(() =>
            {
                coinsCount.text = coinsEarned.ToString();
            })
            .Append(rt.DOAnchorPos(Vector2.zero, StaticData.AnimLength));

        closeSceneAnim = DOTween.Sequence();
        closeSceneAnim
            .Append(rt.DOAnchorPos(hidePos, StaticData.AnimLength))
            .AppendCallback(() =>
            {
                SceneLoader.LoadNext();
            });
    }

    public void EndGame(int reward)
    {
        coinsEarned = reward;
        showEndAnim.Restart();
    }

    public void CloseScene()
    {
        closeSceneAnim.Restart();
    }
}
