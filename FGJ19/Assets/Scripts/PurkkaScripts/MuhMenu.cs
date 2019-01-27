using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuhMenu : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        Screen.lockCursor = false;
        anim = GetComponent<Animator>();
    }

    public void CreSwitch()
    {
        anim.SetTrigger("doorOpen");
    }

    public void Exit()
    {
        Application.Quit();
    }
}