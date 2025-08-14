using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButtonHandler : MonoBehaviour
{
    [SerializeField] private float _fadeInTime, _fadeOutTime;
    protected Button _btn;
    protected void Awake()
    {
        _btn = gameObject.GetComponent<Button>();
        _btn.onClick.AddListener(ButtonClicked);
    }

    protected abstract void ButtonClicked();

    public void ActivateButton()
    {
        gameObject.SetActive(true);
        GetComponent<Button>().interactable = false;

        TMPro.TextMeshProUGUI btnText = GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        btnText.alpha = 0f; ;
        btnText.DOFade(1f, _fadeInTime);

        Image[] imgs = GetComponentsInChildren<Image>(true);
        foreach (var img in imgs)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
            img.DOFade(1f, _fadeInTime);
        }

        GetComponent<Button>().interactable = true;
    }

    public void DesactivateButton()
    {
        GetComponent<Button>().interactable = false;

        TMPro.TextMeshProUGUI btnText = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        btnText.DOFade(0f, _fadeOutTime);

        Image[] imgs = GetComponentsInChildren<Image>(true);
        foreach (var img in imgs)
        {
            img.DOFade(0f, _fadeOutTime);
        }
    }

    public void ToggleButton(bool boolean)
    {
        this.GetComponentInChildren<TextMeshProUGUI>(true).enabled = boolean;
        Image[] imgs = gameObject.GetComponentsInChildren<Image>();

        foreach (var img in imgs)
        {
            img.enabled = boolean;
        }
        this.GetComponent<Button>().interactable = boolean;
    }
}
