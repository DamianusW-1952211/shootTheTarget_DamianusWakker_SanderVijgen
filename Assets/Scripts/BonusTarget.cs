using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTarget : MonoBehaviour

{
    [SerializeField]
    private AudioSource targetHitSound;
    GameObject Player;
    float count_after_start = 0.0f;
    int count_to_blow = 4;
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {
            targetHitSound.Play();
            string collisionString = collision.gameObject.name;
            Debug.Log(collisionString);
            collision.gameObject.SetActive(false);
            int positieX = (int)collision.gameObject.transform.position.x;
            int positieY = (int)collision.gameObject.transform.position.y;

            int DPTime;
            float pitago = Mathf.Sqrt((positieX - (int)transform.position.x) ^ 2 + (positieY - (int)transform.position.y) ^ 2);
            if (pitago < 0.06)
            {
                DPTime = 100;
            }
            else if (pitago < 0.12)
            {
                DPTime = 50;
            }
            else if (pitago < 0.18)
            {
                DPTime = 30;
            }
            else if (pitago < 0.24)
            {
                DPTime = 15;
            }
            else
            {
                DPTime = 0;
            }
            Player.GetComponent<PlayerManager>().DubblePoints(DPTime);
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
