using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void GoToMain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }

   public void GoToCreds() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

   public void GoToHTP() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
   }

   
}
