using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
     
    public int NumberOfHearts { get; private set; }

    public Text heartsCollected;
    
    public void HeartCollected()
    {
        NumberOfHearts++;
    }

    public void updateHeartsText()
    {
        heartsCollected.text= "";
        heartsCollected.text+= NumberOfHearts;
    }
    
}
