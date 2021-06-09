using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public AnimationClip animClip;
    public float aditionalTime;

    private void Start()
    {
        Invoke("NextScene", animClip.length + aditionalTime);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
