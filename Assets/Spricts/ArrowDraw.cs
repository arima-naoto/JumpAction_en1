using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]

    private Image arrowImage;//矢印の画像

    private Vector3 clickPosition;//クリックした座標

    // Start is called before the first frame update
    void Start()
    {
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックしたら
        if (Input.GetMouseButtonDown(0))
        {
            //マウスの座標をクリックした座標に代入する
            clickPosition = Input.mousePosition;

            //arrowImageを有効化にする
            arrowImage.gameObject.SetActive(true);
        }

        //右クリックしている間
        if (Input.GetMouseButton(0))
        {
            //ベクトルの長さを算出
            Vector3 dragVector = clickPosition - Input.mousePosition;
            
            //ベクトルから角度(孤度法)を算出
            float size = dragVector.magnitude;

            //矢印の画像をクリックした場所に画像を移動
            float angleRad = Mathf.Atan2(dragVector.y, dragVector.x);

            //矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
            arrowImage.rectTransform.position = clickPosition;

            //矢尻氏の画像の大きさをドラッグした距離に合わせる
            arrowImage.rectTransform.rotation
                = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);

            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);


        }

        //はなしたら
        if (Input.GetMouseButtonUp(0))
        {
            //arrowImageを無効化にする
            arrowImage.gameObject.SetActive(false);
        }

    
    }
}