using UnityEngine;

public class SizeControllerScript : MonoBehaviour
{
    [SerializeField]
    public RectTransform _parentRectTransform; // ������ �� RectTransform ������������� �������
    [SerializeField]
    public float _widthPercentage; // ������ � ���������
    [SerializeField]
    public float _heightPercentage; // ������ � ���������

    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _parentRectTransform.rect.width * _widthPercentage / 100);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _parentRectTransform.rect.height * _heightPercentage / 100);
    }
}
