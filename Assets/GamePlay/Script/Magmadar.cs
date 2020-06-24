using System;
using UnityEngine;
using System.Collections;

public class Magmadar : MonoBehaviour {

    /// <summary>
    /// 这是那个神兽的脚本
    /// </summary>
    //The box's current health point total
    public int currentHealth = 3;
    private  GameObject target;
    private CharacterController cc;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        target = GameObject.Find("SciFiWarriorHP");
    }
    
    void Update()
    {
        //向着主角移动
        transform.LookAt(target.transform);
        cc.SimpleMove(transform.forward * 1.8F);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag=="Player")
        {
            Destroy(other.collider.gameObject);
        } 
    }

    public void Damage(int damageAmount)
    {
        //被攻击减少血量
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            gameObject.SetActive (false);
        }
    }
}