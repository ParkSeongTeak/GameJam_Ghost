using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.


public class Act_Inact : MonoBehaviour
{
    public GameObject This; 
    public void Active()
    {
        This.active = true;
    }

    public void Inactive()
    {
        This.active = false;
    }
 }
