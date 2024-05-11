using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float pitchSpeed;
    public float yawSpeed;
    public float moveSpeed;

    public float pitch;
    public float yaw;

    Camera plrCam;
    Rigidbody player;
    ParticleSystem stars;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        
        player = gameObject.GetComponent<Rigidbody>();
        plrCam = gameObject.GetComponentInChildren<Camera>();
        stars = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        pitch += Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;
        yaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -90, 90);
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float up = Input.GetAxis("Jump");
        float down = 0;

        bool sprintkey = Input.GetKey(KeyCode.LeftShift);
        bool downKey = Input.GetKey(KeyCode.C);
        
        
        if (downKey)
        {
            down = 1;
        }

        plrCam.transform.localRotation = Quaternion.Euler(-pitch, 0, 0);
        player.transform.rotation = Quaternion.Euler(0, yaw, 0);

        player.transform.position += plrCam.transform.forward * vertical * moveSpeed * Time.deltaTime;
        player.transform.position += plrCam.transform.right * horizontal * moveSpeed * Time.deltaTime;
        player.transform.position += player.transform.up * up * moveSpeed * Time.deltaTime;
        player.transform.position += player.transform.up * -down * moveSpeed * Time.deltaTime;
    }
}
