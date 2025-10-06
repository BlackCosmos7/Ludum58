using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimOnClick : MonoBehaviour
{
    public Button[] buttons;
    public Animator animator;
    public string triggerName = "Play";

    private bool animationPlayed = false;

    void Start()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlayAnimationOnce);
        }
    }

    private void PlayAnimationOnce()
    {
        if (animationPlayed) return;

        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }

        animationPlayed = true;
    }
}
