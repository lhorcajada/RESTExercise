using Data.Model;

namespace Data
{
    /// <summary>
    /// Crea el contexto de datos. Si ya fue creado lo devuelve tal cual.
    /// Cuando DataFactory se destruye este también destruye el contexo.
    /// </summary>  
    public interface IDataFactory
    {
        /// <summary>
        /// Obtiene el contexto de datos.
        /// </summary>
        /// <returns></returns>
        ExerciseContext GetContext();

    }
}
