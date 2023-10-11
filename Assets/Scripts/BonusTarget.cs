using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTarget : MonoBehaviour

{
    [SerializeField]
    private AudioSource targetHitSound;
    GameObject Player;
    float count_after_start = 0.0f;
    int count_to_blow = 6;
    bool geschoten = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count_after_start >= count_to_blow)
        {
            BlowUp();
        }
        count_after_start += Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets") && geschoten == false)
        {
            targetHitSound.Play();
            string collisionString = collision.gameObject.name;
            Debug.Log(collisionString);
            collision.gameObject.SetActive(false);
            float positieX = collision.gameObject.transform.position.x;
            float positieY = collision.gameObject.transform.position.y;
            float DPTime;
            float pitago = Mathf.Sqrt((positieX - transform.position.x) * (positieX - transform.position.x)+ (positieY - transform.position.y) * (positieY - transform.position.y));
            if (pitago < 0.8)
            {
                DPTime = 15;
            }
            else if (pitago < 0.30)
            {
                DPTime = 10;
            }
            else if (pitago < 0.36)
            {
                DPTime = 7;
            }
            else if (pitago < 0.38)
            {
                DPTime = 5;
            }
            else
            {
                DPTime = 0;
            }

            Player.GetComponent<PlayerManager>().DubblePoints(DPTime);
            geschoten = true;
            count_after_start = 0;
            Object.Destroy(this.gameObject);
        }

    }
    void BlowUp()
    {
        
        Player.GetComponent<PlayerManager>().Ontploft();
        Debug.Log("BlowUp");
        Object.Destroy(this.gameObject);
    }
    public void SetPlayer(GameObject player)
    {
        Player = player;
    }
}
