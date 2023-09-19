using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Phase1 : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private List<DialogScriptable> dialog1;
    [SerializeField] private List<DialogScriptable> dialog2;
    [SerializeField] private List<DialogScriptable> dialog3;
    [SerializeField] private List<DialogScriptable> dialog4;

    [Header("[Values]")]
    [SerializeField] private int currentEventPhase;

    public void Play_Event()
    {
        Play_NextPhase();
    }

    private void Play_NextPhase()
    {
        currentEventPhase++;

        switch (currentEventPhase)
        {
            case 0:
                EventPhase_0();
                break;
        }
    }

    private void EventPhase_0()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndPhase_0;
        StartCoroutine(Coroutine_Phase());

        IEnumerator Coroutine_Phase()
        {
            yield return new WaitForSeconds(2);
            UI_DialogPanel.instance.ShowDialog(dialog1);
        }
    }

    private void EventPhase_1()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndPhase_0;
        StartCoroutine(Coroutine_Phase());

        IEnumerator Coroutine_Phase()
        {
            yield return new WaitForSeconds(2);
            UI_DialogPanel.instance.ShowDialog(dialog1);
        }
    }

    private void OnEndPhase_0()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndPhase_0;
        Play_NextPhase();
    }

}
