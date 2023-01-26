using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private GameManager gameManager;

    // title Screens
    public GameObject BalloonTitle;
    public GameObject VroomTitle;
    public GameObject PerryTitle;
    void Start()
    {
        
    }

    public void StartButton()
    {
        if(BalloonTitle.gameObject.activeSelf)
        { SceneManager.LoadScene("BalloonGame"); }
        else if(VroomTitle.gameObject.activeSelf)
        { SceneManager.LoadScene("VroomVroom"); }
        else if(PerryTitle.activeSelf)
        { SceneManager.LoadScene("perry the plat ypus"); }
    }

    public void BackToScene()
    { gameObject.SetActive(false); }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {
                    // open menu with correct name
                    gameObject.SetActive(true);

                    if(gameObject.tag == "balloon")
                    {
                        // activate title
                        BalloonTitle.gameObject.SetActive(true);
                    }
                    else if(gameObject.tag == "VroomVroom")
                    {
                        // activate title
                        VroomTitle.gameObject.SetActive(true);
                    }
                    else if(gameObject.tag == "perry the plat ypus")
                    {
                        // active title
                        PerryTitle.gameObject.SetActive(true);
                    }
                }
            }
        }

        // quit: Application.Quit();
    }
}
