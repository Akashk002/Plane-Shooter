using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelStartAnimation : MonoBehaviour
{
    public TMP_Text waveName;
    public Animator anim;

    public void SetText(string levelName)
    {
        waveName.text = levelName;
    }
}
