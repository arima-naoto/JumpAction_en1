using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isMoving = false;

    //プレイヤーを移動させる関数
    void MovePlayer(){
        transform.Translate(Vector3.right *speed * Time.deltaTime);
    }

    //もし自動床ではない場合、等速直線運動はさせない
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("StepWall")){
            isMoving = false;
        }
    }

    //プレイヤーの自動移動を開始する関数
    public void StartMoving(){
        isMoving = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true){
            MovePlayer();
        }
    }
    
}
