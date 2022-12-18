using UnityEngine;

public class SoundManager_3 : MonoBehaviour
{
    public AudioSource _Sound;
    public AudioSource _Music;
    public AudioClip buttonScaleUp, buttonScaleDown, correct, inCorrect, gainStar,click;
    public AudioClip music;

    private void Start()
    {
        _Sound.volume = 0.6f;
        _Music.volume = 0.6f;
    }
    public void Click() 
    {
        _Sound.PlayOneShot(click);
    }

    public void StarGain() 
    {
        _Sound.PlayOneShot(gainStar);
    }

    public void Correct() 
    {
        _Sound.PlayOneShot(correct);
    }

    public void Incorrect() 
    {
        _Sound.PlayOneShot(inCorrect);
    }

    public void ButtonScaleDown() 
    {
        _Sound.PlayOneShot(buttonScaleDown);
    }

    public void ButtonScaleUp()
    {
        _Sound.PlayOneShot(buttonScaleUp);
    }

    public void SwitchOff() 
    {
        _Sound.mute = true;
        _Music.mute = true;
    }

    public void SwitchOn()
    {
        _Sound.mute = false;
        _Music.mute = false;
    }
}
