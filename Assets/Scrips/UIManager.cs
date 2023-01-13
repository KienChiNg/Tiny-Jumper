using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public GameObject panelContainer;
    public GameObject panelScreenPlay;
    public GameObject panelGameOver;
    public GameObject panelHighScore;
    public GameObject panelHowToPlay;
    public Image powerBar;
    public Button playBtn;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI scoreGOTxt;
    public TextMeshProUGUI bestScore;
    public void showPanelContainer(bool state){
        if(panelContainer)
            panelContainer.SetActive(state);
    }
    public void showPanelScreenPlay(bool state){
        if(panelScreenPlay)
            panelScreenPlay.SetActive(state);
    }
    public void showPanelHowToPlay(bool state){
        if(panelHowToPlay)
            panelHowToPlay.SetActive(state);
    }
    public void setScoreText(string content){
        scoreTxt.text = content;
        scoreGOTxt.text = content;
    }
    public void updatePowerBar(float curVal, float totalVal){
        powerBar.fillAmount = curVal/totalVal;
    }
    public void setBestScore(){
        bestScore.text = Prefs.bestScore.ToString();
    }
    public void showPanelGameOver(bool state){
        panelGameOver.SetActive(state);
    }
    public void showPanelHighScore(bool state){
        panelHighScore.SetActive(state);
    }
}
