using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    // private void OnEnable() {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    
    bool m_replayBtnClicked;
    public void goToHome(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goToHomeHowToPlay(){
        UIManager.Ins.showPanelHowToPlay(false);
        UIManager.Ins.showPanelContainer(true);
    }
    public void goToHomeHighScore(){
        UIManager.Ins.showPanelHighScore(false);
        UIManager.Ins.showPanelContainer(true);
    }
    public void replay(){
        m_replayBtnClicked = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(m_replayBtnClicked){
            // Debug.Log("alooooo");
            // if(Prefs.sound == 0){
            //     AudioController.Ins.aus.Stop();
            //     // Prefs.sound = 0;
            // }else{
            //     AudioController.Ins.aus.Play();
            //     // Prefs.sound = 1;
            // }
            UIManager.Ins.showPanelContainer(false);
            GameController.Ins.playGame();
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
