namespace API33.Dto;

public class LibroDTO
{
    public Guid Id { get; set; }
    public string Título { get; set; }
    public string Resumen { get; set; }
    public Guid AutorId { get; set; }
}
