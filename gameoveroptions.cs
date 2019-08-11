using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoveroptions : MonoBehaviour {
    public void Tryagain(){
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits(){
        SceneManager.LoadScene(5);
    }

}
