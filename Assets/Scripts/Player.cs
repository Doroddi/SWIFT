using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hAxis; // x축 방향키 입력 시 저장 값

    private bool jDown; // 점프 키 입력시 저장 값

    private bool isJump = false; //점프 상태 판별 변수

    [SerializeField]
    private float speed; // 속력
    [SerializeField]
    private float jumpPower;

    Vector3 moveVec;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
    }

    // 입력값 함수
    private void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        jDown = Input.GetButtonDown("Jump");
    }

    // 이동 함수
    private void Move()
    {
        moveVec = new Vector3(hAxis, 0, 0);

        transform.position += moveVec * speed * Time.deltaTime;
    }

    // 점프 함수
    private void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
