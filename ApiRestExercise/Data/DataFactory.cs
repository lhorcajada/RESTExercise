using Data.Model;
using System;

namespace Data
{
    /// <summary>
    /// Crea el contexto de datos. Si ya fue creado lo devuelve tal cual.
    /// Cuando DataFactory se destruye este también destruye el contexo.
    /// </summary>
    public class DataFactory : IDisposable, IDataFactory
    {
        private ExerciseContext _context;

        /// <summary>
        /// Método que crea el contexto de datos. Si ya existe devuelve el existente.
        /// </summary>
        /// <returns>Devuelve el contexto de datos.</returns>
        public ExerciseContext GetContext()
        {
            return _context ?? (_context = new ExerciseContext());
        }

        #region Implementación IDisposable.
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._context == null)
            {
                return;
            }

            this._context.Dispose();
            this._context = null;
        }
        #endregion
    }
}
