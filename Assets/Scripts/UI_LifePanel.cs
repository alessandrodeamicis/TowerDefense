using UnityEngine;
using UnityEngine.UI;

public class UI_LifePanel : MonoBehaviour
{
    [SerializeField] private Image _fillableLifeBar;

    public void UpdateGraphics(int currentHp, int maxHp)
    {
        _fillableLifeBar.fillAmount = (float)currentHp / maxHp;
    }
}
