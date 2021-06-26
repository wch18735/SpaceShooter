using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f; // Inspector에도 표시되며 이를 바꾸면 소스코드에도 반영된다
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {

        /*
           Input 클래스
            - Keyboard, Mouse, Screen, JoyStick, VR Controller
            - 전진, 후진 -> Vertical
            - 좌, 우 -> Horizontal
        */
        float v = Input.GetAxis("Vertical"); // W, S, Up, Down // -1.0f ~ 0.0f ~ +1.0f
        float h = Input.GetAxis("Horizontal"); // A, D, Left, Right // -1.0f ~ 0.0f ~ +1.0f
        Debug.Log($"h={h}, v={v}");

        //transform.Translate(Vector3.forward * 0.1f * v); // Vector3.forward = new Vector3(0, 0, 1)
        //transform.Translate(Vector3.right * 0.1f * h);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f); // Fade blending, Blending Time
        }
        else if(v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if(h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if(h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.1f);
        }
    }
}

/*  단위벡터 (Unit Vector), 정규화 벡터 (Normalized Vector)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up = Vector3(0, 1, 0)
            Vector3.right = Vector3(1, 0, 0)
            
        나머지 direction은 왼손 좌표계 기준 -를 붙여서 사용한다.

            Vector3.one = Vector3(1,1,1)
            Vector3.zero = Vector3(0,0,0)
*/