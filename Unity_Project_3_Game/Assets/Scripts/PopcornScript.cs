using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornScript : MonoBehaviour
{
    
    public AudioSource sound;
    public ParticleSystem prt;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.IncPopcornCount();
        StartCoroutine("Grabbed");
    }

    IEnumerator Grabbed()
    {
        prt.Play();
        SpriteRenderer spr = gameObject.GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D bc = gameObject.GetComponentInChildren<BoxCollider2D>();
        bc.enabled = false;
        spr.enabled = false;
        sound.Play();
        yield return new WaitForSeconds(prt.main.duration * 2);
        Destroy(gameObject);
    }
}
