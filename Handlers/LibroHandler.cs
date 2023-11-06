namespace API33.Handlers;
using API33.Dto;

public class LibroHandler
{
    private  List<LibroDTO> _libro;

        public LibroHandler(List<LibroDTO> libro)
        {
            this._libro = libro;
        }

        public List<LibroDTO> ALL()
        {
            return this._libro;
        }

        public void CrearLibro(LibroDTO libro)
        {
            this._libro.Add(libro);
        }

        public LibroDTO ObtenerLibroPorId(Guid id)
        {
            foreach (var libro in this._libro)
            {
                if (libro.Id == id)
                 {
                    return libro;
                }
            }
            return null;
        }

        public void ActualizarLibro(Guid id, LibroDTO libro)
        {
            foreach (LibroDTO m in this._libro)
            {
                if (m.Id == id)
                {
                    m.Título = libro.Título;
                    break;
                }
            }
        }

        public bool EliminarLibro(Guid id)
        {
            var libroParaEliminar = _libro.FirstOrDefault(libro => libro.Id == id);
            if (libroParaEliminar != null)
            {
                this._libro.Remove(libroParaEliminar);
                return true;
            }
            return false;
        }
}