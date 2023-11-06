using API33.Dto;
using API33.Handlers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<LibroDTO> BD = new List<LibroDTO>();
List<AutorDTO> DB = new List<AutorDTO>();
LibroHandler Handlers = new LibroHandler (BD);
AutorHandler AHandlers =new AutorHandler(DB);

app.MapPost("/api/v1/libros",(LibroDTO libro) => 
{
    Handlers.CrearLibro(libro);   
});

app.MapGet("/api/v1/libros/{id}", (Guid id) =>
{
    var libro = Handlers.ObtenerLibroPorId(id);

    if (libro != null)
    {
        return Results.Ok(libro);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/api/v1/libros/{id}", (Guid id, LibroDTO libro) =>
{
    Handlers.ActualizarLibro(id,libro);
});

app.MapDelete("/api/v1/libros/{id}", (Guid id) =>
{
    bool eliminado = Handlers.EliminarLibro(id);

    if (eliminado)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/api/v1/autores", (AutorDTO autor) =>
{
    AHandlers.CrearAutor(autor);  
});

app.MapGet("/api/v1/autores/{id}", (Guid id) =>
{
    var autor = AHandlers.ObtenerAutorPorId(id);

    if (autor != null)
    {
        return Results.Ok(autor);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/api/v1/autores/{id}", (Guid id,AutorDTO autor) =>
{
    AHandlers.ActualizarAutor(id,autor);
});

app.MapDelete("/api/v1/autores/{id}", (Guid id) =>
{
    bool eliminado = AHandlers.EliminarAutor(id);
    if (eliminado)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();