namespace API33.Handlers;
using API33.Dto;

public class AutorHandler
{
    private List<AutorDTO> _autor;

        public AutorHandler(List<AutorDTO> autor)
        {
            this._autor = autor;
        }

        public List<AutorDTO> ALL()
        {
            return this._autor;
        }

        public void CrearAutor(AutorDTO autor)
        {
            this._autor.Add(autor);
        }

        public AutorDTO ObtenerAutorPorId(Guid id)
        {
            foreach (var autor in this._autor)
            {
                if (autor.Id == id)
                 {
                    return autor;
                }
            }
            return null;
        }

        public void ActualizarAutor(Guid id, AutorDTO autor)
        {
            foreach (AutorDTO n in this._autor)
            {
                if (n.Id == id)
                {
                    n.Nacionalidad = autor.Nacionalidad;
                    break;
                }
            }
        }

        public bool EliminarAutor(Guid id)
        {
            var autorParaEliminar = _autor.FirstOrDefault(autor => autor.Id == id);
            if (autorParaEliminar != null)
            {
                this._autor.Remove(autorParaEliminar);
                return true;
            }
            return false;
        }
}