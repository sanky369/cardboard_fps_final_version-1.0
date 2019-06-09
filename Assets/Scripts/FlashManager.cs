using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashManager : MonoBehaviour
{
    public static FlashManager Instance { set; get; }

    public Image thisImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    private void Update()
    {

        if (!isInTransition)
        {
            return;
        }

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        thisImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.red, transition);

        if(transition > 1 || transition < 0)
        {
            isInTransition = false;
        }
    }


}
