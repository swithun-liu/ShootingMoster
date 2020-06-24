using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactor : MonoBehaviour
{

    /// <summary>
    /// 这是主角
    /// </summary>
    
    public float rotate_speed = 5;
    public float speed=3;

    CharacterController cc;
    Animator animator;
    new Camera camera;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        camera = GetComponent<Camera>();
    }
    //人物移动函数
    public void move(Vector3 v)    
    {
        Vector3 movement = v * speed;
        cc.SimpleMove(movement);
    }
}
