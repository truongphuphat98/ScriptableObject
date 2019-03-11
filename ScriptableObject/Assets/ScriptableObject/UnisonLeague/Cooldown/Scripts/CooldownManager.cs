using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    public static CooldownManager instance;

    public List<UnisonLeagueAbilites> unisonOnCooldown = new List<UnisonLeagueAbilites>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        for(int i = 0; i < unisonOnCooldown.Count; i++)
        {
            unisonOnCooldown[i].currentCooldown -= Time.deltaTime;

            if(unisonOnCooldown[i].currentCooldown <= 0)
            {
                unisonOnCooldown[i].currentCooldown = 0;
                unisonOnCooldown.Remove(unisonOnCooldown[i]);
            }
        }
    }

    public void StartCooldown(UnisonLeagueAbilites unison)
    {
        if (!unisonOnCooldown.Contains(unison))
        {
            unison.currentCooldown = unison.maxCooldown;
            unisonOnCooldown.Add(unison);
        }
    }
}
