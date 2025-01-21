using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murer : MonoBehaviour
{
    public void MuteToggle(bool muted)
    {
        // when clicked on mute, it turns volume to 0
        if (muted) 
        {
            AudioListener.volume = 0;
        }
        // when not clicked on mute, it turns volume to normal
        else
        {
            AudioListener.volume = 1;
        }
    }
}
