using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public Collider bladeCollider;
    public Camera mainCamera;
    public Vector3 direction{get; private set;}
    public float minSliceVelocity = 0.01f;
    private bool slicing; 


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            startSliciing();
        }else if(Input.GetMouseButtonUp(0)){
            stopSlicing();
        }else if(slicing){
            continueSlicing();
        }
    }

    private void startSliciing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;
    }

    private void stopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
    }

    private void continueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition-transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        if(velocity > minSliceVelocity){
            bladeCollider.enabled = true;
        }else{
            bladeCollider.enabled = false;
        }

        transform.position = newPosition;
        
    }
    private void OnEnable()
    {
        stopSlicing();
    }

    private void OnDisable()
    {
        stopSlicing();
    }
}
