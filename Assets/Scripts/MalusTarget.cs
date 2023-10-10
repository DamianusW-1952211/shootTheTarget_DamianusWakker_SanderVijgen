using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalusTarget : MonoBehaviour
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
            Player.GetComponent<PlayerManager>().GameOver();
            Object.Destroy(this.gameObject);
        }
    }
    void BlowUp()
    {
        Debug.Log("BlowUp");
        Object.Destroy(this.gameObject);
    }
    public void SetPlayer(GameObject player)
    {
        Player = player;
    }
}
