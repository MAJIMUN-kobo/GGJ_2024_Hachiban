using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class localizeTextChange : MonoBehaviour
{
    private enum Language
    {
        English,
        Japanese
    }

    [SerializeField]
    int id;

    private Language language= Language.Japanese;
    private UIMenu uIMenu;
    private TextMeshProUGUI text;

    private void Awake()
    {
        uIMenu = GameObject.Find("ExcelDataManager").GetComponent<ExcelDataManager>().uiMenu;
        text = GetComponent<TextMeshProUGUI>();
        Debug.Log(text.name);
    }

    private void Start()
    {
        switch (language)
        {
            case Language.English:
                text.text = uIMenu.Sheet1[id].English;
                break;
            case Language.Japanese:
                text.text = uIMenu.Sheet1[id].Japanese;
                break;
            default:
                break;
        }
    }
}
