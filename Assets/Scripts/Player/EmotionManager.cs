using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    public Animator playerController;
    public RuntimeAnimatorController neutralAnimator;
    public RuntimeAnimatorController angryAnimator;
    public RuntimeAnimatorController happyAnimator;
    public PlayerScript player;

    void Update()
    {

        switch (player.actualEmotion)
        {
            case Emotion.NEUTRAL:
                playerController.runtimeAnimatorController = neutralAnimator;
                player.SetNeutralParameters();
                break;
            case Emotion.ANGRY:
                playerController.runtimeAnimatorController = angryAnimator;
                player.SetAngryParameters();
                break;
            case Emotion.SAD:
                break;
            case Emotion.HAPPY:
                playerController.runtimeAnimatorController = happyAnimator;
                player.SetHappyParameters();
                break;
            default:
                break;
        }       
    }
}
