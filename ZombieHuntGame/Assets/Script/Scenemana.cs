using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemana : MonoBehaviour {

    public void Sceneman(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
