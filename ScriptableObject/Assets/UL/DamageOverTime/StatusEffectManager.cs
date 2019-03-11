using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Health healthscript;

    public List<int> miasmaTickTimers = new List<int>();

    void Start()
    {
        healthscript = GetComponent<Health>();
    }

    public void ApplyMiasma(int ticks)
    {
        if(miasmaTickTimers.Count <= 0)
        {
            miasmaTickTimers.Add(ticks);
            StartCoroutine(Miasma());
        }
        else
        {
            miasmaTickTimers.Add(ticks);
        }
    }

    IEnumerator Miasma()
    {
        while (miasmaTickTimers.Count > 0)
        {
            for (int i = 0; i < miasmaTickTimers.Count; i++)
            {
                miasmaTickTimers[i]--;
            }
            healthscript.health -= 5;
            miasmaTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
