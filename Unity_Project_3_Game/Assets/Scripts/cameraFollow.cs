using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;

    public float boundaryPercent;
    public float easing;

    private float leftBound;
    private float rightBound;
    private float upBound;
    private float downBound;


    // Start is called before the first frame update
    void Start()
    {
        leftBound = boundaryPercent * Camera.main.pixelWidth + 200;
        rightBound = Camera.main.pixelWidth - leftBound;
        downBound = boundaryPercent * Camera.main.pixelHeight + 200;
        upBound = Camera.main.pixelHeight - downBound;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 spriteLoc = Camera.main.WorldToScreenPoint(player.transform.position);

            Vector3 pos = transform.position;

            if (spriteLoc.x < leftBound)
            {
                pos.x -= leftBound - spriteLoc.x;
            }
            else if (spriteLoc.x > rightBound)
            {
                pos.x += spriteLoc.x - rightBound;
            }

            if (spriteLoc.y < downBound)
            {
                pos.y -= downBound - spriteLoc.y;
            }
            else if (spriteLoc.y > upBound)
            {
                pos.y += spriteLoc.y - upBound;
            }

            pos = Vector3.Lerp(transform.position, pos, easing);

            transform.position = pos;
        }
    }
}
