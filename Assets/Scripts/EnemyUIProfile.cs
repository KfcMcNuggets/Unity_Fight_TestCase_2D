using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUIProfile : MonoBehaviour
{
    private RawImage photo;
    private TextMeshProUGUI name;

    public void Init()
    {
        photo = GetComponentInChildren<RawImage>();
        name = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetName(string fullName)
    {
        name.text = fullName;
    }

    public void SetPhoto(Texture texture)
    {
        photo.texture = texture;
    }
}
