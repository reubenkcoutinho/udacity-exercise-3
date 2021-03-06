﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoof;
    public Door door;

    public static bool hasKey;

    private void Awake()
    {
        hasKey = false;
    }

    void Start()
    {
        print("key count = " + hasKey);
    }

    void Update()
	{
        //Bonus: Key Animation
        transform.Rotate(Vector3.up * Time.deltaTime * 60f * 3f);
    }

    public void OnKeyClicked()
    {
        if (!hasKey)
        {
            // Instatiate the KeyPoof Prefab where this key is located
            // Make sure the poof animates vertically
            Object.Instantiate(keyPoof, gameObject.transform.position, Quaternion.Euler(Camera.main.transform.rotation.eulerAngles));

            // Call the Unlock() method on the Door

            // Destroy the key. Check the Unity documentation on how to use Destroy
            Destroy(gameObject);
            hasKey = true;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        var textObj = GameObject.FindGameObjectWithTag("KeyText").GetComponent<TextMesh>();
        textObj.text = string.Format("Key {0}/1", (hasKey?1:0));
    }

}
