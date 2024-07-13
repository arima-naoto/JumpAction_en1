using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerScript : MonoBehaviour
{
    

    [SerializeField]
    //次のシーンに遷移する変数を用意
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280,720,false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
