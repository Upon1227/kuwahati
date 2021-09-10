using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{

    [SerializeField] Slider bgmSlider = default;
    [SerializeField] Slider seSlider = default;
    [SerializeField] GameObject soundUIPanel;

    void Start()
    {
        bgmSlider.value = AudioParamsSO.Entity.BGMVolume;
        seSlider.value = AudioParamsSO.Entity.SEVolume;

        bgmSlider.onValueChanged.AddListener(volume => SoundManager.instance.SetBGMVolume(volume));
        seSlider.onValueChanged.AddListener(volume => SoundManager.instance.SetSEVolume(volume));

    }

    public void TestSE()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Uki);
    }

    public void ShowPanel()
    {
        soundUIPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        soundUIPanel.SetActive(false);
    }
}