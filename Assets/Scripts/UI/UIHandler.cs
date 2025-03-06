using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance;

    [SerializeField] private float _warningDuration = 3f;
    [SerializeField] private string _initText;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private TMP_Text _messageDisplayer;
    [SerializeField] private GameObject _usePillsText;
    [SerializeField] private GameObject _returnToMenu;

    private TMP_Text _warning;
    private Mover _playerMover;

    private void Awake()
    {
        Instance = this;
        _warning = GetComponentInChildren<TMP_Text>();
        _playerMover = FindObjectOfType<Mover>();
    }

    private void Start()
    {
        _warning.gameObject.SetActive(false);
        WarningRoutine(_initText);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !_returnToMenu.activeInHierarchy)
        {
            if (_inventoryPanel.activeInHierarchy)
            {
                _playerMover.SetCanMove(true);
                InventoryUI.Instance.ResetPanel();
                _inventoryPanel.SetActive(false);
            }
            else
            {
                _inventoryPanel.SetActive(true);
                _playerMover.SetCanMove(false);
                InventoryUI.Instance.LoadItems();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !_inventoryPanel.activeInHierarchy)
        {
            if (_returnToMenu.activeInHierarchy)
            {
                _returnToMenu.SetActive(false);
                _playerMover.SetCanMove(true);
            }
            else
            {
                _returnToMenu.SetActive(true);
                _playerMover.SetCanMove(false);
            }
        }
    }


    public void WarningRoutine(string textToShow)
    {
        StartCoroutine(ShowWarning(textToShow));
    }

    public IEnumerator ShowWarning(string textToShow)
    {
        textToShow = textToShow.ToUpper();
        _warning.gameObject.SetActive(true);
        _warning.text = textToShow;
        yield return new WaitForSecondsRealtime(_warningDuration);
        _warning.text = "";
        _warning.gameObject.SetActive(false);
    }

    public void MessageDisplayer(string textToShow)
    {
        _playerMover.SetCanMove(false);
        _messagePanel.SetActive(true);
        _messageDisplayer.text = textToShow;
    }

    public void ClosePanel()
    {
        _playerMover.SetCanMove(true);
        _messagePanel.SetActive(false);
    }

    public void HandlePills(bool value)
    {
        _usePillsText.SetActive(value);
    }

    public void Reload()
    {
        SceneLoader.Instance.ReloadScene();
    }

    public void ReturnToMainMenu()
    {
        SceneLoader.Instance.LoadMainMenu();
    }
}
