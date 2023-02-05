using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{


  [SerializeField] private String sceneName;
  
  public void ChangeScenePlayer()
  {
    SceneManager.LoadScene(sceneName);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      ChangeScenePlayer();
    }
  }
}
