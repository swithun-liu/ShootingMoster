using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    /// <summary>
    /// 主角的控制器
    /// </summary>
    
    PlayerCharactor charactor;
    Animator animator;
    public  float rotateSpeed = 3.0F;
    private AudioSource gunAudio;


    void Awake()
    {
        charactor = GetComponent<PlayerCharactor>();
        animator = GetComponent<Animator>();
        gunAudio = GetComponent<AudioSource>();
        gunAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.visible=false;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //以世界坐标为参考
        Vector3 move_direction = new Vector3(h, 0, v);
        //转换为以自身坐标轴为参考
        Vector3 current_direction = transform.TransformPoint(move_direction) - transform.position;
        //调用人物的移动函数
        charactor.move(current_direction);
        //根据输入的方向键播放动画
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("left", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("right", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("back", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run",true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            gunAudio.Play();
            animator.SetBool("shoot", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("walk",false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("left",false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("right",false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("back",false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("run",false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            gunAudio.Stop();
            animator.SetBool("shoot",false);
        }
    }
}