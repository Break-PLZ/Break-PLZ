using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{

    GameObject background, canvas;
    float background_left, background_right, background_up, background_down;

    bool isActive = true;

    void Start()
    {
        background = GameObject.FindWithTag("Background");
        canvas = GameObject.FindWithTag("Player");

        float canvas_scale_x = canvas.GetComponent<RectTransform>().rect.width* canvas.transform.localScale.x;
        float canvas_scale_y = canvas.GetComponent<RectTransform>().rect.height* canvas.transform.localScale.y;

        float scale_x = background.transform.localScale.x;
        float scale_y = background.transform.localScale.y;

        background_left = background.transform.position.x - scale_x / 2 + canvas_scale_x / 2;
        background_right = background.transform.position.x + scale_x / 2 - canvas_scale_x / 2;
        background_up = background.transform.position.y + scale_y / 2 - canvas_scale_y / 2;
        background_down = background.transform.position.y - scale_y / 2 + canvas_scale_y / 2;
    }

    void Update()
    {
        if (isActive)
        {
            if (!Input.GetMouseButton(0))
                return;

            if (Input.GetAxis("Mouse X") < 0)
            {
                if (transform.position.x < background_right)
                    transform.Translate(0.07f, 0, 0);
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                if (transform.position.x > background_left)
                    transform.Translate(-0.07f, 0, 0);
            }

            if (Input.GetAxis("Mouse Y") < 0)
            {
                if (transform.position.y < background_up)
                    transform.Translate(0, 0.07f, 0);
            }
            else if (Input.GetAxis("Mouse Y") > 0)
            {
                if (transform.position.y > background_down)
                    transform.Translate(0, -0.07f, 0);
            }
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }

    public void Activate()
    {
        isActive = true;
    }
}