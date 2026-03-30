using UnityEngine;
using TMPro;
using System.Collections.Generic;
using PeruanoPower.Utils;

public class SkillGameplay : MonoBehaviour
{
    public SkillManager database;
    public int nivelJugador = 20;
    public string nombreJugador = "PeruanoPower";

    public TextMeshProUGUI NombreyNivel;
    public TextMeshProUGUI Habilidades;
    public TextMeshProUGUI MensajeExtra;

    public List<Skill> MySkills = new();

    private void Start()
    {
        ActualizarInterfaz();
    }

    public void BotonSubirNivel()
    {
        nivelJugador++;
        ActualizarInterfaz();
    }

    public void ActualizarInterfaz()
    {
        if (database == null) 
        {
            return;
        }

        NombreyNivel.text = nombreJugador + " - Nivel: " + nivelJugador;
        Habilidades.text = "";
        MySkills.Clear();

        Skill[] listaHabilidades = database.todasLasHabilidades.ToArray();
        bool algunaAprendida = false;

        foreach (var s in listaHabilidades)
        {
            if (GameUtils.Validate(s, x => nivelJugador >= x.nivelRequerido))
            {
                algunaAprendida = true;
                MySkills.Add(s);

                string desc = GameUtils.Transform(s, x => x.descripcion);

                Habilidades.text += s.nombre + "\n";
                Habilidades.text += desc + "\n\n";

                GameUtils.Process(s, x => x.Ejecutar());

            }
        }
        if (!algunaAprendida)
        {
            Habilidades.text = "Ninguna habilidad aprendida";
        }

        if (GameUtils.TryFind(listaHabilidades, x => x.id == 1, out Skill encontrada))
        {
            MensajeExtra.text = "[INFO]: " + encontrada.nombre + " detectada en DB";
        }

        bool maestrasExist = GameUtils.TryFind(listaHabilidades, x => x.nivelRequerido > 10, out _);
        MensajeExtra.text += "\n¿Habilidades de alto nivel?: " + (maestrasExist ? "SÍ" : "NO");
    }
    
}
