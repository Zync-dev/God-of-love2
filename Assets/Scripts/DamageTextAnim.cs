using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextAnim : MonoBehaviour
{

    float timeToDelete = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("DmgAnim");
    }

    // Update is called once per frame
    void Update()
    {
        timeToDelete -= Time.deltaTime;

        if (timeToDelete <= 0)
        {
            Destroy(this.gameObject);
        } 
    }
}
