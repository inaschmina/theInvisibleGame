using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    void Start()
    {

    }

    public void QuitApp()
    { Application.Quit(); }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // create a ray at the touch position
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // check if the object hit is the same as the current object
                if (hit.transform == this.transform)
                {
                    if (hit.transform.tag == "balloon")
                    {
                        Debug.Log("In balloon");
                        SceneManager.LoadScene("Balloon Game");
                    }
                    else if (hit.transform.tag == "VroomVroom")
                    {
                        Debug.Log("In Vroom");
                        SceneManager.LoadScene("Vroom Vroom");
                    }
                    else if (hit.transform.tag == "perry the plat ypus")
                    {
                        Debug.Log("In perry");
                        SceneManager.LoadScene("Perry the plat ypus");
                    }
                }
            }


            // quit: Application.Quit();
        }
    }
}
