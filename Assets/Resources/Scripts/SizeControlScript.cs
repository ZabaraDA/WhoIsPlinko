using UnityEngine;

public class SizeControllerScript : MonoBehaviour
{
    [SerializeField]
    public RectTransform _parentRectTransform; // Ссылка на RectTransform родительского объекта
    [SerializeField]
    public float _widthPercentage; // Ширина в процентах
    [SerializeField]
    public float _heightPercentage; // Высота в процентах

    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _parentRectTransform.rect.width * _widthPercentage / 100);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _parentRectTransform.rect.height * _heightPercentage / 100);
    }
}
