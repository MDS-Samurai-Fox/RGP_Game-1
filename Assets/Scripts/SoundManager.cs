using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [HeaderAttribute("Audio Sources")]
    public AudioSource source;
    public AudioSource jetpackSource;

    [HeaderAttribute("Sound Effects")]
    public AudioClip Lever;
    public AudioClip Button;
    public AudioClip JoinSplit;
    public AudioClip Intro;
    public AudioClip Finish;
    public AudioClip Buoyancy;
	
	// Jetpack variables
	bool hasPlayedJetpackSound = false;

    public void Play(ClipType _clip) {

        switch (_clip) {
            case ClipType.Jetpack:
			{
                jetpackSource.Play();
                if (!hasPlayedJetpackSound) {
                    jetpackSource.DOFade(1, 0);
                    hasPlayedJetpackSound = true;
                    // jetpackSource.DOFade(1, 0.15f).OnComplete(jetpackActivate);
                }
			}
                break;
            case ClipType.Lever:
                source.PlayOneShot(Lever);
                break;
            case ClipType.Button:
                source.PlayOneShot(Button);
                break;
            case ClipType.JoinSplit:
                source.PlayOneShot(JoinSplit);
                break;
            case ClipType.Intro:
                source.PlayOneShot(Intro);
                break;
            case ClipType.Finish:
                source.PlayOneShot(Finish);
                break;
            case ClipType.Buoyancy:
                source.PlayOneShot(Buoyancy);
                break;
            default:
                break;
        }

    }

    public void StopSource() {
        source.Stop();
    }

    public void StopJetpackSource() {
        if (hasPlayedJetpackSound) {
            jetpackSource.DOFade(0, 0.25f).OnComplete(JetpackShutdown);
            hasPlayedJetpackSound = false;
        }
    }

    void jetpackActivate() {
        hasPlayedJetpackSound = true;
    }
    
    void JetpackShutdown() {
        jetpackSource.Stop();
    }

}