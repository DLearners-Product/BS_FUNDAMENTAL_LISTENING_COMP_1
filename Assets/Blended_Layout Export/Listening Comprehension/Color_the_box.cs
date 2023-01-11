using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Color_the_box : MonoBehaviour
{
    public GameObject G_selected;
    public Color color;
    public AudioSource AS_Wrong,AS_sound;
    public GameObject selectedcolor;

    // Start is called before the first frame update
    void Start()
    {
        color = Color.white;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "color")
                {
                    Debug.Log(hit.collider.name);
                    color = hit.collider.gameObject.GetComponent<Image>().color;
                    G_selected = hit.collider.gameObject;
                    selectedcolor.GetComponent<Image>().color = color;
                    // selectedcolor.gameObject.GetComponent<Image>().color = color;
                    // hit.collider.gameObject.transform.localScale = new Vector2(1.1f, 1.1f);
                    //hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                    AS_sound.Play();
                }


                if (hit.collider.gameObject.tag == "docolor")
                {
                    Debug.Log(hit.collider.name);
                    if (G_selected.name == "brown")
                    {
                        if (hit.collider.gameObject.name == "deer")
                        {
                            hit.collider.gameObject.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "yellow")
                    {
                        if (hit.collider.gameObject.name == "house")
                        {
                            hit.collider.gameObject.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "blue")
                    {
                        if (hit.collider.gameObject.name == "bird")
                        {
                            hit.collider.gameObject.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "green")
                    {
                        if (hit.collider.gameObject.name == "tree")
                        {
                            hit.collider.gameObject.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "orange")
                    {
                        if (hit.collider.gameObject.name == "fish")
                        {
                            hit.collider.gameObject.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "black")
                    {
                        if (hit.collider.gameObject.name == "cloud")
                        {
                            hit.collider.gameObject.SetActive(false);
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                    if (G_selected.name == "red")
                    {
                        if (hit.collider.gameObject.name == "roof")
                        {
                            hit.collider.gameObject.SetActive(false);
                        }
                        else
                        {
                            AS_Wrong.Play();
                        }
                    }
                }
                if (hit.collider.gameObject.tag == "Untagged")
                {
                    hit.collider.GetComponent<AudioSource>().Play();
                }
                

            }
        }
    }
}
