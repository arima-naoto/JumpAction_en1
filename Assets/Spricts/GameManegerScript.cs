using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerScript : MonoBehaviour
{
    //次のシーンに遷移する変数を用意
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SPACEキーが押された瞬間
        if(Input.GetKeyDown(KeyCode.Space)){
            //次のシーンに遷移する
            SceneManager.LoadScene(nextSceneName);
        }        
    }
}
