using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class RaycastShoot : MonoBehaviour
{

    /// <summary>
    ///  这是发射子弹的脚本
    /// </summary>
    
    
    public int gunDamage = 1;                                           
    public float fireRate = 0.25f;                                      
    public float weaponRange = 50f;                                     
    public float hitForce = 100f;                                       
    public Transform gunEnd;                                            

    private Camera fpsCam;                                              
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    
    private AudioSource gunAudio;                                     
    private LineRenderer laserLine;                                     
    private float nextFire;                                             


    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();

        gunAudio = GetComponent<AudioSource>();

        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            laserLine.enabled = true;
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {

                Magmadar health = hit.collider.GetComponent<Magmadar>();
                
                laserLine.SetPosition(1, hit.point);

                if (health!=null)
                {
                    health.Damage(gunDamage);
                }
                
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            laserLine.enabled = false;
        }
    }


}