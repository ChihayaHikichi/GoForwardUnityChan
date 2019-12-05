using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

        // キューブの移動速度
        private float speed = -12;

        // 消滅位置
        private float deadLine = -10;

        // 既に衝突音を出したか
        private bool SoundFlag = false;

        // 音源を設定
        //private AudioClip SoundBlock;
        private AudioSource audioSource;
        //private AudioClip SoundBlock;



    // Use this for initialization
    void Start(){

            //Componentを取得
            audioSource = GetComponent<AudioSource>();

    }

        // Update is called once per frame
        void Update () {
                // キューブを移動させる
                transform.Translate (this.speed* Time.deltaTime, 0, 0);

                // 画面外に出たら破棄する
                if (transform.position.x < this.deadLine){
                        Destroy (gameObject);
                }
        }



	    //衝突時に呼ばれる関数
        void OnCollisionEnter2D(Collision2D other) {
		
		// ユニティちゃん以外と衝突したら音を鳴らす
                if (other.gameObject.tag != "UnityChan" && SoundFlag == false) {
                    //audioSource.PlayOneShot(SoundBlock);
                    audioSource.PlayOneShot(audioSource.clip);

                // 音を出したのでフラグを立てる
                SoundFlag = true;

                    //Debug.Log("True");
        }
                else {

                    //Debug.Log("Else");

                }
        }
}