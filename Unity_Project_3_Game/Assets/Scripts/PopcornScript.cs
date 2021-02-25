using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornScript : MonoBehaviour
{
    
    public AudioSource sound;
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
        SpriteRenderer spr = gameObject.GetComponentInChildren<SpriteRenderer>();
        spr.enabled = false;
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length);
        Destroy(gameObject);
    }
}
