using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [HeaderAttribute("Audio Sources")]
    public AudioSource source;
    public AudioSource jetpackSource;

    [HeaderAttribute("Sound Effects")]
    public AudioClip Lever;
    public AudioClip Button;
    public AudioClip Join;
	public AudioClip Split;
    public AudioClip Finish;
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
                    print("<< Starting Jetpack");
					
                    jetpackFadeOut.Kill(false);
                    jetpackSource.Play();
                    jetpackFadeIn = jetpackSource.DOFade(1, 1f);

                    if (!hasPlayedJetpackSound) {
                        hasPlayedJetpackSound = true;
                    }
                }
                break;
            case ClipType.Lever:
                source.PlayOneShot(Lever);
                break;
            case ClipType.Button:
                source.PlayOneShot(Button);
                break;
            case ClipType.Join:
                source.PlayOneShot(Join);
                break;
			case ClipType.Split:
                source.PlayOneShot(Split);
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
            case ClipType.Buoyancy:
                return (Buoyancy.length);
            default:
                return 0;
        }

    }

    public void StopSource() {
        source.Stop();
    }

    public void StopJetpackSource() {
        print(">> Stopping Jetpack");
		
        jetpackFadeIn.Kill(false);
        jetpackFadeOut = jetpackSource.DOFade(0, 0.35f);

        if (hasPlayedJetpackSound) {
            hasPlayedJetpackSound = false;
        }
    }

}