using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Cam : LivingEntity
{
    public GameObject enemy; // 적
    public GameObject objWeapon; // 무기
    public Camera cam; // 카메라
    public float camSpd; // 카메라 스피드
    public float movSpd; // 이동 속도
    Rigidbody ridBody;
    Vector3 vec = new Vector3(0, 0, 0);
    Vector3 tmp;
    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    public int[] energy = new int[3] { 0, 0, 0 };
    int[] weapon = new int[3] { 0, 0, 0 };
    int[,] reqWeapon = new int[3, 3] { { 2, 1, 1 }, { 1, 2, 1 }, { 1, 1, 2 } };
    public int selWeapon = -1;
    public float dmg = 1f;
    public GameObject A;

    public override void Start()
    {
        base.Start();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ridBody = GetComponent<Rigidbody>();
        n = 0;
    }
    void Update()
    {
        CamRotate();
        CamMove();

        if (selWeapon != -1)
        {
            if ((weapon[selWeapon] <= 0))
            {
                selWeapon = -1;
            }
        }

        tmp = ridBody.transform.position;
        tmp.y += 0.25f;
        cam.transform.position = Vector3.Lerp(cam.transform.position, tmp, 1);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            A.GetComponent<UiFinal>().enabled = true;
            A.GetComponent<UiFinal>().FocusOn();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selWeapon == -1)
            {
                if (weapon[0] >= 1)
                {
                    selWeapon = 0;
                }
                else if (weapon[1] >= 1)
                {
                    selWeapon = 1;
                }
                else if (weapon[2] >= 1)
                {
                    selWeapon = 2;
                }
            }
            if (selWeapon == 0)
            {
                if (weapon[1] >= 1)
                {
                    selWeapon = 1;
                }
                else if (weapon[2] >= 1)
                {
                    selWeapon = 2;
                }
            }
            else if (selWeapon == 1)
            {
                if (weapon[2] >= 1)
                {
                    selWeapon = 2;
                }
                else if (weapon[0] >= 1)
                {
                    selWeapon = 0;
                }
            }
            else if (selWeapon == 2)
            {
                if (weapon[0] >= 1)
                {
                    selWeapon = 0;
                }
                else if (weapon[1] >= 1)
                {
                    selWeapon = 1;
                }
            }
        }

        Ray ray = cam.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 15f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    if (selWeapon != -1)
                    {
                        if (selWeapon == 0)
                        {
                            dmg = 5f;
                        }
                        else if (selWeapon == 1)
                        {
                            dmg = 10f;
                        }
                        else if (selWeapon == 2)
                        {
                            dmg = 20f;
                        }
                        weapon[selWeapon] -= 1;
                        hit.transform.gameObject.GetComponent<LivingEntity>().TakeHit(dmg);
                    }
                }
                else if (hit.transform.gameObject.tag == "Chest")
                {
                    energy[0] += (int)Random.Range(0, 2);
                    energy[1] += (int)Random.Range(0, 2);
                    energy[2] += (int)Random.Range(0, 2);
                }
            }
        }
    }
    void CamRotate() // 마우스로 화면 돌리는 함수
    {
        vec += new Vector3(-Input.GetAxis("Mouse Y") * camSpd, Input.GetAxis("Mouse X") * (camSpd * 1.7f), 0);

        vec.x = Mathf.Clamp(vec.x, -60, 60);
        cam.transform.localEulerAngles = vec;
        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    ridBody.velocity += new Vector3(0, 6, 0);
        //}
    }
    void CamMove() // 플레이어 이동
    {
        Vector3 forward = Vector3.Cross(cam.transform.right, Vector3.up);
        Vector3 right = Vector3.Cross(cam.transform.up, cam.transform.forward);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(forward * Time.deltaTime * movSpd);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-right * Time.deltaTime * movSpd);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-forward * Time.deltaTime * movSpd);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(right * Time.deltaTime * movSpd);
        }
    }
    //bool IsGrounded() // 점프
    //{
    //return Physics.Raycast(transform.position, -Vector3.up, 1);
    //}
    public void MakeWeapon(int a, int b, int c) // 무기 생성
    {
        for (int i = 0; i < 3; i++)
        {
            if ((reqWeapon[i, 0] == a) && (reqWeapon[i, 1] == b) && (reqWeapon[i, 2] == c) && (energy[0] > a) && (energy[1] > b) && (energy[2] > c))
            {
                energy[0] -= a; energy[1] -= b; energy[2] -= c;
                weapon[i] += 1;
            }
        }
    }
}