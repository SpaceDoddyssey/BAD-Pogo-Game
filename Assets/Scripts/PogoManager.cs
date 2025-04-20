using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoManager : MonoBehaviour
{
    [SerializeField] private GameObject pogoStick, pogoCrossbar, pogoTip, pogoMetal, rayObj;
    [SerializeField] private LayerMask pogoLayerMask;
    private float distFromBodyToMetal;
    private float castLength, stickLength;
    private Vector3 defaultMetalPos, defaultTipPos;

    private void Awake(){
        distFromBodyToMetal = Vector3.Distance(rayObj.transform.localPosition, pogoMetal.transform.localPosition);
        stickLength = pogoMetal.GetComponent<MeshRenderer>().bounds.extents.y;
        castLength = Vector3.Distance(rayObj.transform.position, pogoTip.transform.position); 
        defaultMetalPos = pogoMetal.transform.localPosition;
        defaultTipPos = pogoTip.transform.localPosition;
    }

    void FixedUpdate(){
        //Cast a ray down from the base of the metal to check if the tip is touching the ground
        Vector3 rayOrigin = rayObj.transform.position;
        Vector3 rayDirection = pogoStick.transform.up * -1;
        Debug.DrawRay(rayOrigin, rayDirection * castLength, Color.red);
    
        Quaternion newRot = Quaternion.RotateTowards(pogoStick.transform.rotation, new Quaternion(0,0,0,1), 0.001f);
        pogoStick.transform.rotation = newRot;

        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, rayDirection, out hit, castLength, pogoLayerMask)){
            pogoTip.transform.position = hit.point;
            pogoMetal.transform.position = pogoTip.transform.position + new Vector3(0, stickLength, 0);
        
            float pogoForce = 0.0f;
            float distance = Vector3.Distance(rayObj.transform.localPosition, pogoMetal.transform.localPosition);
            if(distance < distFromBodyToMetal){
                pogoForce = Mathf.Lerp(0, 7, (distFromBodyToMetal - distance) / distFromBodyToMetal);
            }
            Debug.Log(string.Format("Distance: {0},  DfBtM:  {1, 6:0.00},  Pogoforce:  {2}", distance, distFromBodyToMetal, pogoForce));

            Vector3 upVector = pogoStick.transform.up;
            if(Vector3.Dot(upVector, Vector3.up) > 0.99f){
                upVector = Vector3.up;
            }
            pogoStick.GetComponent<Rigidbody>().AddForceAtPosition(upVector * pogoForce, pogoStick.transform.position, ForceMode.Impulse);
        } else {
            pogoTip.transform.localPosition = defaultTipPos;
            pogoMetal.transform.localPosition = defaultMetalPos;
        }
    }
}
