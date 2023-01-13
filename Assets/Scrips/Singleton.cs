using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<Guest> : MonoBehaviour where Guest : MonoBehaviour
{
    public static Guest Ins;
    void Awake()
    {
        makeSingleton();
    }
    public void makeSingleton(){
        if(Ins == null){
            Ins = this as Guest;
        }else{
            Destroy(gameObject);
        }
    }
}
