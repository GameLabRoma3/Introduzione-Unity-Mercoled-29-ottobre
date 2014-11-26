using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region UI
    //UI manager
    private long seconds;
    public long Seconds
    {
        get { return seconds; }
        set
        {
            seconds = value;
            SecondsText.text = string.Format("Time: {0}s", Seconds);
        }
    }
    public GUIText SecondsText;
    private long points;
    public long Points
    {
        get { return points; }
        set
        {
            points = value;
            PointsText.text = string.Format("Ponts: {0}", points);
        }
    }
    public GUIText PointsText;
    public GUIText SpeedText;
    #endregion

    public GameObject Player;
    private ShipLocomotion PlayerLocomotion;

    void Start()
    {
        InvokeRepeating("UpdateSeconds", 1, 1);
        PlayerLocomotion = Player.GetComponent<ShipLocomotion>();
        Seconds = Points = 0;
    }

    private void UpdateSeconds()
    { Seconds++; }


    void Update()
    {
        SpeedText.text = string.Format("{0:####.0}Km/h", PlayerLocomotion.Speed * 4);
    }
}
