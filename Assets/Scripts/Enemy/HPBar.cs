using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    private Image hpFill;

    public void UpdateHp(float currentHp, float maxHp)
    {
        float hpPercent = currentHp / maxHp;
        hpFill.fillAmount = hpPercent;
        hpFill.color = new Color(1 - hpPercent, hpPercent, 0, 1);
    }
}
