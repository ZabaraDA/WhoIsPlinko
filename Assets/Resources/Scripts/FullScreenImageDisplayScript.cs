using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.EventSystems; // Если бы использовали EventTrigger вручную

public class ClickableImageToFullscreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Ссылка на Raw Image, который будет показывать картинку на весь экран.")]
    public RawImage fullScreenRawImage; // Сюда перетащишь свой FullScreenDisplayImage

    [SerializeField]
    [Tooltip("Кнопка для закрытия полноэкранной картинки (опционально).")]
    private GameObject _imageContainer;

    void Start()
    {
        _imageContainer.SetActive(false);
    }

    // Эта функция будет вызываться, когда ТЫ кликнешь на кликабельную картинку
    public void OpenImageFromClick(Button button)
    {
        RawImage clickedRawImage = button.GetComponentInChildren<RawImage>(true);
        if (clickedRawImage != null && clickedRawImage.texture != null)
        {
            fullScreenRawImage.texture = clickedRawImage.texture;
        }
        else
        {
            Debug.LogError("Нет текстуры Full Screen Texture или на этом объекте отсутствует RawImage с текстурой");
            return; // Выходим, если нет текстуры
        }
        //Screen.width
        float availableWidth = fullScreenRawImage.transform.parent.GetComponent<RectTransform>().rect.width;

        // Исходные размеры текстуры
        float imageWidth = clickedRawImage.texture.width;
        float imageHeight = clickedRawImage.texture.height;

        float heightScaleRatio = imageHeight / imageWidth;

        fullScreenRawImage.rectTransform.sizeDelta = new Vector2(availableWidth, availableWidth * heightScaleRatio);

        _imageContainer.SetActive(true);
    }

    // Эта функция будет вызываться по нажатию на кнопку закрытия
    public void CloseImage()
    {
        if (_imageContainer != null)
        {
            _imageContainer.gameObject.SetActive(false);
        }
    }
}