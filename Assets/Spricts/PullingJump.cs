using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    [SerializeField]
    private float JumpPower = 10;

    private bool isCanJump;
    
    private void OnCollisionStay(Collision collision){

        // 衝突している点の情報が複数格納されている
        ContactPoint[] constacts = collision.contacts;

        // 0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = constacts[0].normal;

        // 上方向を示すベクトル、長さは1；
        Vector3 upVector = new Vector3(0,1,0);

        // 上方向と法線と内積。二つのベクトルはともに長さが1なので、cosθの結果がdotUN変数に入る
        float dotUN = Vector3.Dot(upVector,otherNormal);

        // 内積地に逆三角関数arccosをかけて角度を算出。それを度数法へ変換する。角度が算出できた
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        //二つのベクトルがなす角度が４５度より小さければ、もう一度ジャンプをすることが可能
        if(dotDeg <= 45){
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision){
        isCanJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックしたら
        if(Input.GetMouseButtonDown(0)){
            //マウスの座標をクリックした座標に代入する
            clickPosition = Input.mousePosition;
        }

        //離したら
        if(isCanJump && Input.GetMouseButtonUp(0)){
            //クリックした座標と話した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;
            //クリックとリリースが同じ座標ならば無視
            if(dist.sqrMagnitude == 0){return;}

            //差分を標準化し,jumpPowerを掛け合わせた値を移動量とする
            rb.velocity = dist.normalized * JumpPower;
        }

    }
}
