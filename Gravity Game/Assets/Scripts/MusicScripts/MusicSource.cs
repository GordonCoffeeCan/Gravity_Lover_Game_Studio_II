using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class MusicSource : MonoBehaviour
{
    public bool IsBusy
    {
        get
        {
            if (!Scheduled)
            {
                //print("NotSched");
                return false;
            }
            if (AudA.isPlaying || AudB.isPlaying)// && Aud.timeSamples != 0)
            {
                //print("IsPlayin");
                //print(Aud.timeSamples + "/" + Aud.clip.samples);
                return true;
            }
            if (Scheduled && scheduledPlayTime > AudioSettings.dspTime)
            {
                //print("IsGonnaPlay at " + scheduledPlayTime); // + " DSPTIME: " + AudioSettings.dspTime);
                return Scheduled;
            }
            //print("Initialized");
            Init();
            return Scheduled;
        }
    }
    
    private AudioSource AudA;
    private AudioSource AudB;
    private bool ActiveAudA = true;
    private bool Scheduled;
    private bool Looping;
    private bool Fading;
    private bool CrossFading;
    private double scheduledPlayTime = System.Double.MinValue;
    private double scheduledEndTime = System.Double.MinValue;
    private double startTime;

    void Awake()
    {
        AudA = GetComponent<AudioSource>();
        AudA.playOnAwake = false;
        AudA.loop = false;
        AudB = gameObject.AddComponent<AudioSource>();
        AudB.playOnAwake = false;
        AudB.loop = false;
        startTime = AudioSettings.dspTime;
        Init();
    }

    public void PlayAt(AudioClip clipToPlay, double timeToPlay, bool looping = false)
    {
        scheduledPlayTime = timeToPlay;
        AudioSource playingSource = ActiveAudA ? AudB : AudA;
        playingSource.loop = looping;
        playingSource.clip = clipToPlay;
        playingSource.PlayScheduled(scheduledPlayTime);
        ActiveAudA = !ActiveAudA;
        Scheduled = true;
        Looping = looping;
    }

    public void LoopAt(AudioClip loopToPlay, double timeToPlay)
    {
        PlayAt(loopToPlay, timeToPlay, true);
    }

    public void CrossFadeToClip(AudioClip clipToCrossfadeTo, double whenToStartFade, double lengthOfFade, bool loopClip = false)
    {
        if (CrossFading) return;
        CrossFading = true;
        AudioSource fadeOutSource = ActiveAudA ? AudA : AudB;
        AudioSource fadeInSource = ActiveAudA ? AudB : AudA;
        fadeOutSource.DOFade(0, (float) lengthOfFade)
            //.SetId("CrossFadeOut" + gameObject.GetInstanceID())
            .SetDelay((float)(whenToStartFade-AudioSettings.dspTime))
            .SetEase(Ease.OutSine)
            .OnComplete(()=>ActiveAudA= false);
        fadeInSource.clip = clipToCrossfadeTo;
        fadeInSource.loop = loopClip;
        fadeInSource.volume = 0;
        fadeInSource.PlayScheduled(whenToStartFade);
        fadeInSource.DOFade(1, (float)lengthOfFade)
            //.SetId("CrossFadeIn" + gameObject.GetInstanceID())
            .SetDelay((float)(whenToStartFade - AudioSettings.dspTime))
            .SetEase(Ease.InSine)
            .OnComplete(()=> { CrossFading = false; scheduledEndTime = System.Double.MinValue;});
        scheduledEndTime = whenToStartFade + lengthOfFade;
    } 

    public void CrossfadeToLoop(AudioClip clipToCrossfadeTo, double whenToStartFade, double lengthOfFade)
    {
        CrossFadeToClip(clipToCrossfadeTo, whenToStartFade, lengthOfFade, true);
    }

    public void FadeOut(double whenToStartFade, double lengthOfFade)
    {
        if (CrossFading && whenToStartFade < scheduledEndTime)
        {
            AudA.DOPause();
            AudB.DOPause();
            AudA.DOFade(0, (float) lengthOfFade)
                .OnComplete(Init);
            AudB.DOFade(0, (float)lengthOfFade)
                .OnComplete(Init);
            Fading = true;
        }
        AudioSource fadeOutSource = ActiveAudA ? AudA : AudB;
        fadeOutSource.DOFade(0, (float) lengthOfFade)
            .OnComplete(Init);
        Fading = true;
    }

    private void Init()
    {
        Scheduled = false;
        Looping = false;
        CrossFading = false;
        Fading = false;
        ActiveAudA = false;
        scheduledPlayTime = startTime;
        scheduledEndTime = System.Double.MinValue;
    }

}