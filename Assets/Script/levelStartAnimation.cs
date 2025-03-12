using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelStartAnimation : MonoBehaviour
{
    [SerializeField] TMP_Text waveName;
    [SerializeField] Animator anim;

    public void SetText(string levelName)
    {
        waveName.text = levelName;
    }
}
