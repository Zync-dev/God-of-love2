using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{

    Canvas canvas;

    GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        canvas = this.GetComponent<Canvas>();

        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");

        canvas.worldCamera = Camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
