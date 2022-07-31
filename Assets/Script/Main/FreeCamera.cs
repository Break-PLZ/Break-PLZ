using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{

    GameObject background, canvas;
    float background_left, background_right, background_up, background_down;
    float speed=0.2f;
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
            if(isActive){
                if (!Input.GetMouseButton(0)) return;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if(hit.collider!=null) return;

                float mx=Input.GetAxis("Mouse X");
                float my=Input.GetAxis("Mouse Y");

                if (mx < 0)
                {
                    if (transform.position.x < background_left)
                        transform.Translate(-speed*mx, 0, 0);
                }
                else if (mx > 0)
                {
                    if (transform.position.x > background_right)
                        transform.Translate(-speed*mx, 0, 0);
                }

                if (my < 0)
                {
                    if (transform.position.y < background_down)
                        transform.Translate(0, -speed*my, 0);
                }
                else if (my > 0)
                {
                    if (transform.position.y > background_up)
                        transform.Translate(0, -speed*my, 0);
                }
            }
        //}
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