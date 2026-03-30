using UnityEngine;
using System.Collections.Generic;
using PeruanoPower.Utils;

public class SkillGameplay : MonoBehaviour
{
    public SkillManager database;
    public int nivelJugador = 5;
    public List<Skill> MySkills = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (database == null) return;

        Skill[] listaHabilidades = database.todasLasHabilidades.ToArray();

        foreach (var s in listaHabilidades)
        {
            bool puedeAprender = GameUtils.Validate(s, x => nivelJugador >= x.nivelRequerido);

            if (puedeAprender)
            {
                MySkills.Add(s);
                GameUtils.Process(s, x => x.Ejecutar());
            }
        }

        if (GameUtils.TryFind(listaHabilidades, x => x.id == 1, out Skill encontrada))
        {
            Debug.Log("Habilidad Aprendida" + encontrada.nombre);
        }

        bool SkillExist = GameUtils.TryFind(listaHabilidades, x => x.nivelRequerido > 10, out _);

    }
}
