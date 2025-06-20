using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour, IAnswerView
{

    [SerializeField]
    private Button _button;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TMP_Text _text;

    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public event Action<int> OnAnswerClicked;

    private void Start()
    {
        //_button = GetComponent<Button>();
        //_image =  GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Image>();
        //_text = GetComponent<TMP_Text>();

        _button.onClick.AddListener(OnQuestionClick);
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    public void OnQuestionClick()
    {
        OnAnswerClicked?.Invoke(Id);
        //_image.color = new Color(255 / 255f, 62 / 255f, 0 / 255f, 255 / 255f); //rgba(204, 57, 24, 1)
    }

}
