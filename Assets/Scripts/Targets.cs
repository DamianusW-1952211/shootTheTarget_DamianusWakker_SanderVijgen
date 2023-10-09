using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject color;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Camera cam;
    int count_after_start = 0;
    int count_to_blow = 600;

    // Start is called before the first frame update
    void Start()
    {
        cam.targetTexture.Release();
        color.SetActive(true);
        target.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (count_after_start == 1)
        {
            color.SetActive(false);
            target.SetActive(false);
        }
        if (count_after_start == count_to_blow)
        {
            BlowUp();
        }
        count_after_start ++;
    }
    void OnCollisionEnter(Collision collision){  
    
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullets")){
            string collisionString = collision.gameObject.name;
            Debug.Log(collisionString);
            collision.gameObject.SetActive(false);
            Vector3 positie = collision.gameObject.transform.position;
            Debug.Log(positie);
            Player.GetComponent<PlayerManager>().DubblePoints(5);
            Player.GetComponent<PlayerManager>().IsRaak(2);
        }
    }
    void BlowUp(){
        Player.GetComponent<PlayerManager>().Ontploft();
        //Player.Ontploft();
        Debug.Log("BlowUp");
        count_after_start ++;
        //infvsetActive(false);
    }
    
}
