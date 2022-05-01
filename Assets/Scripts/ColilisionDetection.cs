using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColilisionDetection : MonoBehaviour
{
    public PlayerMovimentation pm;
    public WeaponController wc;
    public GameObject HitParticle;
    public AudioClip WalkingDungeon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.IsAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");

            Instantiate(HitParticle, new Vector3(other.transform.position.x,
            transform.position.y, other.transform.position.z),
            other.transform.rotation);
        }
        if(other.tag == "Dungeon")
        {
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(WalkingDungeon);
        }
    }
}
