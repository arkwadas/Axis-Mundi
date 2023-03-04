using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float rollSpeed = 5f;
    public Animator anim;

    private bool isRolling = false;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        ActiveRoll();
    }

    private void ActiveRoll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRolling)
        {
            isRolling = true;
            anim.SetTrigger("Roll");
            StartCoroutine(Rolling());
        }
    }

    IEnumerator Rolling()
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rollSpeed;
            transform.Translate(Vector3.forward * Time.deltaTime * rollSpeed);
            yield return null;
        }
        isRolling = false;
    }
}
