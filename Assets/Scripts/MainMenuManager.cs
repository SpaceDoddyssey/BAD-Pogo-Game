using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pogoStick, mainMenuObject;

    void Start(){
        pogoStick.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pogoStick.GetComponent<Rigidbody>().isKinematic = false;
            mainMenuObject.SetActive(false);
            pogoStick.GetComponent<RotateOnY>().enabled = false;
        }
    }
}
