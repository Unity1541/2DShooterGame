using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void LoadScene()
   {
        SceneManager.LoadScene("SpaceShoter");
        Debug.Log("Loading scene: " + "SpaceShoter");
   }
}
