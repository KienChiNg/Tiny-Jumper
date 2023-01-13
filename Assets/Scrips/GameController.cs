using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;


public class GameController : Singleton<GameController>
{
    public Player player;
    public Column column;
    public CamController cam;
    public float minSpawnX;
    public float maxSpawnX;
    public float minSpawnY;
    public float maxSpawnY;

    public Button soundButton;
    public Sprite soundOn;
    public Sprite soundOff;
    // public float powerBarUp;
    int m_score;
    int m_bestScore;
    bool didJump = false;
    // bool m_replayBtnClicked = false;
    bool m_isPlayGame;
    bool m_isPlaySound = true;
    public bool DidJump { get => didJump; set => didJump = value; }
    public bool IsPlayGame { get => m_isPlayGame; set => m_isPlayGame = value; }

    // private void OnEnable() {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    public void Start()
    {
        if (Prefs.sound == 0)
        {
            AudioController.Ins.aus.Stop();
            // Prefs.sound = 0;
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            AudioController.Ins.aus.Play();
            soundButton.GetComponent<Image>().sprite = soundOn;
            // Prefs.sound = 1;
        }
    }
    IEnumerator prefabsSpawn()
    {
        UIManager.Ins.showPanelScreenPlay(true);
        Column columnCur = null;
        didJump = false;
        if (column)
        {
            columnCur = Instantiate(column, new Vector2(-2, Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
            columnCur.id = columnCur.gameObject.GetInstanceID();
        }
        yield return new WaitForSeconds(0.5f);
        if (player)
        {
            player = Instantiate(player, new Vector2(-2, 0), Quaternion.identity);
            player.id = columnCur.id;
        }
        if (column)
        {
            createColumn();
        }
        yield return new WaitForSeconds(1);
        m_isPlayGame = true;
    }
    public void createColumn()
    {
        float spawnX = Random.Range(player.transform.position.x + minSpawnX, player.transform.position.x + maxSpawnX);
        float spawnY = Random.Range(minSpawnY, maxSpawnY);
        Column columnClone = Instantiate(column, new Vector2(spawnX, spawnY), Quaternion.identity);
        columnClone.id = columnClone.gameObject.GetInstanceID();
    }
    public void createColumnAndLerp(float playerXpos)
    {
        createColumn();
        if (cam)
        {
            cam.LerpTrigger(playerXpos + minSpawnX);
        }
    }
    public void incrementScore()
    {
        m_score++;
        Prefs.bestScore = m_score;
        UIManager.Ins.setScoreText(m_score.ToString());
    }

    public void playGame()
    {
        // if (m_isPlaySound){

        // }
        //     AudioController.Ins.aus.Play();
        UIManager.Ins.showPanelContainer(false);
        StartCoroutine(prefabsSpawn());
    }
    public void setSound()
    {
        if (Prefs.sound == 1)
        {
            AudioController.Ins.aus.Stop();
            Prefs.sound = 0;
            m_isPlaySound = false;
            soundButton.GetComponent<Image>().sprite = soundOff;

        }
        else
        {
            AudioController.Ins.aus.Play();
            Prefs.sound = 1;
            m_isPlaySound = true;
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
    }

    public void highScoreBtn()
    {
        UIManager.Ins.setBestScore();
        UIManager.Ins.showPanelHighScore(true);
        UIManager.Ins.showPanelContainer(false);
    }
    public void howToPlayBtn()
    {
        // UIManager.Ins.setBestScore();
        UIManager.Ins.showPanelHowToPlay(true);
        UIManager.Ins.showPanelContainer(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
