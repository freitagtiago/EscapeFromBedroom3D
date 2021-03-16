using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] float warningDuration = 3f;
    [SerializeField] string initText;
    [SerializeField] GameObject messagePanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] TMP_Text messageDisplayer;
    [SerializeField] GameObject usePillsText;
    [SerializeField] GameObject returnToMenu;

    public static UIHandler instance;
    TMP_Text warning;
    Mover mover;

    private void Awake()
    {
        instance = this;
        warning = GetComponentInChildren<TMP_Text>();
        mover = FindObjectOfType<Mover>();
    }

    private void Start()
    {
        warning.gameObject.SetActive(false);
        WarningRoutine(initText);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !returnToMenu.activeInHierarchy)
        {
            if (inventoryPanel.activeInHierarchy)
            {
                mover.SetCanMove(true);
                InventoryUI.instance.ResetPanel();
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
                mover.SetCanMove(false);
                InventoryUI.instance.LoadItems();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !inventoryPanel.activeInHierarchy)
        {
            if (returnToMenu.activeInHierarchy)
            {
                returnToMenu.SetActive(false);
                mover.SetCanMove(true);
            }
            else
            {
                returnToMenu.SetActive(true);
                mover.SetCanMove(false);
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
        warning.gameObject.SetActive(true);
        warning.text = textToShow;
        yield return new WaitForSecondsRealtime(warningDuration);
        warning.text = "";
        warning.gameObject.SetActive(false);
    }

    public void MessageDisplayer(string textToShow)
    {
        mover.SetCanMove(false);
        messagePanel.SetActive(true);
        messageDisplayer.text = textToShow;
    }

    public void ClosePanel()
    {
        mover.SetCanMove(true);
        messagePanel.SetActive(false);
    }

    public void HandlePills(bool value)
    {
        usePillsText.SetActive(value);
    }

    public void Reload()
    {
        Loader.instance.ReloadScene();
    }

    public void ReturnToMainMenu()
    {
        Loader.instance.LoadMainMenu();
    }
}
