using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int currentStage = 1;
    public int currentround = 1;
    [SerializeField] TMP_Text stage;
    [SerializeField] TMP_Text round;


    public void StageCount()
    {
        
        if(currentround < 10)
        {
            currentround++;
            round.text = currentround + "/10 ";
        }
        else
        {
            ChangeStage();
            currentround = 1 ;
            round.text = currentround + "/10 ";
        }

    }

    public void ChangeStage()
    {
        currentStage++;
        stage.text = "스테이지" + currentStage;
    }



}
