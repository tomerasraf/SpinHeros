﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure some components cannot be accidentally deleted.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class FishingController : MonoBehaviour {
    
    Rigidbody player;
    public float speed;
    Animator anim;
    bool canFish;
    Vector3 moveDirection;

    float timerToCatch;
    float timeBeforeBite;
    bool isFishing;

    public GameObject fishingZone;

    public GameObject fishingPole;
    
    void Start () {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        fishingPole.SetActive(false);
    }
	
	
	void Update () {
        timerToCatch += Time.deltaTime;

        // Player attempts to start fishing when F is pressed. Useless comment is useless.
        if (Input.GetKeyDown(KeyCode.F))
        {
            //fishingPole.GetComponent<FishingPole>().ResetPhy(fishingPole);
            FishCheck();
        }

        // Player movement cancels fishing.
        if ((moveDirection.x != 0 || moveDirection.z != 0) && isFishing)
        {
            Debug.Log("You have moved. Fishing was cancelled.");
            isFishing = false;
        }

        // FISHING TIMER
        if (timerToCatch > timeBeforeBite && isFishing)
        {
            // Player catches fish.
            Debug.Log("You have caught a fish!");
            isFishing = false;
            //inventory.AddItem(6);
            anim.SetBool("IsFishing", false);
            fishingPole.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // Moving player.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        player.MovePosition(player.position + moveDirection * speed * Time.deltaTime);
        
        // Set player rotation
        Quaternion rotation = transform.rotation;
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            rotation.SetLookRotation(moveDirection);
        }
        transform.rotation = rotation;


        // Sets animation for walking if player is moving.
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsFishing", false);
            fishingPole.SetActive(false);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }

    void FishCheck()
    {
        canFish = fishingZone.GetComponent<FishingZone>().PlayerCanFish();

        if (canFish)
        {
            Fish();
            Debug.Log("You are fishing! :)");
        }
        else
        {
            Debug.Log("You cannot fish here!");
        }
    }

    // Weird stupid fishing code that works for some reason.
    void Fish()
    {
        timerToCatch = 0f;
        timeBeforeBite = 0f;
        System.Random random = new System.Random();

        // Testing value.
        //timeBeforeBite = 3;

        // Real value.
        timeBeforeBite = random.Next(10) + 5;

        Debug.Log(timeBeforeBite);
        isFishing = true;
        anim.SetBool("IsFishing", true);
        fishingPole.SetActive(true);
    }
}
