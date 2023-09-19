using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEvents : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private House_Phase1 housePhase1;
    [SerializeField] private House_Phase2 housePhase2;
    [SerializeField] private House_Phase3 housePhase3;
    [SerializeField] private House_Phase4 housePhase4;


    private void Start()
    {
        PlayNextEvent();
    }

    private void PlayNextEvent()
    {
        StartCoroutine(Coroutine_PlayNextEvent());

        IEnumerator Coroutine_PlayNextEvent()
        {
            yield return new WaitForSeconds(1);

            switch (StaticData.instance.gamePhase)
            {
                case 1:
                    housePhase1.Play_Event();
                    break;
                case 2:
                    housePhase2.Play_Event();
                    break;
                case 3:
                    housePhase3.Play_Event();
                    break;
                case 4:
                    housePhase4.Play_Event();
                    break;
            }
        }
    }

}
