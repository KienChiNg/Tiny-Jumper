using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Update is called once per frame
    public void Update()
    {
        transform.position = new Vector3(
            CamController.Ins.transform.position.x-3,
            CamController.Ins.transform.position.y,
            0f
        );
    }
}
