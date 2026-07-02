using UnityEngine;

public enum Gamestate
{
    Gameplay,
    Paused
}

public class Gamemanager : MonoBehaviour
{

    public Gamestate currentstate;
    bool stateChangingThisFrame;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentstate = Gamestate.Gameplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (stateChangingThisFrame)
        {
            if(currentstate == Gamestate.Paused)
            {
                Time.timeScale = 0f;
            }
            else if (currentstate == Gamestate.Gameplay)
            {
                Time.timeScale = 1f;
            }

            stateChangingThisFrame = false;

        }
    }
    public void TogglePause()
    {
        if (currentstate == Gamestate.Gameplay)
        {
            
            
                currentstate = Gamestate.Paused;
                stateChangingThisFrame = true;
            
        }
        else if (currentstate == Gamestate.Paused)
        {
            
            
          currentstate = Gamestate.Gameplay;
          stateChangingThisFrame = true;
            
        }
    }
}
