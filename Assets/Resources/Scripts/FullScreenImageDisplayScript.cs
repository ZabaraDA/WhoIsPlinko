using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.EventSystems; // ���� �� ������������ EventTrigger �������

public class ClickableImageToFullscreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("������ �� Raw Image, ������� ����� ���������� �������� �� ���� �����.")]
    public RawImage fullScreenRawImage; // ���� ���������� ���� FullScreenDisplayImage

    [SerializeField]
    [Tooltip("������ ��� �������� ������������� �������� (�����������).")]
    private GameObject _imageContainer;

    void Start()
    {
        _imageContainer.SetActive(false);
    }

    // ��� ������� ����� ����������, ����� �� �������� �� ������������ ��������
    public void OpenImageFromClick(Button button)
    {
        RawImage clickedRawImage = button.GetComponentInChildren<RawImage>(true);
        if (clickedRawImage != null && clickedRawImage.texture != null)
        {
            fullScreenRawImage.texture = clickedRawImage.texture;
        }
        else
        {
            Debug.LogError("��� �������� Full Screen Texture ��� �� ���� ������� ����������� RawImage � ���������");
            return; // �������, ���� ��� ��������
        }
        //Screen.width
        float availableWidth = fullScreenRawImage.transform.parent.GetComponent<RectTransform>().rect.width;

        // �������� ������� ��������
        float imageWidth = clickedRawImage.texture.width;
        float imageHeight = clickedRawImage.texture.height;

        float heightScaleRatio = imageHeight / imageWidth;

        fullScreenRawImage.rectTransform.sizeDelta = new Vector2(availableWidth, availableWidth * heightScaleRatio);

        _imageContainer.SetActive(true);
    }

    // ��� ������� ����� ���������� �� ������� �� ������ ��������
    public void CloseImage()
    {
        if (_imageContainer != null)
        {
            _imageContainer.gameObject.SetActive(false);
        }
    }
}