using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public Animator thisAnimator;
    
    public void ThisDisable()
    {
        this.gameObject.SetActive(false);
    }

    public void AnimDisable()
    {
        thisAnimator.Play("InfoCard-Close");
    }
}
