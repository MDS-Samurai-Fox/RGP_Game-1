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
    Tween jetpackFadeIn, jetpackFadeOut;

    void Start() {

        // jetpackFadeOut = jetpackSource.DOFade(0, 0.25f);
        // jetpackFadeIn = jetpackSource.DOFade(1, 0);
        // jetpackSource.Play();

    }

    public void Play(ClipType _clip) {

        switch (_clip) {
            case ClipType.Jetpack:
                {
                    print("<< Starting Jetpack");
					
                    jetpackFadeOut.Kill(false);
                    jetpackSource.Play();
                    jetpackFadeIn = jetpackSource.DOFade(1, 0.25f);

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
        print(">> Stopping Jetpack");
		
        jetpackFadeIn.Kill(false);
        jetpackFadeOut = jetpackSource.DOFade(0, 0.35f);

        if (hasPlayedJetpackSound) {
            hasPlayedJetpackSound = false;
        }
    }

}