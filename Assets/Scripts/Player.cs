using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hAxis; // x�� ����Ű �Է� �� ���� ��

    private bool jDown; // ���� Ű �Է½� ���� ��

    private bool isJump = false; //���� ���� �Ǻ� ����

    [SerializeField]
    private float speed; // �ӷ�
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

    // �Է°� �Լ�
    private void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        jDown = Input.GetButtonDown("Jump");
    }

    // �̵� �Լ�
    private void Move()
    {
        moveVec = new Vector3(hAxis, 0, 0);

        transform.position += moveVec * speed * Time.deltaTime;
    }

    // ���� �Լ�
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
