using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void CarStart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);

    }
}
