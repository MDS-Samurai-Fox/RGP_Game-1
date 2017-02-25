using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private GameManager gameManager;

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

    // Jetpack variables
    bool hasPlayedJetpackSound = false;
    Tween jetpackFadeIn, jetpackFadeOut;

    void Awake() {

        gameManager = FindObjectOfType<GameManager> ();

    }

    void Update() {

        if (!gameManager.canUpdate)
            return;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) {
            
            Play(ClipType.Jetpack);
            
        } else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")) {
            
            StopJetpackSource();
            
        }

    }

    /// <summary>
    /// Plays any given clip
    /// </summary>
    /// <param name="_clip">The name of the clip to play</param>
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
            case ClipType.BlastStart:
                effectSource.PlayOneShot(BlastStart, 0.5f);
                break;
            case ClipType.BlastEnd:
                effectSource.PlayOneShot(BlastEnd, 0.5f);
                break;
            case ClipType.Finish:
                effectSource.PlayOneShot(Finish);
                break;
            case ClipType.Timer:
                effectSource.PlayOneShot(Timer);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Gets the length of the desired clip, useful for making tweens last the duration of the sound
    /// </summary>
    /// <param name="_clip">The name of the clip</param>
    /// <returns>The clip's duration</returns>
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
            case ClipType.BlastStart:
                return (BlastStart.length);
            case ClipType.BlastEnd:
                return (BlastEnd.length);
            case ClipType.Timer:
                return (Timer.length);
            default:
                return 0;
        }

    }

    /// <summary>
    /// Stops the jetpack audio source from playing
    /// </summary>
    public void StopJetpackSource() {

        jetpackFadeIn.Kill(false);
        jetpackFadeOut = jetpackSource.DOFade(0, 0.35f);

        if (hasPlayedJetpackSound) {
            hasPlayedJetpackSound = false;
        }
    }

    /// <summary>
    /// Stops the effects audio source from playing
    /// </summary>
    public void StopEffectSource() {
        effectSource.Stop();
    }

    /// <summary>
    /// Stops the music's audio source from playing
    /// </summary>
    public void StopMusicSource() {
        musicSource.Stop();
    }

}