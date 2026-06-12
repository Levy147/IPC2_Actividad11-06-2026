var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1 Lista para guardar los datos
var misNodos = new List<NodoElemento>();

// Agregamos los dos datos iniciales
misNodos.Add(new NodoElemento { Id = 10, Valor = "Raíz Inicial" });
misNodos.Add(new NodoElemento { Id = 5, Valor = "Hijo Izquierdo" });

// pedir y ver daots
app.MapGet("/api/nodos", () => 
{
    return Results.Ok(misNodos); // Devuelve un código 200 OK y la lista
});

// enviar y guardar un dato nuevo
app.MapPost("/api/nodos", (NodoElemento nuevoNodo) =>
{
    misNodos.Add(nuevoNodo); // agregar al final de la lista
    return Results.Created("/", nuevoNodo); 
});

app.Run(); // iniciar servidor

// modelar los datos que lleva el nodo
public class NodoElemento
{
    public int Id { get; set; }
    public string Valor { get; set; } = "";
}