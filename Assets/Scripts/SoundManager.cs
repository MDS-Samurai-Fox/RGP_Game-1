using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [HeaderAttribute("Audio Sources")]
    public AudioSource effectSource;
    public AudioSource jetpackSource;
    public AudioSource musicSource;

    [HeaderAttribute("Sound Effects")]
    public AudioClip Lever;
    public AudioClip Button;
    public AudioClip Join;
	public AudioClip Split;
    public AudioClip BlastStart;
    public AudioClip BlastEnd;
    public AudioClip Finish;
    public AudioClip Timer;
    public AudioClip Buoyancy;

    // Jetpack variables
    bool hasPlayedJetpackSound = false;
    Tween jetpackFadeIn, jetpackFadeOut;

    void Start() {

       jetpackSource.volume = 0;

    }

    public void Play(ClipType _clip) {

        switch (_clip) {
            case ClipType.Jetpack:
                {
					
                    jetpackFadeOut.Kill(false);
                    jetpackSource.Play();
                    jetpackFadeIn = jetpackSource.DOFade(1, 1);

                    if (!hasPlayedJetpackSound) {
                        hasPlayedJetpackSound = true;
                    }
                }
                break;
            case ClipType.Lever:
                effectSource.PlayOneShot(Lever);
                break;
            case ClipType.Button:
                effectSource.PlayOneShot(Button);
                break;
            case ClipType.Join:
                effectSource.PlayOneShot(Join);
                break;
			case ClipType.Split:
                effectSource.PlayOneShot(Split);
				break;
            case ClipType.Finish:
                effectSource.PlayOneShot(Finish);
                break;
            case ClipType.Timer:
                effectSource.PlayOneShot(Timer);
                break;
            case ClipType.Buoyancy:
                effectSource.PlayOneShot(Buoyancy);
                break;
            default:
                break;
        }

    }
	
	public float GetLength(ClipType _clip) {

        switch (_clip) {
            case ClipType.Lever:
                return (Lever.length);
            case ClipType.Button:
                return (Button.length);
            case ClipType.Join:
                return (Join.length);
			case ClipType.Split:
                return (Split.length);
            case ClipType.Finish:
                return (Finish.length);
            case ClipType.Timer:
                return (Timer.length);    
            case ClipType.Buoyancy:
                return (Buoyancy.length);
            default:
                return 0;
        }

    }

    public void StopJetpackSource() {
		
        jetpackFadeIn.Kill(false);
        jetpackFadeOut = jetpackSource.DOFade(0, 0.35f);

        if (hasPlayedJetpackSound) {
            hasPlayedJetpackSound = false;
        }
    }
    
    public void StopEffectSource() {
        effectSource.Stop();
    }
    
    public void StopMusicSource() {
        musicSource.Stop();
    }

}