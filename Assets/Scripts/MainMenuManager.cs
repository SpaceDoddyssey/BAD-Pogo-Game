using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pogoStick, mainMenuObject, cameraObject;
    void Start(){
        pogoStick.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mainMenuObject.SetActive(false);
            pogoStick.GetComponent<RotateOnY>().enabled = false;
            pogoStick.transform.DORotate(new Vector3(0, 0, 0), 1.0f);
            pogoStick.transform.DOMove(cameraObject.transform.position + new Vector3(0, -2, 5), 1.0f).OnComplete(() => {
                cameraObject.transform.parent = pogoStick.transform;
                pogoStick.GetComponent<Rigidbody>().isKinematic = false;
            });
        }
    }
}
