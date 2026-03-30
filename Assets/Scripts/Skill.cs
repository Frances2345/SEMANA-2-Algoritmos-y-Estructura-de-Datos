using UnityEngine;

[CreateAssetMenu(fileName = "NuevaHabilidad", menuName = "SistemaHabilidades/Skill")]
public class Skill : ScriptableObject
{
    public int id;
    public string nombre;
    public string descripcion;
    public int costo;
    public int nivelRequerido;

    public void Ejecutar()
    {
        Debug.Log("Habilidad usada" + nombre);
    }
}
