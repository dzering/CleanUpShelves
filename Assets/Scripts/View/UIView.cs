using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button restart;
    [SerializeField] Button quit;

    public Button Restart { get => restart; set => restart = value; }
    public Button Quit { get => quit; set => quit = value; }
    public Button Play { get => play; set => play = value; }
}
