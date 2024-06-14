using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class cutsceneTrigger : MonoBehaviour
{
    public GameObject cutsceneGameObject;
    public Animator cutSceneAnim;
    public bool preRendered;
    public VideoPlayer preRenderedVideo;

    public string cutsceneTriggerName;
    // public RawImage videoImage;
    public SC_FPSController playerScript;
    public Camera playerCam;
    public float cutsceneTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerScript.enabled = false;
            if (preRendered == false)
            {
                cutsceneGameObject.SetActive(true);
                playerCam.enabled = false;
                cutSceneAnim.SetTrigger(cutsceneTriggerName);
                StartCoroutine(cutsceneRoutine());
            }

            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator cutsceneRoutine()
    {
        yield return new WaitForSeconds(cutsceneTime);
        playerScript.enabled = true;
        playerCam.enabled = true;
    }
}
