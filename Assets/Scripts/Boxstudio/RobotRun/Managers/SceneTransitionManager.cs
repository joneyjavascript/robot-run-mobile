

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Boxstudio.RobotRun.Utils;

namespace Boxstudio.RobotRun.Managers {

  public class SceneTransitionManager : MonoBehaviour {

    public static SceneTransitionManager instance;

    [SerializeField] float _time = 1f;
    [SerializeField] Image _backgroundPanelImage;

    string _newSceneName = SceneUtils.GAMEPLAY;
    float _percent = 0;

    void Awake(){
      if(instance == null){
        instance = this;
      }
    }

    void Update(){
      UpdateAlpha();
    }

    public void TransitionTo(string newSceneName){
      _newSceneName = newSceneName;
      StartCoroutine(SceneTransition());
    }

    IEnumerator SceneTransition(){
      WaitForEndOfFrame nextFrame = new WaitForEndOfFrame();
      _percent = 0;
      while(_percent <= 1f){
        _percent += Time.deltaTime * _time;
        yield return nextFrame;
      }
      _percent = 1f;

      AsyncOperation loading = SceneManager.LoadSceneAsync(_newSceneName);
      while (!loading.isDone)
      {
          yield return nextFrame;
      }

      while(_percent > 0f){
        _percent -= Time.deltaTime * _time;
        yield return nextFrame;
      }
      _percent = 0f;

      yield return null;
    }

    void UpdateAlpha(){
      Color newColor = _backgroundPanelImage.color;
      newColor.a = _percent;
      _backgroundPanelImage.color = newColor;
    }
  }
}
