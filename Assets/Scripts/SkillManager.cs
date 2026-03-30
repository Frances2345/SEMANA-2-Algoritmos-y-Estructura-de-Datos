using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillManagerData", menuName = "SistemaHabilidades/Manager")]
public class SkillManager : ScriptableObject
{
    public List<Skill> todasLasHabilidades;
}
