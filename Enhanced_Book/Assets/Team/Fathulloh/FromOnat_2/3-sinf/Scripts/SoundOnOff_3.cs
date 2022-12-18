using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff_3 : MonoBehaviour
{
    SoundManager_3 soundManager;
    public Button button;
    public Sprite soundOn;
    public Sprite soundOn_Pressed;
    public Sprite soundOff;
    public Sprite soundOff_Pressed;
    public bool soundIsOn;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_3>();
        soundIsOn = true;
    }

    public void ChangeSprite() 
    {
        if (soundIsOn) 
        {
            button.image.sprite = soundOff;
            soundIsOn = false;
            soundManager.SwitchOff();
        }
        else 
        {
            button.image.sprite = soundOn;
            soundIsOn = true;
            soundManager.SwitchOn();
        }
    }
}
