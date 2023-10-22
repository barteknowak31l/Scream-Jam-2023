using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private Animator anim;
    public int sceneToLoad;
    public AudioSource elevator;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Transition()
    {
        anim.Play("start");
        if(elevator != null)
        elevator.Play();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        Destroy(this);
    }

}
