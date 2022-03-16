using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Boxstudio.RobotRun.Utils;
using Boxstudio.RobotRun.Managers;

public class EndLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        string otherTag = other.gameObject.tag;
        if(otherTag == TagsUtils.PLAYER){
            LevelManager.instance.EndLevel();
        }
    }

}
