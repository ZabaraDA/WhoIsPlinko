using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoadScript : MonoBehaviour
{
    [SerializeField]
    private int _currentPageId;
    [SerializeField]
    private TMP_Text _pageText;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _toStartButton;
    private int _minPageId;
    private int _maxPageId;

    void Start()
    {
        FillPageContextById(_currentPageId);
    }

    public void LoadNextPageForScene()
    {
        _currentPageId++;
        FillPageContextById(_currentPageId);
    }
    public void LoadBackPageForScene()
    {
        _currentPageId--;
        FillPageContextById(_currentPageId);
    }

    private void FillPageContextById(int pageId)
    {

        PageContext pageContext = GetPageContextFromJsonById(pageId);

        _backButton.gameObject.SetActive(pageId > _minPageId);
        _nextButton.gameObject.SetActive(pageId < _maxPageId);
        _toStartButton.gameObject.SetActive(pageId == _maxPageId);

        _pageText.SetText(pageContext.Text);

    }

    private PageContext GetPageContextFromJsonById(int sceneId)
    {
        TextAsset text = Resources.Load<TextAsset>("Json/SceneInfoJson");
        var pageContextContainer = JsonConvert.DeserializeObject<JsonContainer<List<PageContext>>>(text.text);

        _minPageId = pageContextContainer.Value.Min(x => x.Id);
        _maxPageId = pageContextContainer.Value.Max(x => x.Id);
        return pageContextContainer.Value.FirstOrDefault(x => x.Id == sceneId);
    }
}
