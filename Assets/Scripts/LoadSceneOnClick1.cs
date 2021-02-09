using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick1 : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
       SceneManager.LoadScene(sceneName);
   }

   void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
