using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Singleton<Player>
{
    public Vector2 jumpForce;
    public Vector2 jumpForceUp;
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;
    public int id;
    Animator m_anm;
    Rigidbody2D m_rg;
    bool m_holding;
    bool m_upDownState = true;


    // float m_curPowerBarUp = 0;
    // Rigidbody2D
    
    // Start is called before the first frame update
    void Start()
    {
        m_anm = GetComponent<Animator>();
        m_rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            // Debug.Log(GameController.Ins.DidJump);
        if(!GameController.Ins.DidJump && GameController.Ins.IsPlayGame){
            setPower();
            if(Input.GetMouseButtonDown(0)){
                setPower2(true);
            }
            if(Input.GetMouseButtonUp(0) && m_holding){
                setPower2(false);
                GameController.Ins.DidJump = true;
                AudioController.Ins.aus.PlayOneShot(AudioController.Ins.jumpSound);
                UIManager.Ins.updatePowerBar(minForceX,maxForceX);
            }
        }
    }

    void setPower(){
        // Debug.Log(jumpForce);
        if(m_holding && m_rg){
            if (m_upDownState){
                if(jumpForce.x >= maxForceX) m_upDownState = false; 
                jumpForce.x += jumpForceUp.x * Time.deltaTime;
                jumpForce.y += jumpForceUp.y * Time.deltaTime;
            }else{
                // Debug.Log("Covaodaykhos");
                if(jumpForce.x <= minForceX) m_upDownState = true; 
                jumpForce.x -= jumpForceUp.x * Time.deltaTime;
                jumpForce.y -= jumpForceUp.y * Time.deltaTime;
            }
            jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX,maxForceX);
            jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY,maxForceY);

            // m_curPowerBarUp += GameController.Ins.powerBarUp * Time.deltaTime;
            // Debug.Log(m_curPowerBarUp);
            UIManager.Ins.updatePowerBar(jumpForce.x, maxForceX);
        }else{
            jumpForce = Vector2.zero;
        }
    }

    public void setPower2(bool isHolding){
        m_holding = isHolding;
        jump();
    }

    public void jump(){
        m_rg.velocity =  jumpForce;
        // m_rg.AddForce(jumpForce);
        if (m_anm){
            m_anm.SetBool("didJump", true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Column col = other.transform.root.GetComponent<Column>();
        if (other.CompareTag(TagCounts.GROUND)){
            // Debug.Log("Ground");
            m_anm.SetBool("didJump",false);
            GameController.Ins.DidJump = false;
        }
        if (other.CompareTag(TagCounts.DEATHZONE)){
            // Debug.Log("gameOver");
            UIManager.Ins.showPanelGameOver(true);
            AudioController.Ins.aus.Stop();
            AudioController.Ins.aus.PlayOneShot(AudioController.Ins.gameOverSound);
            // GameController.Ins.StopAllCoroutines();
            Destroy(gameObject);
        }
        if (col && col.id != id){
            // Debug.Log("Ground2");
            AudioController.Ins.aus.PlayOneShot(AudioController.Ins.fallSound);
            GameController.Ins.createColumnAndLerp(transform.position.x);
            GameController.Ins.incrementScore();
            id = col.id;
        } 
    }
    
}
