using UnityEngine;
using System.Collections;

public class RayViewer : MonoBehaviour
{

    // Debug.DrawRay绘制的Unity单位
    public float weaponRange = 50f;

    // FPS相机
    private Camera fpsCam;


    void Start()
    {
        // 获取Camera组件
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        // 创建相机位置至视口中心点的向量
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // 在场景视图中绘制lineOrigin到相机前方武器射程处的射线
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
    }
}