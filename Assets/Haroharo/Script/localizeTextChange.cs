using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class localizeTextChange : MonoBehaviour
{
    private enum Language
    {
        English,
        Japanese
    }

    [SerializeField]
    int id;

    [SerializeField]
    private bool is_image = false;
    [SerializeField]
    private Sprite JP_Image;
    [SerializeField]
    private Sprite EN_Image;

    private Language language= Language.Japanese;
    private UIMenu uIMenu;
    private TextMeshProUGUI text = null;
    private Image image = null;

    private void Awake()
    {
        if (is_image)
        {
            image = GetComponent<Image>();
        }
        else
        {
            uIMenu = GameObject.Find("ExcelDataManager").GetComponent<ExcelDataManager>().uiMenu;
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        switch (language)
        {
            case Language.English:
                if (is_image)
                {
                    image.sprite = EN_Image;
                }
                else
                {
                    text.text = uIMenu.Sheet1[id].English;
                }
                break;

            case Language.Japanese:
                if (is_image)
                {
                    image.sprite = JP_Image;
                }
                else
                {
                    text.text = uIMenu.Sheet1[id].Japanese;
                }
                break;
            default:
                break;
        }
    }
}
