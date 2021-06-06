using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShootingScript : MonoBehaviour
{
    PhotonView view; 

    public GameObject Bullet;  //bullet: dan co the thay doi bang object khac

    public int force = 30; 


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.isMine && Input.GetKeyDown(KeyCode.Space))
        {
            view.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPosition").transform.position, transform.Find("ShootPosition").transform.rotation);
            
        }
    }

    [PunRPC]
    void shootBullet(Vector3 pos, Quaternion quaat)
    {
        GameObject GO = Instantiate(Bullet, pos, quaat) as GameObject; 
        GO.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
    }
}
